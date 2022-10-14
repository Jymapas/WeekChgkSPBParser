namespace WeekChgkSPBParser.API
{
    public class TxtPostReader
    {
        public static string GetAnnounce(string path)
        {
            TgHtmlFormat announcementText = new(GetFromTxtHelper.GetFromTxt(Constants.TxtAnnouncePath));
            return announcementText.Announcement;
        }
    }
}