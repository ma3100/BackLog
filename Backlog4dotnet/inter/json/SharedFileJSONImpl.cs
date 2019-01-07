using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    public class SharedFileJSONImpl : SharedFile
    {
        public int id { get; set; }
        public string type { get; set; }
        public string dir { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public UserJSONImpl createdUser { get; set; }
        public string created { get; set; }
        public UserJSONImpl updatedUser { get; set; }
        public string updated { get; set; }
    }
}
