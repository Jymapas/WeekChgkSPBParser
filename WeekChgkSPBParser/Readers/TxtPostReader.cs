using WeekChgkSPBParser.API;
using WeekChgkSPBParser.Helpers;
using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.Readers
{
    /// <summary>
    /// Текст анонса, который берётся из .txt
    /// </summary>
    internal class TxtPostReader : IPostReader
    {
        /// <summary>
        /// Возвращает текст анонса в формате ТГ-поста.
        /// </summary>
        /// <returns>Текст анонса в формате ТГ-поста</returns>
        public string GetAnnounce()
        {
            var txt = GetFromTxtHelper.GetFromTxt(Paths.TxtAnnounce);
            Announcement announcement = new(txt);
            return announcement.Text;
        }
    }
}