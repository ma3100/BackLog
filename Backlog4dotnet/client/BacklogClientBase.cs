using Backlog4dotnet.api.option;
using Backlog4dotnet.conf;
using Backlog4dotnet.http;
using Backlog4dotnet.inter;
using Backlog4dotnet.inter.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.client
{
    public abstract class BacklogClientBase
    {
        protected BacklogHttpClient httpClient;
        protected BacklogConfigure configure;
        protected InternalFactory factory = new InternalFactoryJSONImpl();

        public BacklogClientBase(BacklogConfigure configure)
        {
            this.configure = configure;
            this.httpClient = new BacklogHttpClientImpl();
            configureHttpClient();
        }

        private void configureHttpClient()
        {
            if (this.configure.apiKey != null)
            {
                httpClient.setApiKey(this.configure.apiKey);
            }
        }

        protected String buildEndpoint(String connection)
        {
            StringBuilder url = new StringBuilder()
                    .Append(configure.getRestBaseURL())
                    .Append(connection == null ? "" : "/" + connection);
            return url.ToString();
        }

        protected BacklogHttpResponse get(String endpoint)
        {
            return this.get(endpoint, null, null);
        }

        protected BacklogHttpResponse get(String endpoint, GetParams getParams)
        {
            return this.get(endpoint, getParams, null);
        }

        protected BacklogHttpResponse get(String endpoint, QueryParams queryParams)
        {
            return this.get(endpoint, null, queryParams);
        }

        private BacklogHttpResponse get(string endpoint, GetParams getParams, QueryParams queryParams)
        {
            BacklogHttpResponse ires = httpClient.get(endpoint, getParams, queryParams);
            // リフレッシュトークン未対応
            if (needTokenRefresh(ires))
            {
                //refreshToken();
                ires = httpClient.get(endpoint, getParams, queryParams);
            }
            checkError(ires);
            return ires;
        }

        protected BacklogHttpResponse post(String endpoint) 
        {
        return this.post(endpoint, new List<KeyValuePair<string, string>>());
    }

    protected BacklogHttpResponse post(String endpoint, PostParams postParams) 
    {
        return this.post(endpoint, postParams.getParamList());
    }

    protected BacklogHttpResponse post(String endpoint, List<KeyValuePair<string, string>> parameters) 
    {
        BacklogHttpResponse ires = httpClient.post(endpoint, parameters);
        if (needTokenRefresh(ires)) {
            //refreshToken();
            ires = httpClient.post(endpoint, parameters);
        }
        checkError(ires);
        return ires;
    }

    private void checkError(BacklogHttpResponse ires)
        {
            if (ires.getStatusCode() != 200 &&
                    ires.getStatusCode() != 201 &&
                    ires.getStatusCode() != 202 &&
                    ires.getStatusCode() != 203 &&
                    ires.getStatusCode() != 204)
            {
                throw new Exception("backlog api request failed."+ ires);
            }
        }

        private bool needTokenRefresh(BacklogHttpResponse ires)
        {
            // TODO 
            return false;

            //return (ires.getStatusCode() == 401 ||
            //        ires.getStatusCode() == 0) && // for android bug
            //        configure.getApiKey() == null &&
            //        configure.getAccessToken() != null;
        }
    }
}
