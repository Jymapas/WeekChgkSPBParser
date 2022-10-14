namespace WeekChgkSPBParser.API
{
    internal class GetFromTxtHelper
    {
        public static string GetFromTxt(string path)
        {
            using StreamReader sr = new FileInfo(path).OpenText();
            return sr.ReadToEnd();
        }
    }
}