﻿namespace WeekChgkSPBParser.Constants
{
    internal class Paths
    {
        internal const string TxtAnnounce = @"Announcement.txt";
        internal const string TgToken = @"TgToken.txt";
        internal const string AdminIds = @"IDs.txt";
        internal const string LjUrl = @"https://chgk-spb.livejournal.com/2596838.html";

        internal static readonly List<string> TxtPaths = new() { TgToken, AdminIds, TxtAnnounce };
    }
}