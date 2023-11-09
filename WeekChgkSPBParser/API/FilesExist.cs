using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.API
{
    public class Files
    {
        /// <summary>
        /// Проверка наличия файлов "Announcement.txt", "TgToken.txt" и "IDs.txt"
        /// </summary>
        /// <returns>true — если все файлы есть в каталоге,
        /// false — в ином случае</returns>
        public static bool СheckExistence()
        {
            var missingFiles = Paths.TxtPaths.Where(file => !File.Exists(file));
            foreach (var file in missingFiles)
                Console.WriteLine($"\"{file}\" does not exist!");
            return !missingFiles.Any();
        }
    }
}