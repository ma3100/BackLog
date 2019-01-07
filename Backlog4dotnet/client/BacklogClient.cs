using Backlog4dotnet.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.client
{
    public interface BacklogClient : ProjectMethods, IssueMethods, PriorityMethods
    {
    }
}
