using JoeySoft.Core;
using JoeySoft.JoeyLog;
using Newtonsoft.Json;
using SharpCompress.Readers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace JoeySoft.UpdatePackageClient
{
    static class Program
    {
        static string api = AppConfigHelper.GetAppConfig("UpdateServiceAddress");
        static string joeySofyName = AppConfigHelper.GetAppConfig("JoeySofyName");
        static string versionAddress = "Version";
        static string packageAddress = "Package";
        static BackgroundWorker worker;
        static JoeySoftVersion joeySoftVersion;
        static string joeySoftTfsToolPath;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Uri uir = new Uri(api + "/" + versionAddress + "/" + joeySofyName);
            joeySoftVersion = new JoeySoftVersion();
            using (HttpClient httpClient = new HttpClient())
            {
                joeySoftVersion = JsonConvert.DeserializeObject<JoeySoftVersion>
                    (httpClient.GetAsync(uir).Result.Content.ReadAsStringAsync().Result);
                httpClient.Dispose();
            }
            Logging.WriteLog("获取服务器最新版本：" + joeySoftVersion.Version);
            joeySoftTfsToolPath = Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory));
            string exeFileName = Path.Combine(joeySoftTfsToolPath, "JoeySoftTfsTool.exe");
            Logging.WriteLog("读取exe：" + exeFileName);
            if (!File.Exists(exeFileName))
            {
                RunWork();
            }
            else
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(exeFileName);
                if (VersionHelper.CompareVersion(myFileVersionInfo, joeySoftVersion) == false)
                {
                    MessageBox.Show("已经是最新版本" + myFileVersionInfo.FileVersion);
                    return;
                }
                if (joeySoftVersion.Version != myFileVersionInfo.FileVersion)
                {
                    RunWork();
                }
            }
        }

        private static void RunWork()
        {
            Logging.WriteLog("更新版本为：" + joeySoftVersion.Version);
            //执行exe程序
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
            Application.Run(new ProgressBar(worker));
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //解压到
            string temp = joeySoftTfsToolPath;
            string fileName = "产品迁移二开工具V" + joeySoftVersion.Version + ".zip";
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }

            Uri uir = new Uri(api + "/" + packageAddress + "/" + fileName);

            worker.ReportProgress(10, "开始更新！");
            //下载
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                client.DownloadFileTaskAsync(uir, fileName).Wait();
            }
            worker.ReportProgress(90, "开始解压！");
            try
            {
                //解压 更新 复制信息
                using (Stream stream = File.OpenRead(fileName))
                {
                    var reader = ReaderFactory.Open(stream);
                    while (reader.MoveToNextEntry())
                    {
                        if (reader.Entry.IsDirectory == false)
                        {
                            Logging.WriteLog("复制文件：" + reader.Entry.Key);
                        }
                        reader.WriteEntryToDirectory(temp, new ExtractionOptions()
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
            string zipFileName = Path.Combine(joeySoftTfsToolPath, fileName);
            if (File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }
            else
            {
                zipFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                File.Delete(zipFileName);
            }

            Logging.WriteLog("删除压缩包：" + zipFileName);
            worker.ReportProgress(100, "更新完成！");
        }

        private static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            worker.ReportProgress(e.ProgressPercentage / 10 * 8 + 10, string.Format("当前接收到{0}字节，文件大小总共{1}字节", e.BytesReceived, e.TotalBytesToReceive));
        }

        private static void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("文件下载被取消", "提示", MessageBoxButtons.OKCancel);
            }
        }
    }
}
