using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    public class CustomFieldJSONImpl : CustomField
    {
        public enum fieldType
        {
            文字列 = 1,
            文章,
            数値,
            日付,
            単一リスト,
            複数リスト,
            チェックボックス,
            ラジオ,
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int id { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int typeId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool? required { get; set; }
        public List<int> applicableIssueTypes { get; set; }
        public bool? allowAddItem { get; set; }
        public List<Item> items { get; set; }
        public object value { get; set; }

        //POST用
        public string setValue { get; set; }

        public class Item
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int id { get; set; }
            public string name { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int displayOrder { get; set; }
        }

    }
}
