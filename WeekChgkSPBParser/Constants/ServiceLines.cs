namespace WeekChgkSPBParser.Constants
{
    internal record class ServiceLines
    {
        internal const string TgHead = "Продолжаем вести список синхронов в Санкт-Петербурге.";
        internal const string RegexPattern = @"(?<=(\n|<br\s?/?>))^[<b>][\w\W]+?(?=</p>)";
        internal const string CutSourcePattern = @"(?<=<article.*b\-singlepost\-body.*>)[\w\W]*?(?=<\/article>)";
        internal const string WarningMessage = "Постить анонсы могут только админы.\nОбратитесь к @FA72t или к @Jymapas.";
        internal const string UnknownСommand = "Неизвестная команда.";
        internal const string EmptyAnnouncementWarning = "Не удалось получить текст анонса!";
    }
}