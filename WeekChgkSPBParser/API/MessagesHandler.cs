﻿using Telegram.Bot;
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
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: ServiceLines.WarningMessage,
                    cancellationToken: cancellationToken
                    );
                return;
            }

            string txtPost = TxtPostReader.GetAnnounce(Paths.TxtAnnounce);

            switch (message.Text)
            {
                case Commands.announcement:
                    await botClient.SendTextMessageAsync(
                        chatId: Id.Chat,
                        text: txtPost,
                        parseMode: ParseMode.Html,
                        disableWebPagePreview: true,
                        cancellationToken: cancellationToken
                        );
                    return;
                case Commands.announcementToChannel:
                    await botClient.SendTextMessageAsync(
                        chatId: Id.Channel,
                        text: txtPost,
                        parseMode: ParseMode.Html,
                        disableWebPagePreview: true,
                        cancellationToken: cancellationToken
                        );
                    return;
                default:
                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: ServiceLines.UnknownСommand,
                        cancellationToken: cancellationToken
                        );
                    return;
            }
        }
        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}