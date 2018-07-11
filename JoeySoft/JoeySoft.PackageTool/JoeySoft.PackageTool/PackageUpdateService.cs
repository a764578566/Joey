using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Uri uri = new Uri(api + "/" + versionActionName);
            List<JoeySoftVersion> joeySoftVersion = new List<JoeySoftVersion>();
            using (HttpClient httpClient = new HttpClient())
            {
                joeySoftVersion = JsonConvert.DeserializeObject<List<JoeySoftVersion>>
                    (httpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result);
                httpClient.Dispose();
            }
            return joeySoftVersion;
        }

        /// <summary>
        /// 更新包版本
        /// </summary>
        public static HttpResponseMessage UpdateVersionInfo(PutPackageVersion putPackageVersion)
        {
            Uri uri = new Uri(api + "/" + versionActionName + "/" + putPackageVersion.JoeySoftName);
            HttpResponseMessage httpResponseMessage = null;
            using (HttpClient httpClient = new HttpClient())
            {
                httpResponseMessage = httpClient.PutAsync(uri, new StringContent(JsonConvert.SerializeObject(putPackageVersion), Encoding.UTF8, "application/json-patch+json")).Result;
                httpClient.Dispose();
            }
            return httpResponseMessage;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        public static HttpStatusCode UploadPackage(string filePath)
        {
            return UploadRequest(api + "/" + packageActionName, filePath);
        }


        /// <summary>
        /// 上传 参考https://www.cnblogs.com/AndyDai/p/5135294.html
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filePath"></param>
        private static HttpStatusCode UploadRequest(string url, string filePath)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.NotFound;
            // 时间戳，用做boundary
            string timeStamp = DateTime.Now.Ticks.ToString("x");

            //根据uri创建HttpWebRequest对象
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
            httpReq.Method = "POST";
            httpReq.AllowWriteStreamBuffering = false; //对发送的数据不使用缓存
            httpReq.Timeout = 300000;  //设置获得响应的超时时间（300秒）
            httpReq.ContentType = "multipart/form-data; boundary=" + timeStamp;

            //文件
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            //头信息
            string boundary = "--" + timeStamp;
            string dataFormat = boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";filename=\"{1}\"\r\nContent-Type:application/octet-stream\r\n\r\n";
            string header = string.Format(dataFormat, "file", Path.GetFileName(filePath));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(header);

            //结束边界
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + timeStamp + "--\r\n");

            long length = fileStream.Length + postHeaderBytes.Length + boundaryBytes.Length;

            httpReq.ContentLength = length;//请求内容长度

            try
            {
                //每次上传4k
                int bufferLength = 4096;
                byte[] buffer = new byte[bufferLength];

                //已上传的字节数
                long offset = 0;
                int size = binaryReader.Read(buffer, 0, bufferLength);
                Stream postStream = httpReq.GetRequestStream();

                //发送请求头部消息
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

                while (size > 0)
                {
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    size = binaryReader.Read(buffer, 0, bufferLength);
                }

                //添加尾部边界
                postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                postStream.Close();

                //获取服务器端的响应
                using (HttpWebResponse response = (HttpWebResponse)httpReq.GetResponse())
                {
                    httpStatusCode = response.StatusCode;
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fileStream.Close();
                binaryReader.Close();
            }
            return httpStatusCode;
        }
    }
}
