using System.Text.RegularExpressions;

namespace WeekChgkSPBParser.API
{
    internal class TgHtmlFormat
    {
        public string Announcement { get; private set; }
        internal TgHtmlFormat(string inputString)
        {
            var match = Regex.Match(inputString, Constants.RegexPattern, RegexOptions.Multiline);
            Announcement = $"{Constants.TgHead}\n\n{match.Value}";
        }
    }
}