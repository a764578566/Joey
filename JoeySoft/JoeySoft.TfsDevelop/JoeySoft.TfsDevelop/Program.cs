using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.VersionControl.Client;
using System.IO;
using System.Text.RegularExpressions;
using JoeySoft.Core;
using JoeySofy.TFS;

namespace JoeySoft.TfsDevelop
{
    class Program
    {
        static void Main(string[] args)
        {
            string sln =
                File.ReadAllText(
                    "E:\\mysoft\\tfs_new\\10.5.10.70\\星河二开项目\\总部星河\\明源云ERPv1.0SP5星河孵化\\源代码\\分支1\\材料供应链二开整体解决方案.sln");

            string regex = @"SccTeamFoundationServer = (.+)\r";

            var math2 = Regex.Matches(sln, regex, RegexOptions.IgnoreCase);

            ////连接TFS
            string tpcURL = "http://10.5.10.70:8080/tfs";

            //登录服务器
            TfsConfigurationServer tfs = TfsConfigurationServerFactory.GetConfigurationServer(new Uri(tpcURL),
                new UICredentialsProvider());

            //登录服务前，如果没有登录过会弹出提示框登录，登录过会直接跳过
            tfs.EnsureAuthenticated();

            #region 隐藏
            ////获取tfs服务器上所有项目
            //CatalogNode configurationServerNode = tfs.CatalogNode;

            //ReadOnlyCollection<CatalogNode> tpcNodes = configurationServerNode.QueryChildren(
            //      new Guid[] { CatalogResourceTypes.ProjectCollection },
            //      false,
            //      CatalogQueryOptions.None);

            //List<TfsTeamProjectCollection> lst = new List<TfsTeamProjectCollection>();

            ////遍历每一个TeamProjectCollection 节点
            //foreach (CatalogNode tpcNode in tpcNodes)
            //{
            //    //获取 当前 team project collection 名称.
            //    String displayName = tpcNode.Resource.DisplayName;

            //    // 获得 当前 team project collection 描述.
            //    String description = tpcNode.Resource.Description;

            //    //获取当前 team project collection 的描述.
            //    ServiceDefinition tpcServiceDefinition = tpcNode.Resource.ServiceReferences["Location"];
            //    ILocationService configLocationService = tfs.GetService<ILocationService>();
            //    Uri tpcUri = new Uri(configLocationService.LocationForCurrentConnection(tpcServiceDefinition));

            //    // 真正的连接到team project collection
            //    TfsTeamProjectCollection tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(tpcUri);
            //    lst.Add(tpc);
            //}
            #endregion

            //获取tfs权限
            TeamFoundationIdentity tfi;
            tfs.GetAuthenticatedIdentity(out tfi);

            //登录服务器指定tfs项目
            TfsTeamProjectCollection pjc = new TfsTeamProjectCollection(new Uri(tpcURL + "/szzb"), tfi.Descriptor);
            VersionControlServer version = pjc.GetService<VersionControlServer>();

            //获取文件夹目录 ItemSet
            //ItemSet its = version.GetItems("$/", RecursionType.OneLevel);

            //获取工作区
            Workspace[] wss = version.QueryWorkspaces(Environment.MachineName, version.AuthenticatedUser, Environment.MachineName);//查询工作区

            Workspace ws = wss.FirstOrDefault();

            #region 获取最新版本信息
            ItemSet itemSet = version.GetItems("$\\总部星河\\明源云ERPv1.0SP5星河孵化\\源代码\\分支1\\00-ERP站点\\Clgyl\\OrderMng\\M02210303", RecursionType.Full);

            string filename =
                @"E:\mysoft\tfs_new\10.5.10.70\星河二开项目\总部星河\明源云ERPv1.0SP5星河孵化\源代码\分支1\00-ERP站点\Clgyl\OrderMng\M02210303\ApplyEdit.js";

            //foreach (var item in itemSet.Items)
            //{
            //    if (item.ItemType == ItemType.File)
            //    {
            //        if (Path.GetFileName(item.ServerItem) == Path.GetFileName(filename))
            //        {
            //            item.DownloadFile(filename);
            //        }
            //    }
            //}
            #endregion

            #region TFS获取最新版本

            TFSHelper tfsHelper = new TFSHelper("E:\\mysoft\\tfs_new\\10.5.10.70\\星河二开项目\\总部星河\\明源云ERPv1.0SP5星河孵化\\源代码\\分支1", "材料供应链二开整体解决方案.sln");

            ItemSet its = version.GetItems("$/总部星河/明源云ERPv1.0SP5星河孵化/源代码/分支1/00-ERP站点/Clgyl/OrderMng/M02210303", RecursionType.Full);

            tfsHelper.GetLatest("E:\\mysoft\\tfs_new\\10.5.10.70\\星河二开项目\\总部星河\\明源云ERPv1.0SP5星河孵化\\源代码\\分支1\\00-ERP站点\\Clgyl\\OrderMng\\M02210303\\ApplyMng.js");

            #endregion

            //添加Item
            //int pend = ws.PendAdd(localPath);

            //删除Item
            //int pend = ws.PendDelete(localPath);

            //编辑
            //int pend = wss.FirstOrDefault().PendEdit();

            //签入
            //ItemSpec[] itemSpecs = new ItemSpec[1];
            //itemSpecs[0] = new ItemSpec(localDir, RecursionType.Full);
            //WorkspaceCheckInParameters wscip = new WorkspaceCheckInParameters(itemSpecs, "注释内容");
            //int changeSetId = ws.CheckIn(wscip);//如果签入失败changeSetId==-1；反之，返回变更集，大于0的整数
        }
    }
}
