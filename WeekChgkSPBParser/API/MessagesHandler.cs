using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WeekChgkSPBParser.Constants;
using WeekChgkSPBParser.Helpers;
using WeekChgkSPBParser.Readers;

namespace WeekChgkSPBParser.API
{
    /// <summary>
    /// Обработчик сообщений боту.
    /// </summary>
    internal class MessagesHandler
    {
        private readonly List<long> _adminsIds = AdminListHelper.GetIds();
        private ITelegramBotClient _botClient;
        private CancellationToken _cancellationToken;

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            _botClient = botClient;
            _cancellationToken = cancellationToken;
            if ((update.Type != UpdateType.Message) || (update.Message!.Type != MessageType.Text)) return;
            var message = update?.Message;
            string messageText = message.Text.ToLower();

            if (!_adminsIds.Contains(message.From.Id))
            {
                await SendMessage(message.Chat.Id, ServiceLines.WarningMessage);
                return;
            }

            IPostReader reader = Commands.LjCommands.Contains(messageText)
                ? new LjPostReader()
                : new TxtPostReader();

            string txtPost = reader.GetAnnounce();

            if (txtPost.Equals(string.Empty))
            {
                await SendMessage(message.Chat.Id, ServiceLines.EmptyAnnouncementWarning);
                return;
            }

            switch (messageText)
            {
                case Commands.Announcement:
                case Commands.AnnouncementFromLj:
                    await SendMessage(message.Chat.Id, txtPost);
                    return;
                case Commands.AnnouncementToChannel:
                case Commands.AnnouncementFromLjToChannel:
                    await SendMessage(Id.Channel, txtPost);
                    return;
                default:
                    await SendMessage(message.Chat.Id, ServiceLines.UnknownСommand);
                    return;
            }
        }

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
        /// <summary>
        /// Отправка сообщений ботом
        /// </summary>
        /// <param name="id">Id пользователя или чата, куда будет отправлено сообщение</param>
        /// <param name="text">Текст сообщения в HTML формате</param>
        private async Task SendMessage(long id, string text)
        {
            await _botClient.SendTextMessageAsync(
                chatId: id,
                text: text,
                parseMode: ParseMode.Html,
                disableWebPagePreview: true,
                cancellationToken: _cancellationToken
                );
        }
        /// <summary>
        /// Отправка сообщений ботом
        /// </summary>
        /// <param name="id">Id канала (в формате "@chanelLink", куда будет отправлено сообщение</param>
        /// <param name="text">Текст сообщения в HTML формате</param>
        private async Task SendMessage(string id, string text)
        {
            await _botClient.SendTextMessageAsync(
                chatId: id,
                text: text,
                parseMode: ParseMode.Html,
                disableWebPagePreview: true,
                cancellationToken: _cancellationToken
                );
        }
    }
}