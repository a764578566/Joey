using Newtonsoft.Json;
using System;
using System.IO;

namespace JoeySoft.Common
{
    /// <summary>
    /// json帮助类
    /// </summary>
    public static class JsonHelper
    {
        public static T ReadJson<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
        }


        /// <summary>
        /// 将对象写入josn文件
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象</param>
        /// <param name="fileFullName">写入文件全名称</param>
        public static void WriteJson<T>(T t, string fileFullName)
        {
            WriteJson((object)t, fileFullName);
        }

        /// <summary>
        /// 将对象写入josn文件
        /// </summary>
        /// <param name="t">对象</param>
        /// <param name="fileFullName">写入文件全名称</param>
        public static void WriteJson(object t, string fileFullName)
        {
            string json = JsonConvert.SerializeObject(t);

            var directoryName = Path.GetDirectoryName(fileFullName);

            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            if (!File.Exists(fileFullName))
            {
                File.Create(fileFullName);
            }
            using (StreamWriter sw = new StreamWriter(fileFullName))
            {
                sw.WriteLine(json);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
