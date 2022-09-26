using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WeekChgkSPBParser.API
{
    internal class MessagesHandler
    {
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken ct)
        {
            if (update.Type != UpdateType.Message)
                return;
            var message = update?.Message;
            if (message?.Text == null)
                return;
            
            
        }
    }
}
