using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace WeekChgkSPBParser.API
{
    public class Connect
    {
        private ITelegramBotClient _bot = new TelegramBotClient(GetFromTxtHelper.GetFromTxt(Constants.TgTokenPath));
        private MessagesHandler _messagesHandler = new();

        internal void Start()
        {
            if (!string.Empty.Equals(GetFromTxtHelper.GetFromTxt(Constants.TgTokenPath)))
            {
                using CancellationTokenSource cts = new();
                var cancellationToken = cts.Token;
                var receiverOptions = new ReceiverOptions
                {
                    AllowedUpdates = { }
                };

                _bot.StartReceiving(
                    _messagesHandler.HandleUpdateAsync,
                    _messagesHandler.HandleErrorAsync,
                    receiverOptions,
                    cancellationToken
                );
            }
            else
                Console.WriteLine("Tg Token is empty!");

            Console.ReadLine();
        }
    }
}
