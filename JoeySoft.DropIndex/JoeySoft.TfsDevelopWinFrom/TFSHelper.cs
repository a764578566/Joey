using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace JoeySoft.DropIndexWinFrom
{
    public class TFSHelper
    {
        private Workspace ws;

        public TFSHelper()
        {
            ////连接TFS
            string tpcURL = "http://10.5.10.70:8080/tfs";

            //登录服务器
            TfsConfigurationServer tfs = TfsConfigurationServerFactory.GetConfigurationServer(new Uri(tpcURL),
                new UICredentialsProvider());

            //登录服务前，如果没有登录过会弹出提示框登录，登录过会直接跳过
            tfs.EnsureAuthenticated();

            //登录服务器指定tfs项目
            TfsTeamProjectCollection pjc = new TfsTeamProjectCollection(new Uri(tpcURL + "/szzb"), tfs.AuthorizedIdentity.Descriptor);

            VersionControlServer version = pjc.GetService<VersionControlServer>();

            String Path = "$/";
            //获取文件夹目录 ItemSet
            ItemSet its = version.GetItems("$/", RecursionType.OneLevel);

            //获取工作区
            Workspace[] wss = version.QueryWorkspaces(Environment.MachineName, version.AuthenticatedUser, Environment.MachineName);//查询工作区

            ws = wss.FirstOrDefault();
        }

        /// <summary>
        /// 签出编辑
        /// </summary>
        /// <param name="localPath"></param>
        public void Edit(string localPath)
        {
            //编辑
            int pend = ws.PendEdit(localPath);
        }
    }
}
