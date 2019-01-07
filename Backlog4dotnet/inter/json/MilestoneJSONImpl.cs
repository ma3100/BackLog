using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    public class MilestoneJSONImpl : Milestone
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int id { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int projectId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string releaseDueDate { get; set; }
        public bool archived { get; set; }
        public int? displayOrder { get; set; }
    }
}
