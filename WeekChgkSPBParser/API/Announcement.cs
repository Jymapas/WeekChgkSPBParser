﻿using System.Globalization;
using System.Text.RegularExpressions;
using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.API
{
    /// <summary>
    /// Класс анонсов. Создаёт анонс в формате ТГ-поста.
    /// </summary>
    internal class Announcement
    {
        private static readonly CultureInfo RuCulture = new("ru-RU");
        private static readonly DateTimeStyles None = DateTimeStyles.None;

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
            var inputString = ClearOldInfos(inputLines);
            var match = Regex.Match(inputString, Patterns.CutAnnouncement, RegexOptions.Multiline);
            Text = match.Value.Equals(string.Empty) ? string.Empty : $"{ServiceLines.TgHead}\n\n{match.Value}";
        }
        
        /// <summary>
        /// Убирает из анонса старую информацию
        /// </summary>
        /// <param name="lines">Текст анонса, разбитый на строки</param>
        /// <returns>Текст анонса без старой информации</returns>
        private static string ClearOldInfos(string[] lines)
        {
            List<string> clearLines = new(lines.Length);
            clearLines.Add("\n");
            var tooOld = true;
            var today = DateOnly.FromDateTime(DateTime.Today);
            foreach (var line in lines)
            {
                if (!tooOld)
                {
                    clearLines.Add(line);
                    continue;
                }
                
                if(line.Length < 7)
                    continue;

                var subLine = Regex.Match(line, Patterns.СutDate).Value;
                if (!DateOnly.TryParseExact(subLine, DateFormat.Day, RuCulture, None, out var date))
                {
                    continue;
                }

                if (date < today)
                    continue;

                clearLines.Add(line);
                tooOld = false;
            }

            return string.Join("\n", clearLines);
        }
    }
}