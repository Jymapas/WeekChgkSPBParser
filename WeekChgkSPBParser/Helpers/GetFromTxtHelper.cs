namespace WeekChgkSPBParser.Helpers
{
    internal class GetFromTxtHelper
    {
        /// <summary>
        /// Возвращает весь текст .txt-файла в string
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Текст файла как string</returns>
        public static string GetFromTxt(string path)
        {
            using var sr = new FileInfo(path).OpenText();
            return sr.ReadToEnd();
        }

        /// <summary>
        /// Возвращает весь текст .txt-файла в массив string'ов
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Текст файла как string[]</returns>
        public static string[] GetLinesFromTxt(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}