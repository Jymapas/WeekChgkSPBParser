namespace WeekChgkSPBParser.API
{
    internal class TxtPost
    {
        internal string Anounce()
        {
            FileInfo file = new(Constants.Path);
            using StreamReader streamReader = file.OpenText();
            TgHtmlFormat t = new(streamReader);
            return t.Announcement;
        }
    }
}
