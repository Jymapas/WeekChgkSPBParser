namespace WeekChgkSPBParser
{
    internal record class Constants
    {
        internal const int ChatId = -635211124;
        internal const string ChannelId = "@sapamyJ";
        internal const string TxtAnnouncePath = @"C:\\Users\petrakov_as\Desktop\anounsment.txt";
        internal const string TgTokenPath = "TgToken.txt";
        internal const string LJUrl = "https://chgk-spb.livejournal.com/2596838.html";
        internal const string TgHead = "Продолжаем вести список синхронов в Санкт-Петербурге.";
        internal const string RegexPattern = @"(?<=(\n|<br\s?/?>))^[<b>][\w\W]+?(?=</p>)";
    }
}