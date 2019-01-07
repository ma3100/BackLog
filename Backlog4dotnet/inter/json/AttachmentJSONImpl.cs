using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    public class AttachmentJSONImpl : Attachment
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public UserJSONImpl createdUser { get; set; }
        public string created { get; set; }
    }
}
