using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.Helpers
{
    internal class AdminListHelper
    {
        /// <summary>
        /// Возвращает из файла List of long со списком ID админов
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>List of long со списком ID админов</returns>
        public static List<long> GetIds(string path = Paths.AdminIds)
        {
            var allText = GetFromTxtHelper.GetFromTxt(path);
            string[] splitLines = allText.Split(Environment.NewLine);
            List<long> ids = new(splitLines.Length);
            foreach (var line in splitLines)
            {
                long.TryParse(line, out var id);
                if (id != 0)
                    ids.Add(id);
            }
            return ids;
        }
    }
}