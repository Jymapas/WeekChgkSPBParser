using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace WeekChgkSPBParser.API
{
    public class Connect
    {
        private ITelegramBotClient Bot = new TelegramBotClient(Constants.TgToken);
        private MessagesHandler _messagesHandler = new();

        internal void Start()
        {
            using CancellationTokenSource cts = new();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            Bot.StartReceiving(
                _messagesHandler.HandleUpdateAsync,
                _messagesHandler.HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );

            Console.ReadLine();
        }
    }
}
