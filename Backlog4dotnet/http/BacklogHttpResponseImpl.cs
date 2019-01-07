using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.http
{
    public class BacklogHttpResponseImpl : BacklogHttpResponse
    {
        protected Stream inputStream;
        protected String responseAsString = null;
        private HttpResponseMessage httpResponseMessage;
        protected int statusCode;


        public BacklogHttpResponseImpl(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
            this.statusCode = (int)httpResponseMessage.StatusCode;
        }

        public Stream asInputStream()
        {
            throw new NotImplementedException();
        }

        public string asString()
        {
            // 文字列にして結果を返却
            return httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public string getFileNameFromContentDisposition()
        {
            throw new NotImplementedException();
        }

        public int getStatusCode()
        {
            return statusCode;
        }

    }
}
