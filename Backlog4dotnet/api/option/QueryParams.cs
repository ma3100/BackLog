using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.api.option
{
    public class QueryParams : GetParams
    {
        public QueryParams minId(Object minId)
        {
            parameters.Add(new KeyValuePair<string, string>("minId", minId.ToString()));
            return this;
        }

        public QueryParams maxId(Object maxId)
        {
            parameters.Add(new KeyValuePair<string, string>("minId", maxId.ToString()));
            return this;
        }

        public QueryParams count(int count)
        {
            parameters.Add(new KeyValuePair<string, string>("count", count.ToString()));
            return this;
        }

        public QueryParams count(long count)
        {
            parameters.Add(new KeyValuePair<string, string>("count", count.ToString()));
            return this;
        }

        //public QueryParams order(Order order)
        //{
        //    parameters.add(new NameValuePair("order", order.getStrValue()));
        //    return this;
        //}
    }
}
