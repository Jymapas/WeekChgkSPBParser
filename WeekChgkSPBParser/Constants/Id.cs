using WeekChgkSPBParser.API;

namespace WeekChgkSPBParser.Constants
{
    internal record class Id
    {
        internal const int Chat = -635211124;
        internal const string Channel = "@sapamyJ";
        private static List<int> Admins
        {
            get
            {
                string allText = GetFromTxtHelper.GetFromTxt(Paths.AdminIds);
                foreach (string line in allText.Split(Environment.NewLine))
                {
                    int.TryParse(line, out int id);
                    if (id != 0)
                        Admins.Add(id);
                }
                return Admins;
            }
        }
    }
}