using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.api.option
{
    public abstract class GetParams
    {
        protected List<KeyValuePair<string,string>> parameters = new List<KeyValuePair<string, string>>();
        public List<KeyValuePair<string, string>> getParamList()
        {
            return parameters;
        }
    }
}
