using WeekChgkSPBParser.API;

namespace WeekChgkSPBParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Exist.Check())
            {
                Connect connect = new();
                connect.Start();
            }
            Console.ReadLine();
        }
    }
}