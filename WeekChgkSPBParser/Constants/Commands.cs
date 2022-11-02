namespace WeekChgkSPBParser.Constants
{
    internal record Commands
    {
        internal const string Announcement = "/announcement";
        internal const string AnnouncementToChannel = "/announcementtochannel";
        internal const string AnnouncementFromLj = "/announcementfromlj";
        internal const string AnnouncementFromLjToChannel = "/announcementfromljtochannel";

        internal static readonly List<string> LjCommands = new() { AnnouncementFromLj, AnnouncementFromLjToChannel };
    }
}