using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WeekChgkSPBParser.API
{
    internal class MessagesHandler
    {
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken ct)
        {
            if (update.Type != UpdateType.Message) return;
            if (update.Message!.Type != MessageType.Text) return;
            var message = update?.Message;
            TxtPost _txtPost = new();
            Console.WriteLine(_txtPost.Anounce);
            if (_txtPost.Anounce != null)
            {
                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: -635211124,
                    text: _txtPost.Anounce,
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
