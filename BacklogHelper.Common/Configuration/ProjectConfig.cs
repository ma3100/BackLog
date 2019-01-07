using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogHelper.Common.Configuration
{
    public class ProjectConfig : ConfigurationElement
    {
        /// <summary>
        /// Project名
        /// </summary>
        [ConfigurationProperty("Name", IsRequired = true)]
        public string ProjectName
        {
            get { return (string)this["Name"]; }
            set { this["Name"] = value; }
        }

        /// <summary>
        /// ProjectID
        /// </summary>
        [ConfigurationProperty("ID", IsRequired = true)]
        public string ProjectID
        {
            get { return (string)this["ID"]; }
            set { this["ID"] = value; }
        }

    }
}
