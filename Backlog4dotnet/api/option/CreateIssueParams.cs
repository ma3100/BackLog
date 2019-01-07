using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.api.option
{
    public class CreateIssueParams : PostParams
    {
        public CreateIssueParams(Object projectId, String summary, Object issueTypeId, Object priority)
        {
            parameters.Add(new KeyValuePair<string, string>("projectId", projectId.ToString()));
            parameters.Add(new KeyValuePair<string, string>("summary", summary));
            parameters.Add(new KeyValuePair<string, string>("issueTypeId", issueTypeId.ToString()));
            parameters.Add(new KeyValuePair<string, string>("priorityId", priority.ToString()));
        }

        public void setParam(string key,string value)
        {
            parameters.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}
