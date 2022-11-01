namespace WeekChgkSPBParser.Constants
{
    internal record Patterns
    {
        internal const string CutAnnouncement = @"(?<=(\n|<br\s?/?>))^[<b>][\w\W]+?(?=</p>)";
        internal const string CutSource = @"(?<=<article.*b\-singlepost\-body.*>)[\w\W]*?(?=<\/article>)";
        internal const string СutDate = @"(?<=<b>)[\w\W]+?(?=</b>)";
    }
}