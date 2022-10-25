using WeekChgkSPBParser.API;
using WeekChgkSPBParser.Helpers;

namespace WeekChgkSPBParser.Readers
{
    /// <summary>
    /// Абстрактный клас, от которого наследуются посты из ЖЖ и из .txt
    /// </summary>
    internal abstract class PostReader
    {
        /// <summary>
        /// Возвращает текст анонса в формате ТГ-поста.
        /// </summary>
        /// <param name="path">Путь к файлу, в котором хранится копия поста в ЖЖ в HTML-LJ формате.</param>
        /// <returns>Текст анонса в формате ТГ-поста</returns>
        public static string GetAnnounce(string path)
        {
            var txt = GetFromTxtHelper.GetFromTxt(path);
            Announcement announcement = new(txt);
            return announcement.Text;
        }
    }
}