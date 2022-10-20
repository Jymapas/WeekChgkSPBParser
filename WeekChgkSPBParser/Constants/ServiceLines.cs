namespace WeekChgkSPBParser.Constants
{
    internal record class ServiceLines
    {

        internal const string TgHead = "Продолжаем вести список синхронов в Санкт-Петербурге.";
        internal const string RegexPattern = @"(?<=(\n|<br\s?/?>))^[<b>][\w\W]+?(?=</p>)";
    }
}