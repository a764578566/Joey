using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeySoft.UpdatePackageClient.Model
{
    /// <summary>
    /// 版本信息
    /// </summary>
    public class JoeySoftVersion
    {
        /// <summary>
        /// 软件名称
        /// </summary>
        public string JoeySoftName { get; set; }

        /// <summary>
        /// 软件版本号 0.0.0.0  第一个0为主版本号 第二个0为次版本号 第三个0内部版本号 第四个0修订版  
        /// </summary>
        public string Version { get; set; }
    }
}
