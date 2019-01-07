using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogHelper.Common.Configuration
{
    /// <summary>
    /// Project定期コレクション
    /// </summary>
    public class ProjectConfigCollection : ConfigurationElementCollection
    {
        public ProjectConfigCollection()
        {
            AddElementName = "Project";
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ProjectConfig();
        }        

        protected override object GetElementKey(ConfigurationElement element)
        {
            ProjectConfig item = element as ProjectConfig;
            return item.ProjectName;
        }
    }
}
