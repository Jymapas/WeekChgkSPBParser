using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.API
{
    public class Exist
    {
        private static bool _exist = true;

        /// <summary>
        /// Проверка наличия файлов "Announcement.txt", "TgToken.txt" и "IDs.txt"
        /// </summary>
        /// <returns>true — если все файлы есть в каталоге,
        /// false — в ином случае</returns>
        public static bool Check()
        {
            foreach (var file in Paths.TxtPaths.Where(file => !File.Exists(file)))
            {
                Console.WriteLine($"\"{file}\" does not exist!");
                _exist = false;
            }

            return _exist;
        }
    }
}