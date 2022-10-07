namespace WeekChgkSPBParser.API
{
    internal class TxtPost
    {
        private string _anounce = GetAnounce();
        public string Anounce 
        {
            get => _anounce;
            private set => _anounce = GetAnounce();
        }
        private static string GetAnounce()
        {
            FileInfo file = new(Constants.Path);
            using StreamReader streamReader = file.OpenText();
            TgHtmlFormat t = new(streamReader);
            return t.Announcement;
        }
    }
}
