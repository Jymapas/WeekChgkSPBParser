using System.Text;

namespace WeekChgkSPBParser.API
{
    internal class TgHtmlFormat
    {
        private string _announcement;
        public string Announcement { get; }

        public TgHtmlFormat(StreamReader sr)
        {
            _announcement = TgFormat(sr);
        }

        internal string TgFormat(StreamReader sr)
        {
            char[] rawArray;
            StringBuilder sb = new();
            int indexOfB = 0;
            rawArray = new char[sr.BaseStream.Length];
            sr.Read(rawArray, 0, (int)sr.BaseStream.Length);
            foreach (char c in rawArray)
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