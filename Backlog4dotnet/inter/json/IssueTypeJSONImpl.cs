using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    public class IssueTypeJSONImpl : IssueType
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long id { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long projectId { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int? displayOrder { get; set; }

    }
}
