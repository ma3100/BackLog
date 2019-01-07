using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    public class UserJSONImpl : User
    {
        public int id { get; set; }
        public object userId { get; set; }
        public string name { get; set; }
        public int roleType { get; set; }
        public object lang { get; set; }
        public object mailAddress { get; set; }
    }
}
