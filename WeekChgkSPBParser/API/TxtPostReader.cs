using WeekChgkSPBParser.Helpers;

namespace WeekChgkSPBParser.API
{
    public class TxtPostReader
    {
        public static string GetAnnounce(string path)
        {
            var txt = GetFromTxtHelper.GetFromTxt(path);
            Announcement announcement = new(txt);
            return announcement.Text;
        }
    }
}