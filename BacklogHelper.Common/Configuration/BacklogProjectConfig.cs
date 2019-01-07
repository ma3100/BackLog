using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogHelper.Common.Configuration
{
    public class BacklogProjectConfig : ConfigurationSection
    {
        private static readonly BacklogProjectConfig singleton;

        /// <summary>
        /// 静的コンストラクタ
        /// </summary>
        static BacklogProjectConfig()
        {
            singleton = (BacklogProjectConfig)ConfigurationManager.GetSection("BacklogProjectConfig");
            singleton.initial();
        }

        private Dictionary<string, ProjectConfig> projectMap;

        private void initial()
        {
            projectMap = new Dictionary<string, ProjectConfig>();

            foreach (ProjectConfig item in Projects)
            {
                projectMap.Add(item.ProjectName, item);
            }
        }

        /// <summary>
        /// インスタンス取得
        /// </summary>
        public static BacklogProjectConfig Instance
        {
            get
            {
                if (singleton == null)
                {
                    throw new ApplicationException("構成情報[BacklogPloject]がありません。");
                }
                return singleton;
            }
        }

        [ConfigurationProperty("Projects", IsRequired = true) ]
        public ProjectConfigCollection Projects
        {
            get { return (ProjectConfigCollection)this["Projects"]; }
        }

    }
}
