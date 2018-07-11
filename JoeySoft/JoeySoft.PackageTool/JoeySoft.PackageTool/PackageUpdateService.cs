using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoeySoft.PackageTool
{
    /// <summary>
    /// 更新包服务
    /// </summary>
    public static class PackageUpdateService
    {
        //更新服务器地址
        private static string api = "http://111.231.83.218/api";
        //版本ActionName
        private static string versionActionName = "Version";
        //包ActionName
        private static string packageActionName = "Package";

        /// <summary>
        /// 检查最新版本号判断是否需要更新
        /// </summary>
        public static List<JoeySoftVersion> GetVersionInfo()
        {
            Uri uir = new Uri(api + "/" + versionActionName);
            List<JoeySoftVersion> joeySoftVersion = new List<JoeySoftVersion>();
            using (HttpClient httpClient = new HttpClient())
            {
                joeySoftVersion = JsonConvert.DeserializeObject<List<JoeySoftVersion>>
                    (httpClient.GetAsync(uir).Result.Content.ReadAsStringAsync().Result);
                httpClient.Dispose();
            }
            return joeySoftVersion;
        }

        /// <summary>
        /// 更新包版本
        /// </summary>
        public static HttpResponseMessage UpdateVersionInfo(PutPackageVersion putPackageVersion)
        {
            Uri uir = new Uri(api + "/" + versionActionName + "/" + putPackageVersion.JoeySoftName);
            HttpResponseMessage httpResponseMessage = null;
            using (HttpClient httpClient = new HttpClient())
            {
                httpResponseMessage = httpClient.PutAsync(uir, new StringContent(JsonConvert.SerializeObject(putPackageVersion), Encoding.UTF8, "application/json-patch+json")).Result;
                httpClient.Dispose();
            }
            return httpResponseMessage;
        }
    }
}
