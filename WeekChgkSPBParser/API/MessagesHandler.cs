﻿using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WeekChgkSPBParser.API
{
    internal class MessagesHandler
    {
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken ct)
        {
            if ((update.Type != UpdateType.Message) || (update.Message!.Type != MessageType.Text)) return;
            var message = update?.Message;
            string txtPost = TxtPostReader.GetAnnounce(Constants.TxtAnnouncePath);
            Console.WriteLine(txtPost);
            if (txtPost != null)
            {
                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: Constants.ChatId,
                    text: txtPost,
                    cancellationToken: ct,
                    parseMode: ParseMode.Html
                    );
            }
        }
        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}
