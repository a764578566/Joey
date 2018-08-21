using JoeySoft.JoeyLog;
using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joey.Git
{
    /// <summary>
    /// git帮助类
    /// </summary>
    public class GitHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public GitHelper()
        {
            RepositoryInformation github = RepositoryInformation.GetRepositoryInformationForPath("D:\\github\\microsoft\\core", gitPath);
            string str = github.Pull();
        }

        /// <summary>
        /// 获取git地址
        /// </summary>
        private string gitPath = System.IO.Path.Combine(EnvironmentVariable, "git.exe");

        /// <summary>
        /// 获取git地址
        /// </summary>
        private static string EnvironmentVariable
        {
            get
            {
                string sPath = System.Environment.GetEnvironmentVariable("Path");
                var result = sPath.Split(';');
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].Contains(@"Git\cmd"))
                    {
                        sPath = result[i];
                    }
                }
                return sPath;
            }
        }

        /// <summary>
        /// git pull
        /// </summary>
        public void Pull()
        {
            Logging.WriteLog(string.Format("环境路径：{0}", gitPath));
            Process p = new Process();
            p.StartInfo.FileName = gitPath;
            p.StartInfo.Arguments = "git pull";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.WorkingDirectory = "D:\\github\\microsoft\\core";
            p.OutputDataReceived += OnOutputDataReceived;
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
        }

        /// <summary>
        /// 获取返回数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e != null && !string.IsNullOrEmpty(e.Data))
            {
                Logging.WriteLog(e.Data);
            }
        }
    }
}
