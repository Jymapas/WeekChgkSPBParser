using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekChgkSPBParser.API
{
    internal class TxtPost
    {
        internal string Anounce()
        {
            FileInfo file = new(Constants.path);
            using (StreamReader streamReader = file.OpenText())
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
