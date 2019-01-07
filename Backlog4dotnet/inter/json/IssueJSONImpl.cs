using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    public class IssueJSONImpl : Issue
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int id { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int projectId { get; set; }
        public string issueKey { get; set; }
        public int? keyId { get; set; }
        public IssueTypeJSONImpl issueType { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public ResolutionJSONImpl resolution { get; set; }
        public PriorityJSONImpl priority { get; set; }
        public StatusJSONImpl status { get; set; }
        public UserJSONImpl assignee { get; set; }
        public List<CategoryJSONImpl> category { get; set; }
        public List<MilestoneJSONImpl> versions { get; set; }
        public List<MilestoneJSONImpl> milestone { get; set; }
        public string startDate { get; set; }
        public string dueDate { get; set; }
        public double? estimatedHours { get; set; }
        public double? actualHours { get; set; }
        public int? parentIssueId { get; set; }
        public UserJSONImpl createdUser { get; set; }
        public string created { get; set; }
        public UserJSONImpl updatedUser { get; set; }
        public string updated { get; set; }
        public List<CustomFieldJSONImpl> customFields { get; set; }
        public List<AttachmentJSONImpl> attachments { get; set; }
        public List<SharedFileJSONImpl> sharedFiles { get; set; }
        public List<StarJSONImpl> stars { get; set; }

        //POST用
        public int? issueTypeId { get; set; }
        public List<int> categoryId { get; set; }
        public List<int> versionId { get; set; }
        public List<int> milestoneId { get; set; }
        public int? priorityId { get; set; }
        public int? assigneeId { get; set; }
        public List<int> notifiedUserId { get; set; }
        public List<int> attachmentId { get; set; }
        public string comment { get; set; }
    }
}
