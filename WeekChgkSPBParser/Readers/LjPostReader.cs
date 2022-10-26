using WeekChgkSPBParser.API;
using WeekChgkSPBParser.Constants;
using System.Text.RegularExpressions;
using System.Net;

namespace WeekChgkSPBParser.Readers
{
    /// <summary>
    /// Текст анонса, который берётся из ЖЖ
    /// </summary>
    internal class LjPostReader : PostReader
    {
        /// <summary>
        /// Возвращает анонс из ЖЖ поста по ссылке.
        /// </summary>
        /// <param name="path">URL страницы</param>
        public static new string GetAnnounce(string path)
        {
            var txt = GetSource(path);
            Announcement announcement = new(txt);
            return announcement.Text;
        }
        /// <summary>
        /// Получает полный HTML-код страницы
        /// </summary>
        /// <param name="url">URL страницы</param>
        private static string GetSource(string url)
        {
            using HttpClient client = new();
            try
            {
                string source = client.GetStringAsync(url).Result;
                return CutAnnounce(source);
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Возвращает текст в формате, как при HTML-редактировании анонса
        /// </summary>
        /// <param name="source">Полный HTML-код страницы</param>
        private static string CutAnnounce(string source)
        {
            var match = Regex.Matches(source, ServiceLines.CutSourcePattern, RegexOptions.Multiline)[0];
            return Regex.Replace(match.Value, @"<br.*?>", "", RegexOptions.Multiline);

        }
    }
}