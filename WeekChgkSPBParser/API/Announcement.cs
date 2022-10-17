using System.Text.RegularExpressions;

namespace WeekChgkSPBParser.API
{
    internal class Announcement
    {
        public string Text { get; private set; }
        internal Announcement(string inputString)
        {
            var match = Regex.Match(inputString, Constants.RegexPattern, RegexOptions.Multiline);
            Text = $"{Constants.TgHead}\n\n{match.Value}";
        }
    }
}