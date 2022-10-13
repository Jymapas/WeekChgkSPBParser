namespace WeekChgkSPBParser
{
    internal record class Constants
    {
        internal static readonly string TgToken = GetFromTxt("TgToken.txt");
        internal const string LJUrl = "https://chgk-spb.livejournal.com/2596838.html";
        internal const int ChatId = -635211124;
        internal const string ChannelId = "@sapamyJ";
        internal const string TxtAnnouncePath = @"C:\\Users\petrakov_as\Desktop\anounsment.txt";
        internal const string TgHead = "Продолжаем вести список синхронов в Санкт-Петербурге.";
        private static string GetFromTxt(string path)
        {
            using StreamReader sr = new FileInfo(path).OpenText();
            return sr.ReadToEnd();
        }
    }
}