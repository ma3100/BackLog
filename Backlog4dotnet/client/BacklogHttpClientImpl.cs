using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog4dotnet.api.option;
using Backlog4dotnet.http;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Backlog4dotnet.inter.json;

namespace Backlog4dotnet.client
{
    public class BacklogHttpClientImpl : BacklogHttpClient
    {
        protected static string CONTENT_TYPE = "application/x-www-form-urlencoded; charset=UTF-8";
        protected static string CHARSET = "UTF-8";
        protected static string LINE_FEED = "\r\n";

        protected string apiKey;

        public BacklogHttpResponse get(string endpoint, GetParams getParams, QueryParams queryParams)
        {
            // endpoint は以下を想定
            // {0}/api/v2/projects/{1}まで　後続でこれ追加 ?apiKey={2}
            String url = getUrl(endpoint);
            bool paramExists = (apiKey != null);
            if (getParams != null && getParams.getParamList().Any())
            {
                url += getParamsString(paramExists, getParams);
                paramExists = true;
            }
            if (queryParams != null && queryParams.getParamList().Any())
            {
                url += getParamsString(paramExists, queryParams);
            }

            var urlResponse = openUrlResponse(url, "GET");
            return handleResponse(urlResponse);
        }

        private BacklogHttpResponse handleResponse(Task<HttpResponseMessage> openUrlResponse)
        {
            BacklogHttpResponse response = new BacklogHttpResponseImpl(openUrlResponse.GetAwaiter().GetResult());
            return response;
        }

        private async Task<HttpResponseMessage> openUrlResponse(string url, string methodType, string json = null)
        {
            // これがないとTLS1.2サーバにリクエストを送れない
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            var handler = new HttpClientHandler();
            //handler.UseProxy = false;
            //handler.Credentials = CredentialCache.DefaultNetworkCredentials;
            using (var httpClient = new HttpClient(handler))
            {
                var uri = new Uri(url);
                httpClient.DefaultRequestHeaders.Host = uri.Host;

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage
                {
                    Method = new HttpMethod(methodType),
                    RequestUri = uri,
                };
               if (!string.IsNullOrEmpty(json)) request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return await httpClient.SendAsync(request);
                //var aResponse = httpClient;
                //switch (methodType)
                //{
                //    case "GET":
                //        return await aResponse.GetAsync(uri);
                //    default:
                //        return await aResponse.GetAsync(uri);
                //}
            }

        }

        public string getParamsString(bool paramExists, GetParams getParams)
        {
            StringBuilder sb = new StringBuilder();

            // apikeyのあるなしを判定
            if (paramExists)
                sb.Append("&");
            else
                sb.Append("?");

            sb.Append(string.Join("&", getParams.getParamList().Select(x => x.Key + "=" + x.Value)));
            return sb.ToString();
        }

        private string getUrl(String endpoint)
        {
            if (apiKey != null)
            {
                return endpoint + "?apiKey=" + apiKey;
            }
            else
            {
                return endpoint;
            }
        }

        public void setApiKey(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public BacklogHttpResponse post(string endpoint, List<KeyValuePair<string, string>> postParams)
        {
            String url = getUrl(endpoint);
            var json = "{" + string.Join(",", postParams.Select(x => "\"" +  x.Key + "\"" + ":" + convertValue(x.Value)  )) + "}";
            var urlResponse = openUrlResponse(url, "POST", json);
            JsonConvert.SerializeObject(postParams);
            return handleResponse(urlResponse);
        }

        private string convertValue(string value)
        {
            var outValue = 0;
            if(int.TryParse(value,out outValue))
            {
                return value;
            }
            else
            {
                return "\"" +  value + "\"";
            }
        }
    }
}
