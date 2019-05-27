using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEdit.WPF.Model
{
    /// <summary>
    /// 系统信息
    /// </summary>
    public class MyApplication : ConfigurationElement
    {
        /// <summary>
        /// 系统编码
        /// </summary>
        [ConfigurationProperty("ApplictionCode", IsRequired = true)]
        public string ApplictionCode
        {
            get { return this["ApplictionCode"].ToString(); }
            set { this["ApplictionCode"] = value; }
        }

        /// <summary>
        /// 系统名称
        /// </summary>
        [ConfigurationProperty("ApplicationName", IsRequired = true)]
        public string ApplicationName
        {
            get { return this["ApplicationName"].ToString(); }
            set { this["ApplicationName"] = value; }
        }
    }
}
