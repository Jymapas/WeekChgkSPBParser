using System.Text.RegularExpressions;

namespace WeekChgkSPBParser.API
{
    internal class TgHtmlFormat
    {
        public string Announcement { get; private set; }
        internal TgHtmlFormat(string s)
        {
            Match m = Regex.Match(s, @"(?<=(\n|<br\s?/?>))^[<b>][\w\W]+?(?=</p>)", RegexOptions.Multiline);
            Announcement = $"{Constants.TgHead}\n\n{m.Value}";
        }
    }
}