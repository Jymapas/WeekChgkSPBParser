using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using WeekChgkSPBParser.Constants;
using WeekChgkSPBParser.Helpers;

namespace WeekChgkSPBParser.API
{
    public class Connect
    {
        private string _botToken;
        private MessagesHandler _messagesHandler = new();

        /// <summary>
        /// Основной метод программы.
        /// В нём происходит инициализация бота и вызывается обработчик сообщений боту.
        /// </summary>
        internal void Start()
        {
            _botToken = GetFromTxtHelper.GetFromTxt(Paths.TgToken);
            if (_botToken.Equals(string.Empty))
            {
                Console.WriteLine("Tg Token is empty!");
                return;
            }

            ITelegramBotClient bot = new TelegramBotClient(_botToken);
            using CancellationTokenSource cts = new();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            bot.StartReceiving(
                _messagesHandler.HandleUpdateAsync,
                _messagesHandler.HandleErrorAsync,
                receiverOptions,
                cancellationToken
                );
        }
    }
}