using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog4dotnet.api.option;
using Backlog4dotnet.conf;
using Backlog4dotnet.inter.json;

namespace Backlog4dotnet.client
{
    public class BacklogClientImpl : BacklogClientBase , BacklogClient
    {
        public BacklogClientImpl(BacklogConfigure configure) : base(configure)
        {
        }

        public IssueJSONImpl createIssue(CreateIssueParams createIssueParams)
        {
            return factory.createIssue(post(buildEndpoint("issues"), createIssueParams));
        }

        public List<IssueJSONImpl> getIssues(GetIssueParams issueParams)
        {
            return factory.createIssueList(get(buildEndpoint("issues"), issueParams));
        }

        // 課題種別を取得します。課題追加時の必須項目です。
        public List<IssueTypeJSONImpl> getIssueTypes(object projectIdOrKey)
        {
            return factory.createIssueTypeList(get(buildEndpoint("projects/" + projectIdOrKey + "/issueTypes")));
        }

        // 課題の優先度一覧を取得します。課題追加時の必須項目です。
        public List<PriorityJSONImpl> getPriorities()
        {
            return factory.createPriorityList(get(buildEndpoint("priorities")));
        }

        public ProjectJSONImpl getProject(object projectIdOrKey)
        {
            return factory.createProject(get(buildEndpoint("projects/" + projectIdOrKey)));
        }

        public List<ProjectJSONImpl> getProjects()
        {
            return factory.createProjectList(get(buildEndpoint("projects")));
        }
    }
}
