using System.Text.RegularExpressions;
using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.API
{
    /// <summary>
    /// Класс анонсов. Создаёт анонс в формате ТГ-поста.
    /// </summary>
    internal class Announcement
    {
        /// <summary>
        /// Текст анонса в формате ТГ-поста
        /// </summary>
        public string Text { get; }
        internal Announcement(string inputString)
        {
            var match = Regex.Match(inputString, Patterns.CutAnnouncement, RegexOptions.Multiline);
            Text = match.Value.Equals(string.Empty) ? string.Empty : $"{ServiceLines.TgHead}\n\n{match.Value}";
        }
    }
}