using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.API
{
    internal class MessagesHandler
    {
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken ct)
        {
            if ((update.Type != UpdateType.Message) || (update.Message!.Type != MessageType.Text)) return;
            var message = update?.Message;

            if (!Id.Admins.Contains(message.From.Id))
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: ServiceLines.WarningMessage,
                    cancellationToken: ct
                    );
                return;
            }

            string txtPost = TxtPostReader.GetAnnounce(Paths.TxtAnnounce);

            switch (message.Text)
            {
                case Commands.announcementFromTxt:
                    await botClient.SendTextMessageAsync(
                        chatId: Id.Chat,
                        text: txtPost,
                        parseMode: ParseMode.Html,
                        disableWebPagePreview: true,
                        cancellationToken: ct
                        );
                    return;
                case Commands.announcementFromTxtToChannel:
                    await botClient.SendTextMessageAsync(
                        chatId: Id.Channel,
                        text: txtPost,
                        parseMode: ParseMode.Html,
                        disableWebPagePreview: true,
                        cancellationToken: ct
                        );
                    return;
                default:
                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: ServiceLines.UnknownСommand,
                        cancellationToken: ct
                        );
                    return;
            }

            if (txtPost != null)
            {
                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: Id.Chat,
                    text: txtPost,
                    parseMode: ParseMode.Html,
                    disableWebPagePreview: true,
                    cancellationToken: ct
                    );
            }
        }
        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}