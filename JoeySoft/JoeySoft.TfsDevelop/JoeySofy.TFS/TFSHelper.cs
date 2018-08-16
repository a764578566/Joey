using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JoeySoft.TFS
{
    public class TFSHelper
    {

        private Workspace ws;

        private WorkingFolder wf;

        private VersionControlServer version;

        private TfsTeamProjectCollection pjc;

        private string vsPath;

        private Dictionary<string, ItemSet> dic = new Dictionary<string, ItemSet>();

        public int UpdateNumber { get; private set; } = 0;

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
            pjc = new TfsTeamProjectCollection(new Uri(tpcURL));

            //登录服务前，如果没有登录过会弹出提示框登录，登录过会直接跳过
            pjc.EnsureAuthenticated();

            version = pjc.GetService<VersionControlServer>();

            this.vsPath = vsPath;

            //获取工作区
            wf = GetWorkspace(vsPath);
        }

        /// <summary>
        /// 获取工作区
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private WorkingFolder GetWorkspace(string vsPath)
        {
            WorkingFolder workingFolder = null;
            //获取工作区
            Workspace[] workspaces = version.QueryWorkspaces(null, version.AuthenticatedUser,
                    Environment.MachineName); //查询工作区

            foreach (var workspace in workspaces)
            {
                if (workspace.Folders.Count() > 0)
                {
                    foreach (var folder in workspace.Folders)
                    {
                        if (vsPath.IndexOf(folder.LocalItem) == 0)
                        {
                            ws = workspace;
                            workingFolder = folder;
                            break;
                        }
                    }
                }
                else
                {
                    throw new Exception("请确认解决方案连接了TFS！");
                }
            }
            if (workingFolder == null || ws == null)
            {
                throw new Exception("请确认TFS工作区的正确性！");
            }
            return workingFolder;
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
                throw new Exception("请选择正确的地址或解决方案名称！");
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
            string serverPath = GetServerPathByLocalPath(localPath);

            //获取文件目录
            string dir = Path.GetDirectoryName(serverPath);

            if (!dic.ContainsKey(dir))
            {
                //获取服务器上
                ItemSet its = version.GetItems(dir, RecursionType.Full);

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
            this.UpdateNumber += ws.PendEdit(localPath, RecursionType.Full);
        }

        /// <summary>
        /// 签出编辑
        /// </summary>
        /// <param name="localPath"></param>
        private void Add(string localPath)
        {
            //获取添加服务地址
            string serverPath = GetServerPathByLocalPath(localPath);

            ws.Map(serverPath, localPath);
            //编辑
            this.UpdateNumber += ws.PendAdd(localPath);
        }

        /// <summary>
        /// 获取文件所在目录的最新版本
        /// </summary>
        /// <param name="its"></param>
        public void GetLatest(string localPath, RecursionType recursionType = RecursionType.Full)
        {
            //获取文件目录
            string serverPath = Path.GetDirectoryName(GetServerPathByLocalPath(localPath));

            GetLatesByServerPath(serverPath, recursionType);
        }

        /// <summary>
        /// 获取TFS服务器该目录的最新版本
        /// </summary>
        /// <param name="serverPath"></param>
        public void GetLatesByServerPath(string serverPath, RecursionType recursionType = RecursionType.Full)
        {
            ItemSet its = version.GetItems(serverPath, recursionType);

            if (!dic.ContainsKey(serverPath))
            {
                dic.Add(serverPath, its);

                foreach (var item in its.Items)
                {
                    string localItem = GetLocalPathByServerPath(item.ServerItem);
                    if (item.ItemType == ItemType.Folder)
                    {
                        if (!Directory.Exists(localItem))//判断目录是否存在
                        {
                            Directory.CreateDirectory(localItem);
                        }
                    }
                    else if (item.ItemType == ItemType.File)
                    {
                        item.DownloadFile(localItem);//下载最新版本
                    }
                }
            }
        }

        /// <summary>
        /// 根据本地文件地址，获取TFS服务地址
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns></returns>
        public string GetServerPathByLocalPath(string localPath)
        {
            //获取添加服务地址
            return localPath.Replace(wf.LocalItem, wf.ServerItem).Replace('\\', '/').Replace("//", "/");
        }


        /// <summary>
        /// 根据TFS服务的文件地址，获取本地映射地址
        /// </summary>
        /// <param name="ServerPath"></param>
        /// <returns></returns>
        public string GetLocalPathByServerPath(string ServerPath)
        {
            //获取添加服务地址
            return ServerPath.Replace(wf.ServerItem, wf.LocalItem + "\\").Replace('/', '\\').Replace("/", "//"); ;
        }


        /// <summary>
        /// 获取挂起的更改
        /// </summary>
        /// <returns></returns>
        public List<FileInfo> GetPendingChange()
        {
            List<FileInfo> fileInfos = new List<FileInfo>();

            PendingChange[] pendingChanges = ws.GetPendingChanges();

            foreach (var pendingChange in pendingChanges)
            {
                fileInfos.Add(new FileInfo(pendingChange.LocalItem));
            }

            return fileInfos;
        }

        /// <summary>
        /// 获取挂起的更改
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PendingChange> GetPendingChanges()
        {
            return ws.GetPendingChangesEnumerable();
        }

        /// <summary>
        /// 签入二开
        /// </summary>
        /// <param name="checkInFileInfos">签入的文件信息</param>
        /// <param name="checkInRemark">签入说明</param>
        /// <returns></returns>
        public bool CheckIn(List<FileInfo> checkInFileInfos, string checkInRemark)
        {
            ItemSpec[] itemSpecs = new ItemSpec[checkInFileInfos.Count];
            for (int i = 0; i < checkInFileInfos.Count; i++)
            {
                itemSpecs[i] = new ItemSpec(checkInFileInfos[i].FullName, RecursionType.Full);
            }
            WorkspaceCheckInParameters wscip = new WorkspaceCheckInParameters(itemSpecs, "产品迁移二开工具：" + checkInRemark);
            try
            {
                int changeSetId = ws.CheckIn(wscip);//签入。
                if (changeSetId != -1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }


        /// <summary>
        /// 撤销挂起
        /// </summary>
        /// <param name="checkInFileInfos"></param>
        /// <returns></returns>
        public bool Undo(List<FileInfo> checkInFileInfos)
        {
            ItemSpec[] itemSpecs = new ItemSpec[checkInFileInfos.Count];
            for (int i = 0; i < checkInFileInfos.Count; i++)
            {
                itemSpecs[i] = new ItemSpec(checkInFileInfos[i].FullName, RecursionType.Full);
            }
            try
            {
                int count = ws.Undo(itemSpecs);//签入。
                if (count == checkInFileInfos.Count)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw new Exception("撤销失败，请打开VS查看详情！");
            }
            return false;
        }

        /// <summary>
        /// 获取历史变更集
        /// </summary>
        public void GetHistory()
        {
            //查询历史版本
            var histories = version.QueryHistory(this.vsPath, VersionSpec.Latest, 0, RecursionType.OneLevel, null, null, null, int.MaxValue, true, false).Cast<Changeset>();

            foreach (Changeset changeSet in histories)
            {
                foreach (Change change in changeSet.Changes)//每个历史版本下修改了几个文件
                {

                }
            }
        }

        public void GetDelete()
        {
            //查询历史版本
            var histories = version.QueryHistory(this.vsPath, VersionSpec.Latest, 0, RecursionType.OneLevel, null, null, null, int.MaxValue, true, false);

            foreach (Changeset changeSet in histories)
            {
                foreach (Change change in changeSet.Changes)//每个历史版本下修改了几个文件
                {

                }
            }
        }

    }
}
