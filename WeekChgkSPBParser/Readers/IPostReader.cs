namespace WeekChgkSPBParser.Readers
{
    internal interface IPostReader
    {
        /// <summary>
        /// Интерфес, который наследуют ридеры постов.
        /// </summary>
        /// <returns>Текст анонса в формате ТГ-поста</returns>
        public string GetAnnounce();
    }
}
