using WeekChgkSPBParser.API;

namespace WeekChgkSPBParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Connect connect = new();
            connect.Start();
        }
    }
}