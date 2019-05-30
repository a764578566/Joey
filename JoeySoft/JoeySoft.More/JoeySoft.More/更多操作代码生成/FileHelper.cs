using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 更错操作代码生成
{
    public static class FileHelper
    {
        /// <summary>
        /// C#按创建时间排序（倒序）
        /// </summary>
        /// <param name="arrFi">待排序数组</param>
        public static void SortAsFileCreationTime(ref FileInfo[] arrFi)
        {
            Array.Sort(arrFi, (x, y) =>
            {
                return y.LastWriteTime.CompareTo(x.LastWriteTime);
            });
        }
    }
}
