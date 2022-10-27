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
            string allText = GetFromTxtHelper.GetFromTxt(path);
            List<long> ids = new();
            foreach (string line in allText.Split(Environment.NewLine))
            {
                long.TryParse(line, out long id);
                if (id != 0)
                    ids.Add(id);
            }
            return ids;
        }
    }
}