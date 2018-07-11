using JoeySoft.Core;
using JoeySoft.JoeyLog;
using JoeySoft.TfsDevelopWinFrom.model;
using Newtonsoft.Json;
using SharpCompress.Readers;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;

namespace JoeySoft.TfsDevelopWinFrom
{
    public static class UpdateService
    {
        //更新服务器地址
        private static string api = "http://111.231.83.218/api";
        //版本ActionName
        private static string versionActionName = "Version";
        //包ActionName
        private static string packageActionName = "Package";
        //更新包软件名称
        private static string updateClientJoeySofyName = "UpdateClient";
        //工具软件名称
        private static string tfsDevelopJoeySofyName = "TfsDevelop";

        /// <summary>
        /// 检查最新版本号判断是否需要更新
        /// </summary>
        public static JoeySoftVersion CheckTfsDevelopVersion()
        {
            Uri uir = new Uri(api + "/" + versionActionName + "/" + tfsDevelopJoeySofyName);
            JoeySoftVersion joeySoftVersion = new JoeySoftVersion();
            using (HttpClient httpClient = new HttpClient())
            {
                joeySoftVersion = JsonConvert.DeserializeObject<JoeySoftVersion>
                    (httpClient.GetAsync(uir).Result.Content.ReadAsStringAsync().Result);
                httpClient.Dispose();
            }
            return joeySoftVersion;
        }

        /// <summary>
        /// 获取更新工具版本信息
        /// </summary>
        /// <returns></returns>
        public static FileVersionInfo GetUpdateClientVersion()
        {
            string updateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigClass.UpdateServicePathName,
                 ConfigClass.UpdateServiceExeName);

            if (!File.Exists(updateFilePath))
            {
                return null;
            }
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(updateFilePath);
            return myFileVersionInfo;
        }

        /// <summary>
        /// 检查最新版本号判断是否需要更新
        /// </summary>
        public static JoeySoftVersion CheckUpdateClientVersion()
        {
            Uri uir = new Uri(api + "/" + versionActionName + "/" + updateClientJoeySofyName);
            JoeySoftVersion joeySoftVersion = new JoeySoftVersion();
            using (HttpClient httpClient = new HttpClient())
            {
                joeySoftVersion = JsonConvert.DeserializeObject<JoeySoftVersion>
                    (httpClient.GetAsync(uir).Result.Content.ReadAsStringAsync().Result);
                httpClient.Dispose();
            }
            Logging.WriteLog("开始检查更新工具的最新版本：" + joeySoftVersion.Version);
            return joeySoftVersion;
        }

        /// <summary>
        /// 下载包
        /// </summary>
        public static void DownloadUpdateClient(string version)
        {
            Logging.WriteLog("开始下载更新工具的版本：" + version);
            string updateServicePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigClass.UpdateServicePathName);

            string fileName = "UpdateClientV" + version + ".zip";
            Uri uir = new Uri(api + "/" + packageActionName + "/" + fileName);
            //下载
            using (WebClient client = new WebClient())
            {
                client.DownloadFileTaskAsync(uir, fileName).Wait();
            }
            try
            {
                Logging.WriteLog("开始解压更新工具：" + fileName);
                //解压 更新 复制信息
                using (Stream stream = File.OpenRead(fileName))
                {
                    var reader = ReaderFactory.Open(stream);
                    while (reader.MoveToNextEntry())
                    {
                        reader.WriteEntryToDirectory(updateServicePath, new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.WriteErrorLog(ex);
            }
            //删除压缩包
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            Logging.WriteLog("完成更新工具更新版本：" + version);
        }
    }
}
