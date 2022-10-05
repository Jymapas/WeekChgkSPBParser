using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace WeekChgkSPBParser.API
{
    internal class Connect
    {
        internal ITelegramBotClient Bot = new TelegramBotClient(Constants.TgToken);

        internal void Start()
        {
            CancellationTokenSource cts = new();
        }
    }
}
