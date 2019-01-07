using Backlog4dotnet.inter.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.api
{
    public interface PriorityMethods
    {
        List<PriorityJSONImpl> getPriorities();
    }
}
