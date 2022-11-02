﻿using System.Globalization;
using System.Text.RegularExpressions;
using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.API
{
    /// <summary>
    /// Класс анонсов. Создаёт анонс в формате ТГ-поста.
    /// </summary>
    internal class GetAnnouncement
    {
        private DateOnly _today = DateOnly.FromDateTime(DateTime.Now);
        
        /// <summary>
        /// Текст анонса в формате ТГ-поста
        /// </summary>
        public string Text { get; }
        
        /// <summary>
        /// Создаёт анонс в формате ТГ-поста
        /// </summary>
        /// <param name="inputLines">Текст полного анонса, разбитый на строки</param>
        internal GetAnnouncement(string[] inputLines)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var inputString = ClearOldInfo(inputLines, today);
            var match = Regex.Match(inputString, Patterns.CutAnnouncement, RegexOptions.Multiline);
            Text = match.Value.Equals(string.Empty) ? string.Empty : $"{ServiceLines.TgHead}\n\n{match.Value}";
        }

        /// <summary>
        /// Убирает из анонса старую информацию
        /// </summary>
        /// <param name="lines">Текст анонса, разбитый на строки</param>
        /// <param name="today">Объект DateOnly, указывающий на сегодняшний день</param>
        /// <returns>Текст анонса без старой информации</returns>
        private static string ClearOldInfo(string[] lines, DateOnly today)
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

                if (ShouldSkip(line, today, ruCulture))
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
        /// <param name="today">Объект DateOnly, указывающий на сегодняшний день</param>
        /// <param name="ruCulture">Указание на русскую культуру для парсинга строки в DateOnly</param>
        /// <returns>Требуется ли пропустить строку</returns>
        private static bool ShouldSkip(string line, DateOnly today, CultureInfo ruCulture)
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
            
            return date < today;
        }
    }
}