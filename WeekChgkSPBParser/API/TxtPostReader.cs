namespace WeekChgkSPBParser.API
{
    public class TxtPostReader
    {
        public static string GetAnnounce(string path)
        {
            FileInfo file = new(path);
            using StreamReader streamReader = file.OpenText();
            TgHtmlFormat t = new(streamReader.ReadToEnd());
            return t.Announcement;
        }
    }
}