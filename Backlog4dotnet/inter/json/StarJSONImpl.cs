using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    public class StarJSONImpl : Star
    {
        public int id { get; set; }
        public string comment { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public UserJSONImpl presenter { get; set; }
        public string created { get; set; }
    }
}
