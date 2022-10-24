using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.Helpers
{
    internal class AdminListHelper
    {
        /// <summary>
        /// Возвращает из файл List of long со списком ID админов
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public static List<long> Ids(string path = Paths.AdminIds)
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