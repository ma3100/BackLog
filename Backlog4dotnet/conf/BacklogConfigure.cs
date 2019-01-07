using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.conf
{
    public abstract class BacklogConfigure
    {
        // ユーザに割り当てられるAPI Key
        public string apiKey { get; set; }

        public BacklogConfigure ApiKey(string apiKey)
        {
            this.apiKey = apiKey;
            return this;
        }

        public abstract string  getOAuthAuthorizationURL();

        public abstract string getOAuthAccessTokenURL();

        public abstract string getRestBaseURL();

        public abstract string getWebAppBaseURL();
    }
}
