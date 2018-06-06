using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JoeySofy.TFS
{
    public class TFSHelper
    {

        private Workspace ws;

        private string rootPath = "$/";

        private WorkingFolder wf;

        private VersionControlServer version;

        private Dictionary<string, ItemSet> dic = new Dictionary<string, ItemSet>();


        /// <summary>
        /// Tfs初始化
        /// </summary>
        /// <param name="vsPath"></param>
        /// <param name="fileName"></param>
        public TFSHelper(string vsPath, string fileName)
        {
            //读取VS中的tfs地址
            string tpcURL = GetTfsUrl(vsPath, fileName);

            //登录服务器指定tfs项目
            TfsTeamProjectCollection pjc = new TfsTeamProjectCollection(new Uri(tpcURL));

            //登录服务前，如果没有登录过会弹出提示框登录，登录过会直接跳过
            pjc.EnsureAuthenticated();

            version = pjc.GetService<VersionControlServer>();

            //获取工作区
            Workspace[] wss = version.QueryWorkspaces(Environment.MachineName, version.AuthenticatedUser,
                Environment.MachineName); //查询工作区

            ws = wss.FirstOrDefault();

            if (ws.Folders.Count() > 0)
            {
                wf = ws.Folders[0];
            }
        }

        /// <summary>
        /// 读取VS中的tfs地址
        /// </summary>
        /// <param name="vsPath">vs所在地址</param>
        /// <param name="fileName">解决方案名称</param>
        private string GetTfsUrl(string vsPath, string fileName)
        {
            string filePath = Path.Combine(vsPath, fileName);
            if (!File.Exists(filePath))
            {
                throw new Exception("请选择正确的产品地址或解决方案名称！");
            }

            //解决方案数据
            string slnString = File.ReadAllText(filePath);

            string regex = @"SccTeamFoundationServer = (.+)\r";

            Match match = Regex.Match(slnString, regex, RegexOptions.IgnoreCase);

            if (match.Groups.Count > 1)
            {
                return match.Groups[1].Value;
            }
            throw new Exception("请确定解决方案已经关联服务的TFS！");
        }

        /// <summary>
        /// 签出编辑，可能是新增，可能是编辑
        /// </summary>
        /// <param name="localPath"></param>
        public void CheckOut(string localPath)
        {
            //获取添加服务地址
            string serverPath = localPath.Replace(wf.LocalItem, wf.ServerItem).Replace('\\', '/').Replace("//", "/");

            //获取文件目录
            string dir = Path.GetDirectoryName(serverPath);

            if (!dic.ContainsKey(dir))
            {
                ItemSet its = version.GetItems(dir, RecursionType.OneLevel);
                dic.Add(dir, its);
            }
            bool isExist = false;
            foreach (var item in dic[dir].Items)
            {
                if (item.ServerItem == serverPath)
                {
                    isExist = true;
                    break;
                }
            }
            if (isExist)
            {
                Edit(localPath);
            }
            else
            {
                Add(localPath);
            }
        }

        /// <summary>
        /// 签出编辑
        /// </summary>
        /// <param name="localPath"></param>
        private void Edit(string localPath)
        {
            //编辑
            int pend = ws.PendEdit(localPath);
        }

        /// <summary>
        /// 签出编辑
        /// </summary>
        /// <param name="localPath"></param>
        private void Add(string localPath)
        {
            //获取添加服务地址
            string serverPath = localPath.Replace(wf.LocalItem, wf.ServerItem).Replace('\\', '/').Replace("//", "/");

            ws.Map(serverPath, localPath);
            //编辑
            int pend = ws.PendAdd(localPath);
        }
    }
}
