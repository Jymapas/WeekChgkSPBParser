using WeekChgkSPBParser.API;
using WeekChgkSPBParser.Constants;
using System.Text.RegularExpressions;

namespace WeekChgkSPBParser.Readers
{
    /// <summary>
    /// Текст анонса, который берётся из ЖЖ
    /// </summary>
    internal class LjPostReader : IPostReader
    {
        /// <summary>
        /// Возвращает анонс из ЖЖ поста по ссылке.
        /// </summary>
        /// <returns>Текст анонса в формате ТГ-поста</returns>
        public string GetAnnounce()
        {
            var txt = GetSource(Paths.LjUrl);
            if (txt.Equals(null))
                return string.Empty;
            Announcement announcement = new(txt);
            return announcement.Text;
        }
        /// <summary>
        /// Получает полный HTML-код страницы
        /// </summary>
        /// <param name="url">URL страницы</param>
        private static string[] GetSource(string url)
        {
            using HttpClient client = new();
            try
            {
                var source = client.GetStringAsync(url).Result;
                return CutAnnounce(source);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Возвращает текст в формате, как при HTML-редактировании анонса
        /// </summary>
        /// <param name="source">Полный HTML-код страницы</param>
        private static string[] CutAnnounce(string source)
        {
            var match = Regex.Matches(source, Patterns.CutSource, RegexOptions.Multiline)[0];
            return Regex.Split(match.Value, @"<br.*?>", RegexOptions.Multiline);

        }
    }
}