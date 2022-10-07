using System.Text;

namespace WeekChgkSPBParser.API
{
    internal class TgHtmlFormat
    {
        private string _announcement;
        private char[] _rawArray;

        public TgHtmlFormat(StreamReader sr)
        {
            _announcement = TgFormat(sr);
        }

        public string Announcement
        {
            get => _announcement;
        }

        internal string TgFormat(StreamReader sr)
        {
            StringBuilder sb = new();
            int indexOfB = 0;
            _rawArray = new char[sr.BaseStream.Length];
            sr.Read(_rawArray, 0, (int)sr.BaseStream.Length);
            foreach (char c in _rawArray)
            {
                sb.Append(c);
                if ((indexOfB == 0) && (c == 'b'))
                {
                    indexOfB = sb.Length - 1;
                }
            }
            sb.Remove(0, indexOfB)
                .Replace(@"</p>", "")
                .Insert(0, Constants.TgHead);
            return sb.ToString();
        }
    }
}
