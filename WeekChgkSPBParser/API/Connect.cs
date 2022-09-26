using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Polling;

namespace WeekChgkSPBParser.API
{
    internal class Connect
    {
        internal ITelegramBotClient Bot = new TelegramBotClient(Constants.Token.TgToken);

        internal void Start()
        {
            CancellationTokenSource cts = new();
        }
    }
}
