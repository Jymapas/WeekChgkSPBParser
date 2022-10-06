namespace WeekChgkSPBParser.API
{
    internal class TxtPost
    {
        string anounce = GetAnounce();
        public string Anounce 
        {
            get => anounce;
            set => anounce = GetAnounce();
        }
        private static string GetAnounce()
        {
            FileInfo file = new(Constants.Path);
            using (StreamReader streamReader = file.OpenText())
            {
                TgHtmlFormat t = new(streamReader);
                return t.Announcement;
            }
        }
    }
}
