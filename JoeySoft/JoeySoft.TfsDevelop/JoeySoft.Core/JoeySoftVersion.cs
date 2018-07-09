using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeySoft.Core
{
    /// <summary>
    /// 版本信息
    /// </summary>
    public class JoeySoftVersion
    {
        private int _fileMajorPart = -1;
        private int _fileMinorPart = -1;
        private int _filePrivatePart = -1;
        private int _fileBuildPart = -1;

        /// <summary>
        /// 软件名称
        /// </summary>
        public string JoeySoftName { get; set; }

        /// <summary>
        /// 软件版本号 0.0.0.0  第一个0为主版本号 第二个0为次版本号 第三个0内部版本号 第四个0修订版  
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 获取与此文件关联的产品版本号的主要部分
        /// </summary>
        public int FileMajorPart
        {
            get
            {
                if (this._fileMajorPart != -1)
                {
                    return this._fileMajorPart;
                }
                else
                {
                    int.TryParse(Version.Split('.')[0], out this._fileMajorPart);
                }
                return this._fileMajorPart;
            }
        }

        /// <summary>
        /// 获取文件关联产品版本号的次要部分
        /// </summary>
        public int FileMinorPart
        {
            get
            {
                if (this._fileMinorPart != -1)
                {
                    return this._fileMinorPart;
                }
                else
                {
                    int.TryParse(Version.Split('.')[1], out this._fileMinorPart);
                }
                return this._fileMinorPart;
            }
        }

        /// <summary>
        /// 获取该文件关联产品的生成号
        /// </summary>
        public int FileBuildPart
        {
            get
            {
                if (this._fileBuildPart != -1)
                {
                    return this._fileBuildPart;
                }
                else
                {
                    int.TryParse(Version.Split('.')[2], out this._fileBuildPart);
                }
                return this._fileBuildPart;
            }
        }

        /// <summary>
        /// 获取此文件关联产品的专用部件号
        /// </summary>

        public int FilePrivatePart
        {
            get
            {
                if (this._filePrivatePart != -1)
                {
                    return this._filePrivatePart;
                }
                else
                {
                    int.TryParse(Version.Split('.')[3], out this._filePrivatePart);
                }
                return this._filePrivatePart;
            }
        }


    }
}
