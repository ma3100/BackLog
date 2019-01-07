using Backlog4dotnet.http;
using Backlog4dotnet.inter.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter
{
    public interface InternalFactory
    {
        ProjectJSONImpl createProject(BacklogHttpResponse res);
        List<ProjectJSONImpl> createProjectList(BacklogHttpResponse backlogHttpResponse);
        List<IssueJSONImpl> createIssueList(BacklogHttpResponse res);

        IssueJSONImpl createIssue(BacklogHttpResponse res);

        List<IssueTypeJSONImpl> createIssueTypeList(BacklogHttpResponse res);

        List<PriorityJSONImpl> createPriorityList(BacklogHttpResponse res);
    }
}
