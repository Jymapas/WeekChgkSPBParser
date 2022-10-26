using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WeekChgkSPBParser.Constants;
using WeekChgkSPBParser.Helpers;

namespace WeekChgkSPBParser.API
{
    internal class MessagesHandler
    {
        private readonly List<long> _adminsIds = AdminListHelper.GetIds();
        private ITelegramBotClient _botClient;
        private CancellationToken _cancellationToken;
        private string _messageText;
        private string _txtPost;
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if ((update.Type != UpdateType.Message) || (update.Message!.Type != MessageType.Text)) return;
            var message = update?.Message;

            if (!_adminsIds.Contains(message.From.Id))
            {
                await SendMessage(message.Chat.Id, ServiceLines.WarningMessage);
                return;
            }

            string txtPost = TxtPostReader.GetAnnounce(Paths.TxtAnnounce);

            switch (message.Text)
            {
                case Commands.Announcement:
                case Commands.AnnouncementFromLj:
                    await SendMessage(message.Chat.Id, _txtPost);
                    return;
                case Commands.AnnouncementToChannel:
                case Commands.AnnouncementFromLjToChannel:
                    await SendMessage(Id.Channel, _txtPost);
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
    }
}