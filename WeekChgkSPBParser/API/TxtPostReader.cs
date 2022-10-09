namespace WeekChgkSPBParser.API
{
    internal class TxtPostReader
    {
        private string _announce = GetAnnounce(Constants.TxtAnnouncePath);
        public string Announce { get; private set; }
        public static string GetAnnounce(string path)
        {
            FileInfo file = new(path);
            using StreamReader streamReader = file.OpenText();
            TgHtmlFormat t = new(streamReader);
            return t.Announcement;
        }
    }
}