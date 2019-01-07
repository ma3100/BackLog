using Backlog4dotnet.inter.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.api
{
    public interface ProjectMethods
    {
        List<ProjectJSONImpl> getProjects();
        ProjectJSONImpl getProject(Object projectIdOrKey);

        List<IssueTypeJSONImpl> getIssueTypes(Object projectIdOrKey);


    }
}
