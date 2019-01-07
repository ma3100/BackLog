using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    [JsonObject("Project")]
    public class ProjectJSONImpl : Project
    {
        public int id { get; set; }
        public string projectKey { get; set; }
        public string name { get; set; }
        public bool chartEnabled { get; set; }
        public bool subtaskingEnabled { get; set; }
        public bool projectLeaderCanEditProjectLeader { get; set; }
        public string textFormattingRule { get; set; }
        public bool archived { get; set; }

        public bool isArchived()
        {
            throw new NotImplementedException();
        }

        public bool isChartEnabled()
        {
            throw new NotImplementedException();
        }

        public bool isSubtaskingEnabled()
        {
            throw new NotImplementedException();
        }
    }
}
