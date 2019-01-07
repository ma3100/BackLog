using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog4dotnet.http;
using Newtonsoft.Json;

namespace Backlog4dotnet.inter.json
{
    public class InternalFactoryJSONImpl : InternalFactory
    {
        public ProjectJSONImpl createProject(BacklogHttpResponse res)
        {
            return createResponseObject(res.asString(), new ProjectJSONImpl().GetType());
        }

        public List<ProjectJSONImpl> createProjectList(BacklogHttpResponse backlogHttpResponse)
        {
            return createResponseObject(backlogHttpResponse.asString(), new List<ProjectJSONImpl>().GetType());
        }

        public List<IssueJSONImpl> createIssueList(BacklogHttpResponse res)
        {
            return createResponseObject(res.asString(), new List<IssueJSONImpl>().GetType());
        }

        // issue関連の結果文字列生成
        public IssueJSONImpl createIssue(BacklogHttpResponse res)
        {
            return createResponseObject(res.asString(), new IssueJSONImpl().GetType());
        }
        // 課題種別の一覧を取得する
        public List<IssueTypeJSONImpl> createIssueTypeList(BacklogHttpResponse res)
        {
            return createResponseObject(res.asString(), new List<IssueTypeJSONImpl>().GetType());
        }

        // 優先度一覧を取得
        public List<PriorityJSONImpl> createPriorityList(BacklogHttpResponse res)
        {
            return createResponseObject(res.asString(), new List<PriorityJSONImpl>().GetType());
        }


        // 汎用的に利用するデシリアライズオブジェクトです。
        private dynamic createResponseObject(string responseString, Type type)
        {
            return JsonConvert.DeserializeObject(responseString, type);
        }

    }
}
