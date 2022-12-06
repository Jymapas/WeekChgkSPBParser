using System.Globalization;
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
        
        /// <summary>
        /// Создаёт анонс в формате ТГ-поста
        /// </summary>
        /// <param name="inputLines">Текст полного анонса, разбитый на строки</param>
        internal Announcement(string[] inputLines)
        {
            var inputString = ClearOldInfo(inputLines);
            var match = Regex.Match(inputString, Patterns.CutAnnouncement, RegexOptions.Multiline);
            Text = match.Value.Equals(string.Empty) ? string.Empty : $"{ServiceLines.TgHead}\n\n{match.Value}";
        }

        /// <summary>
        /// Убирает из анонса старую информацию
        /// </summary>
        /// <param name="lines">Текст анонса, разбитый на строки</param>
        /// <returns>Текст анонса без старой информации</returns>
        private string ClearOldInfo(string[] lines)
        {
            var ruCulture = new CultureInfo("ru-RU");
            List<string> clearLines = new(lines.Length) { "\n" };
            var tooOld = true;
            
            foreach (var line in lines)
            {
                if (!tooOld)
                {
                    clearLines.Add(line);
                    continue;
                }

                if (ShouldSkip(line, ruCulture))
                    continue;
                
                tooOld = false;
                clearLines.Add(line);
            }

            return string.Join("\n", clearLines);
        }

        /// <summary>
        /// Проверка на то, требуется ли пропустить строку
        /// </summary>
        /// <param name="line">Отдельная строка в анонсе</param>
        /// <param name="ruCulture">Указание на русскую культуру для парсинга строки в DateOnly</param>
        /// <returns>Требуется ли пропустить строку</returns>
        private bool ShouldSkip(string line, CultureInfo ruCulture)
        {
            if (line.Length < 7) return true;
            
            var subLine = Regex.Match(line, Patterns.СutDate).Value;
            if (!DateOnly.TryParseExact(
                    s: subLine, 
                    format: DateFormat.Day, 
                    provider: ruCulture,
                    style: DateTimeStyles.None,
                    result: out var date))
                return true;
            
            return date < DateOnly.FromDateTime(DateTime.Today);
        }
    }
}