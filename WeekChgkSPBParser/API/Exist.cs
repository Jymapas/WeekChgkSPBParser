using WeekChgkSPBParser.Constants;

namespace WeekChgkSPBParser.API
{
    public class Exist
    {
        private static bool _exist = true;

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