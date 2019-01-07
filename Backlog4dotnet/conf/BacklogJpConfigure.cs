using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.conf
{
    public class BacklogJpConfigure : BacklogConfigure
    {
        public string spaceKey { get; set; }

        public BacklogJpConfigure(string spaceKey)
        {
            if (spaceKey == null)
                throw new Exception("スペースIDは必須項目です。https://○.backlog.jp/の○がスペースIDです。");

            this.spaceKey = spaceKey;
        }

        public override string getOAuthAccessTokenURL()
        {
            return "https://" + spaceKey + ".backlog.jp/OAuth2AccessRequest.action";
        }

        public override string getOAuthAuthorizationURL()
        {
            return "https://" + spaceKey + ".backlog.jp/api/v2/oauth2/token";
        }

        public override string getRestBaseURL()
        {
            return "https://" + spaceKey + ".backlog.jp/api/v2";
        }

        public override string getWebAppBaseURL()
        {
            return "https://" + spaceKey + ".backlog.jp";
        }
    }
}
