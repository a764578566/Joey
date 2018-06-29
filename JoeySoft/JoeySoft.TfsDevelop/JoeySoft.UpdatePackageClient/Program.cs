using JoeySoft.UpdatePackageClient.Model;
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
        static BackgroundWorker worker;
        static JoeySoftVersion joeySoftVersion;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string versionAddress = AppConfigHelper.GetAppConfig("VersionAddress");
            Uri uir = new Uri(api + "/" + versionAddress + "/" + joeySofyName);
            string tfsDevelopExePath = AppConfigHelper.GetAppConfig("TfsDevelopExePath");
            joeySoftVersion = new JoeySoftVersion();
            using (HttpClient httpClient = new HttpClient())
            {
                joeySoftVersion = JsonConvert.DeserializeObject<JoeySoftVersion>
                    (httpClient.GetAsync(uir).Result.Content.ReadAsStringAsync().Result);
                httpClient.Dispose();
            }
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JoeySoftTfsTool.exe"));
            string version = myFileVersionInfo.FileVersion;
            if (joeySoftVersion.Version != version)
            {
                //执行exe程序
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += Worker_DoWork;
                worker.RunWorkerAsync();
                Application.Run(new ProgressBar(worker));
            }
            else
            {
                MessageBox.Show("已经是最新版本" + version);
            }
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //解压到
            string temp = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "产品迁移二开工具V" + joeySoftVersion.Version + ".rar";
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }

            string versionAddress = AppConfigHelper.GetAppConfig("PackageAddress");
            Uri uir = new Uri(api + "/" + versionAddress + "/" + fileName);

            worker.ReportProgress(10, "开始更新！");
            //下载
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                client.DownloadFileTaskAsync(uir, fileName).Wait();
            }
            worker.ReportProgress(90, "开始解压！");
            //解压 更新 复制信息
            using (Stream stream = File.OpenRead(fileName))
            {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry())
                {
                    reader.WriteEntryToDirectory(temp, new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
            //删除压缩包
            File.Delete(Path.Combine(temp, fileName));
            worker.ReportProgress(100, "更新完成！");
        }

        static int value = 0;
        static object obj = new object();
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
