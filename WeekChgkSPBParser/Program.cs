using WeekChgkSPBParser.API;

namespace WeekChgkSPBParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Files.СheckExistence())
            {
                Connect connect = new();
                connect.Start();
            }
            Console.ReadLine();
        }
    }
}