using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeySoft.Core
{
    /// <summary>
    /// 版本对比
    /// </summary>
    public static class VersionHelper
    {
        /// <summary>
        /// 对比版本信息
        /// </summary>
        /// <param name="myFileVersionInfo">本地文件版本</param>
        /// <param name="joeySoftVersion">服务文件版本</param>
        /// <returns></returns>
        public static bool CompareVersion(FileVersionInfo myFileVersionInfo, JoeySoftVersion joeySoftVersion)
        {
            string version = myFileVersionInfo.FileVersion;
            if (myFileVersionInfo.FileMajorPart > joeySoftVersion.FileMajorPart)
            {
                return false;
            }
            if (myFileVersionInfo.FileMinorPart > joeySoftVersion.FileMinorPart)
            {
                return false;
            }
            if (myFileVersionInfo.FileBuildPart > joeySoftVersion.FileBuildPart)
            {
                return false;
            }
            if (myFileVersionInfo.FilePrivatePart >= joeySoftVersion.FilePrivatePart)
            {
                return false;
            }
            return true;
        }
    }
}
