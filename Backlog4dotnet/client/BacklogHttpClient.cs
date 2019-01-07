using Backlog4dotnet.api.option;
using Backlog4dotnet.http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.client
{
    public interface BacklogHttpClient
    {
        void setApiKey(string apiKey);
        BacklogHttpResponse get(String endpoint, GetParams getParams, QueryParams queryParams);

        BacklogHttpResponse post(String endpoint, List<KeyValuePair<string, string>> postParams);
    }
}
