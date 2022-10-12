using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace WeekChgkSPBParser.API
{
    internal class Connect
    {
        private ITelegramBotClient _bot = new TelegramBotClient(Constants.TgToken);
        private MessagesHandler _messagesHandler = new();

        internal void Start()
        {
            CancellationTokenSource cts = new();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };

            _bot.StartReceiving(
                _messagesHandler.HandleUpdateAsync,
                _messagesHandler.HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
        }
    }
}
