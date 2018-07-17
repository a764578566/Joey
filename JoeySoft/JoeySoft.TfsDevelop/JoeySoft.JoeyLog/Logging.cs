using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeySoft.JoeyLog
{
    /// <summary>
    /// 保存日志
    /// </summary>
    public static class Logging
    {
        /// <summary>
        /// 日志文件名
        /// </summary>
        private static string logFileName = "_log.txt";

        /// <summary>
        /// 错误日志文件名
        /// </summary>
        private static string errorLogFileName = "_errorLog.txt";

        #region 日志分类
        /// <summary>
        /// 保存普通日志
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLog(params string[] message)
        {
            WriteLog(string.Join("", message));
        }
        /// <summary>
        /// 保存普通日志
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLog(string message)
        {
            string logContent = string.Format("[{0}] =>{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + logFileName;
            WriteFile(fileName, logContent);
        }

        /// <summary>
        /// 保存错误信息日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteErrorLog(Exception ex)
        {
            string logContent = string.Format("[{0}]错误发生在：{1}，\r\n 内容信息：{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.Source, ex.Message);
            logContent += string.Format("\r\n [{0}] 跟踪：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.StackTrace);
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + errorLogFileName;
            WriteFile(fileName, logContent);
        }
        #endregion

        #region 通用操作
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="logContent">内容信息</param>
        private static void WriteFile(string filename, string logContent)
        {
            string logFilePath = Path.Combine(Environment.CurrentDirectory, "Log", filename.Trim());
            //文件不存在生成文件
            string logDirectoryName = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectoryName))
            {
                Directory.CreateDirectory(logDirectoryName);
            }
            if (!File.Exists(logFilePath))
            {
                using (StreamWriter sw = new StreamWriter(File.Create(logFilePath)))
                {
                    sw.WriteLine(logContent);
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine(logContent);
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        #endregion
    }
}
