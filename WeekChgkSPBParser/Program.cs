using WeekChgkSPBParser.API;

namespace WeekChgkSPBParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (FilesExist.Check())
            {
                Connect connect = new();
                connect.Start();
            }
            Console.ReadLine();
        }
    }
}