using Backlog4dotnet.conf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.client
{
    public class BacklogClientFactory
    {
        private BacklogConfigure configure;

        public BacklogClientFactory(BacklogConfigure configure)
        {
            this.configure = configure;
        }

        public BacklogClient newClient()
        {
            return new BacklogClientImpl(configure);
        }
    }
}
