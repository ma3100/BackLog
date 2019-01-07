using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.inter.json
{
    public class StatusJSONImpl : Status
    {
        public enum StatusType
        {
            未対応 = 1,
            処理中,
            処理済み,
            完了,
        }
        public StatusType id { get; set; }
        public string name { get; set; }
    }
}
