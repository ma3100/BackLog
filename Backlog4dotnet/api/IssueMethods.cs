using Backlog4dotnet.api.option;
using Backlog4dotnet.inter.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.api
{
    public interface IssueMethods
    {
        List<IssueJSONImpl> getIssues(GetIssueParams issueParams) ;

        IssueJSONImpl createIssue(CreateIssueParams createIssueParams) ;
    }
}
