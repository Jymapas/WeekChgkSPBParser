using WeekChgkSPBParser.API;

namespace WeekChgkSPBParser.Constants
{
    internal record class Id
    {
        internal const int Chat = -635211124;
        internal const string Channel = "@sapamyJ";
        internal static List<long> Admins
        {
            get
            {
                string allText = GetFromTxtHelper.GetFromTxt(Paths.AdminIds);
                List<long> ids = new();
                foreach (string line in allText.Split(Environment.NewLine))
                {
                    long.TryParse(line, out long id);
                    if (id != 0)
                        ids.Add(id);
                }
                return ids;
            }
        }
    }
}