using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JoeySoft.Core
{
    public static class MD5Helper
    {
        /// <summary>
        /// 比较两个文件是否相同
        /// </summary>
        /// <param name="file1Path">文件1</param>
        /// <param name="file2Path">文件2</param>
        /// <returns></returns>
        public static bool CompareFile(string file1Path, string file2Path)
        {
            return GetFileMD5(file1Path) == GetFileMD5(file2Path);
        }

        /// <summary>
        /// 获取文件MD5值
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileMD5(string filePath)
        {
            //文件信息
            FileInfo fi = new FileInfo(filePath);
            string md5str = string.Empty;
            using (FileStream fs = fi.OpenRead())
            {
                //获取MD5信息
                md5str = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(fs));
                fs.Close();
            }
            return md5str;
        }
    }
}
