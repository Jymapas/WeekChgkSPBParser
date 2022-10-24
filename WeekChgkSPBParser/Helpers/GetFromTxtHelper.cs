namespace WeekChgkSPBParser.Helpers
{
    internal class GetFromTxtHelper
    {
        /// <summary>
        /// Возвращает весь текст .txt-файла в string
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public static string GetFromTxt(string path)
        {
            using StreamReader sr = new FileInfo(path).OpenText();
            return sr.ReadToEnd();
        }
    }
}