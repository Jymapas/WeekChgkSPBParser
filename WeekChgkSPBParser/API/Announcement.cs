using System.Text.RegularExpressions;
using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.API
{
    internal class Announcement
    {
        public string Text { get; }
        internal Announcement(string inputString)
        {
            var match = Regex.Match(inputString, ServiceLines.RegexPattern, RegexOptions.Multiline);
            Text = match.Value.Equals(string.Empty) ? string.Empty : $"{ServiceLines.TgHead}\n\n{match.Value}";
        }
    }
}