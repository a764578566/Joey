using JoeySoft.Core;
using JoeySoft.UpdatePackageClient.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoeySoft.UpdatePackageClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string api = AppConfigHelper.GetAppConfig("UpdateServiceAddress");
            string getVersion = AppConfigHelper.GetAppConfig("GetVersionAddress");
            string joeySofyName = AppConfigHelper.GetAppConfig("JoeySofyName");
            string tfsDevelopExePath = AppConfigHelper.GetAppConfig("TfsDevelopExePath");
            JoeySoftVersion joeySoftVersion = new JoeySoftVersion();
            using (HttpClient httpClient = new HttpClient())
            {
                joeySoftVersion = JsonConvert.DeserializeObject<JoeySoftVersion>
                    (httpClient.GetAsync(new Uri(api + "/" + getVersion + "/" + joeySofyName)).Result.Content.ReadAsStringAsync().Result);
                httpClient.Dispose();
            }
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(tfsDevelopExePath, "JoeySoftTfsTool.exe"));
            string version = myFileVersionInfo.FileVersion;
            if (joeySoftVersion.Version == version)
            {
                //执行exe程序

            }
            //执行更新程序
        }
    }
}
