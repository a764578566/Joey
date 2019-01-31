using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using JoeySoft.TFS;
using JoeySoft.Core;
using JoeySoft.FromCore;
using JoeySoft.JoeyLog;
using SmartSolutions.Controls;
using JoeySoft.TfsDevelopWinFrom.model;
using System.Net.Http;
using Newtonsoft.Json;
using JoeySofy.TFS;

namespace JoeySoft.TfsDevelopWinFrom
{
    public partial class TfsDevelopFrom : Form
    {
        //是否关闭窗体
        private bool isClose = false;

        private string openFileName;

        //产品目录
        private readonly string KeyProduct = "ProductRootPath";

        private string version;
        //是否更新
        private bool isUpdate = false;

        /// <summary>
        /// 产品根目录
        /// </summary>
        public string rootProductPath { get; private set; }

        //二开目录
        private readonly string KeyCustomize = "CustomizeRootPath";
        private string[] rootCustomizePaths;
        /// <summary>
        /// 二开目录
        /// </summary>
        public string customizePath { get; private set; }

        //迁移元数据目录
        private string metadataDirectory;

        //二开解决方案名称
        private string customizeSlnFileName;
        //产品解决方案名称
        private string productSlnFileName;

        private List<string> notContainFileNames;

        private decimal progressValue = 0;

        public TfsDevelopFrom()
        {
            InitializeComponent();
            JoeyLog.Logging.WriteLog("启动程序");
            try
            {
                rootProductPath = ConfigurationManager.AppSettings[KeyProduct];
                InitErrorLog(rootProductPath, "请配置APP.config的“产品根目录" + KeyProduct + "”节点！");
                rootCustomizePaths = ConfigurationManager.AppSettings[KeyCustomize].Split(',');
                InitErrorLog(rootCustomizePaths, "请配置APP.config的“产品根目录" + KeyProduct + "”节点！");
                customizeSlnFileName = ConfigurationManager.AppSettings["CustomizeSlnFileName"];
                InitErrorLog(customizeSlnFileName, "请配置APP.config的“二开解决方案名称CustomizeSlnFileName”节点！");
                productSlnFileName = ConfigurationManager.AppSettings["ProductSlnFileName"];
                InitErrorLog(productSlnFileName, "请配置APP.config的“产品解决方案名称ProductSlnFileName”节点！");
                _updateDirectorys = ConfigClass.UpdateDirectory.Split(',').ToList();
                metadataDirectory = ConfigClass.MetadataDirectory;

                string notContainFileNameStr = ConfigurationManager.AppSettings["NotContainFileName"];
                if (string.IsNullOrEmpty(notContainFileNameStr) == false)
                {
                    notContainFileNames = notContainFileNameStr.Split(',').ToList();
                }
                else
                {
                    notContainFileNames = new List<string>();
                }
                notContainFileNames.AddRange(ConfigClass.NotContainFileName.Split(',').ToList());
            }
            catch (Exception ex)
            {
                JoeyLog.Logging.WriteErrorLog(ex);
                MessageBox.Show("请配置APP.config节点！详情：" + ex.Message);
                return;
            }
            this.version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            this.updateDateTimePicker.Text = DateTime.Now.ToString("yyyy-MM-dd");

            this.pathTBx.Text = rootProductPath;

            this.customizePathCBX.Text = rootCustomizePaths[0];
            this.customizePathCBX.Items.AddRange(rootCustomizePaths);
            customizePath = this.customizePathCBX.Text;
            //是否直接复制到指定目录 否
            this.isFalseCopyRadioBtn.Select();
            //是否直接签入二开 否
            this.isTrueCheckoutRadioBtn.Select();
        }

        private void InitErrorLog(string data, string error)
        {
            if (string.IsNullOrEmpty(data))
            {
                JoeyLog.Logging.WriteLog(error);
                MessageBox.Show(error);
                isClose = true;
            }
        }
        private void InitErrorLog(string[] data, string error)
        {
            if (data == null || data.Count() == 0)
            {
                InitErrorLog(string.Empty, error);
            }
        }
        private void InitErrorLog(List<string> data, string error)
        {
            InitErrorLog(data.ToArray(), error);
        }

        //获取修改当前日期
        private DateTime _dt;
        //更新目录
        private string _metadata = ConfigClass._metadata;
        private string _clgyl = ConfigClass._clgyl;
        private string _bin = ConfigClass._bin;
        private string _app_Data = ConfigClass._app_Data;
        private string[] _app_DataContainFileNames = ConfigClass.App_DataContainFileNames.Split(',');

        //更新文件夹
        private List<string> _updateDirectorys;

        //需要更新的文件信息
        private List<FileInfo> _updateFiles;

        //需要新增的文件信息
        private List<FileInfo> _addFiles;

        //二开的元数据文件路径
        private List<FileInfo> _customizeFilePath = new List<FileInfo>();

        //提示是否有没签入的产品元数据
        bool isTip = false;

        /// <summary>
        /// 打开更新的文件目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RootFileBtn_Click(object sender, EventArgs e)
        {
            this._updateFiles = new List<FileInfo>();
            this.updateTriSatateTreeView.Nodes.Clear();
            string rootPath = this.pathTBx.Text;
            //获取修改当前日期
            _dt = DateTime.Parse(DateTime.Parse(this.updateDateTimePicker.Text).ToString("yyyy/MM/dd"));
            if (string.IsNullOrEmpty(this.pathTBx.Text))
            {
                //选择文件夹
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.SelectedPath = rootProductPath;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //选择的文件夹
                    this.pathTBx.Text = folderBrowserDialog.SelectedPath;
                }
            }
            if (!File.Exists(rootPath + "\\Web.config"))
            {
                MessageBox.Show("请选择产品根目录！");
            }
            else
            {
                //产品TFS
                TFSHelper tfs = new TFSHelper(Directory.GetParent(rootPath).FullName, productSlnFileName);
                _updateFiles.AddRange(GetRootFileName(rootPath));
                _updateFiles.AddRange(GetMetadataFiles(rootPath));
                var pendingFiles = tfs.GetPendingChange();
                //判断产品TFS是否全部签入
                if (pendingFiles.Count > 0)
                {
                    _updateFiles = null;
                    foreach (var item in pendingFiles)
                    {
                        Logging.WriteLog("没有签入的产品文件：", item.FullName);
                    }
                    MessageBox.Show("产品有未签入的数据，不可以迁移二开！");
                    return;
                }
                if (isTip)
                {
                    _updateFiles = null;
                    MessageBox.Show("产品有未签入的元数据，请在建模平台签入后迁移二开！");
                    return;
                }

                _updateFiles.AddRange(GetBinFiles(rootPath));
                _updateFiles.AddRange(GetAppDataFiles(rootPath));
                //获取需要更新的文件夹信息
                foreach (var updateDirectory in _updateDirectorys)
                {
                    openFileName = Path.Combine(rootPath, updateDirectory);
                    _updateFiles.AddRange(GetUpdateFiles(openFileName));
                }


                IEnumerable<IGrouping<string, FileInfo>> dictionarys = _updateFiles.GroupBy(n => n.DirectoryName);
                if (_updateFiles != null && _updateFiles.Count > 0)
                {
                    foreach (var dictionary in dictionarys)
                    {
                        TriStateTreeNode treeNode1 = new TriStateTreeNode();
                        treeNode1.Text = dictionary.Key.Replace(this.pathTBx.Text + "\\", "");
                        treeNode1.Text = treeNode1.Text.Replace(this.pathTBx.Text.Replace("00_根目录", ""), "");
                        treeNode1.CheckboxVisible = true;
                        treeNode1.Checked = true;
                        treeNode1.IsContainer = true;//文件夹
                        var list = dictionary.OrderBy(n => n.Name);
                        foreach (var metadataFile in list)
                        {
                            TriStateTreeNode treeNode2 = new TriStateTreeNode(metadataFile.Name, 2, 2);
                            treeNode2.Checked = true;
                            treeNode2.Tag = metadataFile;
                            treeNode1.Nodes.Add(treeNode2);
                        }
                        this.updateTriSatateTreeView.Nodes.Add(treeNode1);
                    }

                    if (this.isTrueCopyRadioBtn.Checked)
                    {
                        this._updateFiles = TriStateTreeNodeHelper.GetTreeNodeChecked(this.updateTriSatateTreeView.Nodes);
                        if (this._updateFiles == null)
                        {
                            MessageBox.Show("请选择产品修改的信息！");
                            return;
                        }
                        if (this._updateFiles.Count == 0)
                        {
                            MessageBox.Show("没有要复制编辑签出的文件！");
                            return;
                        }
                        progressValue = 0;
                        customizePath = this.customizePathCBX.Text;
                        this.worker.RunWorkerAsync(); // 运行 backgroundWorker 组件
                        ProgressBar form = new ProgressBar(this.worker);// 显示进度条窗体
                        form.ShowDialog(this);
                    }
                }
            }
        }

        /// <summary>
        /// 获取元数据内信息
        /// </summary>
        /// <param name="openFileName"></param>
        /// <returns></returns>
        private List<FileInfo> GetRootFileName(string openFileName)
        {
            string[] directoryFileNamelist = Directory.GetFiles(openFileName);
            string[] rootFileNames = ConfigClass.RootContainFileName.Split(',');

            List<FileInfo> fileInfos = new List<FileInfo>();

            foreach (var item in rootFileNames)
            {
                string pathFileName = Path.Combine(openFileName, item);
                if (directoryFileNamelist.Contains(pathFileName))
                {
                    FileInfo file = new FileInfo(pathFileName);
                    //判断修改时间是否大于当前时间
                    if (file.LastWriteTime >= _dt)
                    {
                        fileInfos.Add(file);
                    }
                }
            }
            return fileInfos;
        }

        /// <summary>
        /// 获取元数据内信息
        /// </summary>
        /// <param name="openFileName"></param>
        /// <returns></returns>
        private List<FileInfo> GetMetadataFiles(string openFileName)
        {
            isTip = false;

            openFileName = Path.Combine(openFileName, _metadata);

            List<FileInfo> metadataFiles = new List<FileInfo>();

            //如果不存在为空标识不迁移任何文件
            if (string.IsNullOrEmpty(metadataDirectory))
            {
                return metadataFiles;
            }
            string[] directoryNames = metadataDirectory.Split(',');

            if (!Directory.Exists(openFileName))
            {
                MessageBox.Show("请选择产品根目录！");
            }
            else
            {
                //_metadata下子级目录
                foreach (var directoryName in directoryNames)
                {
                    string parentDirectoryName = Path.Combine(openFileName, directoryName);

                    List<string> directoryFileNamelist = new List<string>() { parentDirectoryName };

                    //判断文件是否存在
                    if (!Directory.Exists(parentDirectoryName))
                    {
                        string message = parentDirectoryName + "文件夹不存在！";
                        JoeyLog.Logging.WriteLog(message);
                        continue;
                    }
                    //_metadata下子级目录下目录
                    GetDirectorie(parentDirectoryName, directoryFileNamelist);

                    foreach (var directoryFileName in directoryFileNamelist)
                    {
                        //判断文件是否存在
                        if (!Directory.Exists(Path.Combine(parentDirectoryName, directoryFileName)))
                        {
                            string message = "文件‘" + parentDirectoryName + "’不存在！";
                            JoeyLog.Logging.WriteLog(message);
                            break;
                        }
                        string[] fileNames = Directory.GetFiles(Path.Combine(parentDirectoryName, directoryFileName));
                        foreach (var fileName in fileNames)
                        {
                            FileInfo file = new FileInfo(fileName);
                            //判断修改时间是否大于当前时间
                            if (file.LastWriteTime >= _dt)
                            {
                                metadataFiles.Add(file);
                            }
                            if (fileName.IndexOf(".design.") != -1)
                            {
                                isTip = true;
                            }
                        }
                    }
                }
            }
            return metadataFiles;
        }

        /// <summary>
        /// 获取指定文件夹下所有修改文件
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        private List<FileInfo> GetUpdateFiles(string pathName)
        {
            List<FileInfo> filesInfo = new List<FileInfo>();
            List<string> directoryFileNamelist = new List<string>() { pathName };

            GetDirectorie(pathName, directoryFileNamelist);

            if (!Directory.Exists(pathName))
            {
                MessageBox.Show("请选择产品根目录！");
            }
            else
            {
                foreach (var directoryName in directoryFileNamelist)
                {
                    string[] fileNameAppForm = Directory.GetFiles(Path.Combine(pathName, directoryName));
                    foreach (var fileName in fileNameAppForm)
                    {
                        FileInfo file = new FileInfo(fileName);
                        //判断修改时间是否大于当前时间
                        if (file.LastWriteTime >= _dt && !notContainFileNames.Contains(file.Name))
                        {
                            filesInfo.Add(file);
                        }
                    }
                }
            }
            return filesInfo;
        }

        /// <summary>
        /// 获取bin信息
        /// </summary>
        /// <param name="openFileName"></param>
        /// <returns></returns>
        private List<FileInfo> GetBinFiles(string openFileName)
        {
            openFileName = Path.Combine(openFileName, _bin);
            List<FileInfo> metadataFiles = new List<FileInfo>();
            List<string> directoryFileNamelist = new List<string>() { openFileName };

            GetDirectorie(openFileName, directoryFileNamelist);

            if (!Directory.Exists(openFileName))
            {
                MessageBox.Show("请选择产品根目录！");
            }
            else
            {
                foreach (var directoryName in directoryFileNamelist)
                {
                    string[] fileNameAppForm = Directory.GetFiles(Path.Combine(openFileName, directoryName));
                    foreach (var fileName in fileNameAppForm)
                    {
                        FileInfo file = new FileInfo(fileName);
                        if (IsAddBinDll(file))
                        {
                            metadataFiles.Add(file);
                        }
                    }
                }

            }
            return metadataFiles;
        }

        /// <summary>
        /// 获取bin信息
        /// </summary>
        /// <param name="openFileName"></param>
        /// <returns></returns>
        private List<FileInfo> GetAppDataFiles(string openFileName)
        {
            openFileName = Path.Combine(openFileName, _app_Data);
            List<FileInfo> appDataFiles = new List<FileInfo>();
            List<string> directoryFileNamelist = new List<string>() { openFileName };

            GetDirectorie(openFileName, directoryFileNamelist);

            if (!Directory.Exists(openFileName))
            {
                MessageBox.Show("请选择产品根目录！");
            }
            else
            {
                foreach (var directoryName in directoryFileNamelist)
                {
                    string[] fileNameAppForm = Directory.GetFiles(Path.Combine(openFileName, directoryName));
                    foreach (var fileName in fileNameAppForm)
                    {
                        FileInfo file = new FileInfo(fileName);
                        if (IsAddAppDataFile(file))
                        {
                            appDataFiles.Add(file);
                        }
                    }
                }

            }
            return appDataFiles;
        }

        /// <summary>
        /// 包含的AppDataFile
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool IsAddAppDataFile(FileInfo file)
        {
            return _app_DataContainFileNames.Contains(file.Name);
        }

        /// <summary>
        /// 是否添加DLL目录下该文件
        /// </summary>
        /// <param name="fileName"></param>
        private bool IsAddBinDll(FileInfo file)
        {
            //判断修改时间是否大于当前时间
            if (file.LastWriteTime >= _dt && file.Name.IndexOf("Fakes") == -1 && file.Name.IndexOf("UnitTest") == -1)
            {
                if (file.Name.IndexOf("Web_Clgyl") == -1 && file.Name.IndexOf("License.xml") == -1 && file.Name.IndexOf(".pdb") == -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 递归获取文件目录
        /// </summary>
        /// <returns></returns>
        private void GetDirectorie(string directorieName, List<string> directoryFileNamelist)
        {
            string[] directoryNames = Directory.GetDirectories(directorieName);
            if (directoryNames != null && directoryNames.Count() > 0)
            {
                directoryFileNamelist.AddRange(directoryNames);
                foreach (var directoryName in directoryNames)
                {
                    GetDirectorie(directoryName, directoryFileNamelist);
                }
            }
        }

        /// <summary>
        /// 复制到指定目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customizebtn_Click(object sender, EventArgs e)
        {
            //是否是空 如果是空就去打开选择地址
            if (string.IsNullOrEmpty(this.customizePathCBX.Text))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.SelectedPath = this.customizePathCBX.Text;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //选择的文件夹
                    string openFileName = folderBrowserDialog.SelectedPath;
                    this.customizePathCBX.Text = openFileName;
                    if (!File.Exists(openFileName + "\\Web.config"))
                    {
                        MessageBox.Show("请选择二开根目录！");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            this._updateFiles = TriStateTreeNodeHelper.GetTreeNodeChecked(this.updateTriSatateTreeView.Nodes);
            if (this._updateFiles == null)
            {
                MessageBox.Show("请选择读取产品修改信息！");
                return;
            }
            if (this._updateFiles.Count == 0)
            {
                MessageBox.Show("没有要复制编辑签出的文件！");
                return;
            }
            progressValue = 0;
            customizePath = this.customizePathCBX.Text;
            this.worker.RunWorkerAsync(); // 运行 backgroundWorker 组件
            ProgressBar form = new ProgressBar(this.worker);// 显示进度条窗体
            form.ShowDialog(this);
        }

        /// <summary>
        /// 复制更新文件
        /// </summary>
        private void CopyUpdateFileAndCheckout()
        {
            //Tfs帮助类
            TFSHelper tfsHelper = new TFSHelper(Directory.GetParent(customizePath).FullName, customizeSlnFileName);

            //判断产品TFS是否全部签入
            if (tfsHelper.GetPendingChange().Count > 0)
            {
                _updateFiles = null;
                MessageBox.Show("二开有未签入的数据，不可以再次签入二开，请先签入二开！");
                return;
            }

            //先复制新的文件
            if (!CopyNewFile(tfsHelper))
            {
                return;
            }
            //签出编辑
            if (!Checkout(tfsHelper))
            {
                return;
            }
            //复制文件
            if (!CopyUpdateFile(tfsHelper))
            {
                return;
            }
            //判断是否有编辑签入文件
            if (this._updateFiles.Count == 0)
            {
                MessageBox.Show("没有要编辑签出的文件夹！");
                return;
            }
            MessageBox.Show("复制成功并签出编辑成功！");

            if (CustomizeFileIsTrue() && this._customizeFilePath.Count > 0)
            {
                MessageBox.Show("有二开文件，请点击“显示二开元数据”查看详情信息！");
            }
            JoeyLog.Logging.WriteLog("完成编辑签出");
        }

        /// <summary>
        /// 复制新的文件
        /// </summary>
        private bool CopyNewFile(TFSHelper tfsHelper)
        {
            _addFiles = new List<FileInfo>();
            //复制文件
            decimal progressAddValue = 10M / this._updateFiles.Count;
            foreach (var updateFile in this._updateFiles)
            {
                progressValue += progressAddValue;
                this.worker.ReportProgress((int)progressValue, "开始复制文件" + updateFile.Name + "，请稍后.....");
                var directoryName = updateFile.DirectoryName.Replace(rootProductPath + "\\", "");
                var fileName = Path.Combine(customizePath, directoryName, updateFile.Name);

                if (!File.Exists(fileName))
                {
                    //生成新目录
                    string dir = Path.GetDirectoryName(fileName);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                }
                else
                {
                    continue;
                }
                try
                {
                    _addFiles.Add(updateFile);
                    JoeyLog.Logging.WriteLog("复制新的文件" + fileName);
                    File.Copy(updateFile.FullName, fileName, true);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 复制更新文件并签出编辑
        /// </summary>
        private bool CopyUpdateFile(TFSHelper tfsHelper)
        {
            //复制文件
            List<FileInfo> removeFiles = new List<FileInfo>();
            List<FileInfo> undoFiles = new List<FileInfo>();
            decimal progressAddValue = 10M / this._updateFiles.Count;
            foreach (var updateFile in this._updateFiles)
            {
                progressValue += progressAddValue;
                this.worker.ReportProgress((int)progressValue, "开始复制文件" + updateFile.Name + "，请稍后.....");
                var directoryName = updateFile.DirectoryName.Replace(rootProductPath + "\\", "");
                if (directoryName.Contains(rootProductPath))
                {
                    directoryName = updateFile.DirectoryName.Replace(rootProductPath, "");
                }
                var fileName = Path.Combine(customizePath, directoryName, updateFile.Name);

                if (File.Exists(fileName))
                {
                    FileInfo fi = new FileInfo(fileName);
                    //修改文件只读
                    if ((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                    //如果相同文件没有修改过
                    if (MD5Helper.CompareFile(updateFile.FullName, fileName) && _addFiles.FirstOrDefault(n => n == updateFile) == null)
                    {
                        removeFiles.Add(updateFile);
                        //撤销签出编辑
                        undoFiles.Add(new FileInfo(fileName));
                        JoeyLog.Logging.WriteLog("撤销签出编辑文件：" + fileName);
                        continue;
                    }
                }
                try
                {
                    File.Copy(updateFile.FullName, fileName, true);
                    JoeyLog.Logging.WriteLog("复制编辑签出文件：" + fileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
            if (undoFiles.Count > 0)
            {
                tfsHelper.Undo(undoFiles);
                foreach (var item in removeFiles)
                {
                    this._updateFiles.Remove(item);
                }
            }
            this.worker.ReportProgress(100, "完成");
            return true;
        }

        /// <summary>
        /// 签出编辑
        /// </summary>
        private bool Checkout(TFSHelper tfsHelper)
        {
            decimal progressAddValue = 80M / this._updateFiles.Count;
            //签出编辑
            foreach (var updateFile in this._updateFiles)
            {
                progressValue += progressAddValue;
                this.worker.ReportProgress((int)progressValue, "开始签出编辑文件" + updateFile.Name + "，请稍后.....");
                var directoryName = updateFile.DirectoryName.Replace(rootProductPath + "\\", "");
                if (directoryName.Contains(rootProductPath))
                {
                    directoryName = updateFile.DirectoryName.Replace(rootProductPath, "");
                    var fileName = Path.Combine(customizePath, directoryName, updateFile.Name);
                    tfsHelper.GetLatest(fileName, JoeyRecursionType.OneLevel);
                    tfsHelper.CheckOut(fileName);
                }
                else
                {
                    var fileName = Path.Combine(customizePath, directoryName, updateFile.Name);
                    //获取文件所在目录的最新版本
                    tfsHelper.GetLatest(fileName);
                    tfsHelper.CheckOut(fileName);
                }
            }
            return true;
        }

        /// <summary>
        /// 显示二开过元数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showCustomizeFileBtn_Click(object sender, EventArgs e)
        {
            _customizeFilePath = new List<FileInfo>();
            //校验是否二开过
            if (CustomizeFileIsTrue())
            {
                if (_customizeFilePath.Count == 0)
                {
                    MessageBox.Show("没有二开过的元数据！");
                    return;
                }

                CustomizeFilesFrom customizeFilesFrom = new CustomizeFilesFrom(this.customizePathCBX.Text, _customizeFilePath);

                customizeFilesFrom.ShowDialog();
            }
        }

        /// <summary>
        /// 判断是否二开过该界面
        /// </summary>
        private bool CustomizeFileIsTrue()
        {
            if (this._updateFiles == null)
            {
                MessageBox.Show("请选择读取产品修改信息！");
                return false;
            }
            foreach (var updateFile in this._updateFiles)
            {
                //目录名称
                var directoryName = updateFile.DirectoryName.Replace(this.pathTBx.Text + "\\", "");
                //判断是否是元数据
                if (directoryName.IndexOf(_metadata) == 0)
                {
                    var filePath = Path.Combine(customizePath, directoryName.Replace(_metadata, ConfigClass.x_MetaData), updateFile.Name);
                    if (File.Exists(filePath))
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        _customizeFilePath.Add(fileInfo);
                    }
                }
                //判断二开js
                if (directoryName.IndexOf(_clgyl) == 0)
                {
                    var filePath = Path.Combine(customizePath, directoryName.Replace(_clgyl, ConfigClass.customize + "\\" + _clgyl), updateFile.Name);
                    if (File.Exists(filePath))
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        _customizeFilePath.Add(fileInfo);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 显示二开签入文件信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckInBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.customizePathCBX.Text) || !Directory.Exists(this.customizePathCBX.Text))
            {
                MessageBox.Show("请输入正确二开地址！");
                return;
            }
            //获取解决方案地址
            string filePath = Path.Combine(Directory.GetParent(this.customizePathCBX.Text).FullName, customizeSlnFileName);

            if (File.Exists(filePath))
            {
                CheckInForm checkInForm = new CheckInForm(this.customizePathCBX.Text, customizeSlnFileName);

                checkInForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请输入正确二开地址！");
                return;
            }
        }

        /// <summary>
        /// 取消选中或选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateTriSatateTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //只处理鼠标点击引起的状态变化  
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node is TriStateTreeNode)
                {
                    List<TreeNode> fileTreeNodes = new List<TreeNode>();
                    TriStateTreeNode tsTreeNode = e.Node as TriStateTreeNode;
                    if (tsTreeNode.Nodes.Count == 0)
                    {
                        fileTreeNodes.Add(tsTreeNode);
                    }
                    if (tsTreeNode.Checked == false)
                    {
                        List<FileInfo> updateFileInfo = new List<FileInfo>();
                        foreach (var updatefile in this._updateFiles)
                        {
                            if (fileTreeNodes.Exists(n => n.Text == updatefile.Name))
                            {
                                updateFileInfo.Add(updatefile);
                            }

                        }

                        foreach (var updateFile in updateFileInfo)
                        {
                            this._updateFiles.Remove(updateFile);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 产品地址值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pathTBx_TextChanged(object sender, EventArgs e)
        {
            string text = this.pathTBx.Text;
            if (!string.IsNullOrEmpty(text) && text != rootProductPath)
            {
                //判断是否是产品目录
                if (!File.Exists(text + "\\Web.config"))
                {
                    MessageBox.Show("请选择产品根目录！");
                    return;
                }
                DialogResult dr = MessageBox.Show("是否替换原产品地址？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Logging.WriteLog("替换产品地址，原地址为：" + rootProductPath + "，新产品地址：" + text);
                    AppConfigHelper.UpdateAppConfig(KeyProduct, text);
                    rootProductPath = text;
                }
            }
        }

        /// <summary>
        /// 二开地址值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customizePathCBX_TextChanged(object sender, EventArgs e)
        {
            string text = this.customizePathCBX.Text;
            //在下拉框中找不到该地址
            if (!string.IsNullOrEmpty(text) && rootCustomizePaths.FirstOrDefault(n => n == text) == null)
            {
                //判断是否是产品目录
                if (!File.Exists(text + "\\Web.config"))
                {
                    MessageBox.Show("请选择二开根目录！");
                    return;
                }
                DialogResult dr = MessageBox.Show("是否添加二开地址？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.customizePathCBX.Items.Add(text);
                    List<string> customizePaths = rootCustomizePaths.ToList();
                    customizePaths.Add(text);
                    JoeyLog.Logging.WriteLog("添加二开地址：" + text);
                    AppConfigHelper.UpdateAppConfig(KeyCustomize, string.Join(",", customizePaths));
                }
            }
        }

        /// <summary>
        /// 进度条后台工作任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //复制更新文件
            CopyUpdateFileAndCheckout();
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TfsDevelopFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logging.WriteLog("关闭程序");
            if (isUpdate)
            {
                string updateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigClass.UpdateServicePathName,
                   ConfigClass.UpdateServiceExeName);
                if (File.Exists(updateFilePath))
                {
                    System.Diagnostics.Process.Start(updateFilePath);
                }
                else
                {
                    Logging.WriteLog("不存在更新文件：" + updateFilePath);
                    MessageBox.Show("不存在更新文件请联系，Email：zhoujr01@mysoft.com.cn");
                }
            }
        }


        private void TfsDevelopFrom_Load(object sender, EventArgs e)
        {
            //加载后后台更新更新包
            Task.Run(() =>
            {
                var joeySoftVersion = UpdateService.CheckUpdateClientVersion();
                if (joeySoftVersion != null)
                {
                    var myFileVersionInfo = UpdateService.GetUpdateClientVersion();
                    if (myFileVersionInfo != null)
                    {
                        if (VersionHelper.CompareVersion(myFileVersionInfo, joeySoftVersion) == false)
                        {
                            Logging.WriteLog("当前版本：" + myFileVersionInfo.FileVersion);
                            return;
                        }
                    }
                    if (myFileVersionInfo == null || myFileVersionInfo.FileVersion != joeySoftVersion.Version)
                    {
                        UpdateService.DownloadUpdateClient(joeySoftVersion.Version);
                    }
                }
            });

            if (isClose)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.updateTriSatateTreeView.SelectedNode != null)
            {
                TriStateTreeNodeHelper.Checked(this.updateTriSatateTreeView, this.updateTriSatateTreeView.SelectedNode, true);
            }
            else
            {
                TriStateTreeNodeHelper.Checked(this.updateTriSatateTreeView, true);
            }
        }


        /// <summary>
        /// 全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.updateTriSatateTreeView.SelectedNode != null)
            {
                TriStateTreeNodeHelper.Checked(this.updateTriSatateTreeView, this.updateTriSatateTreeView.SelectedNode, false);
            }
            else
            {
                TriStateTreeNodeHelper.Checked(this.updateTriSatateTreeView, false);
            }
        }

        /// <summary>
        /// 检查最新版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var joeySoftVersion = UpdateService.CheckTfsDevelopVersion();
                var myFileVersionInfo = UpdateService.GetTfsDevelopVersion();
                if (myFileVersionInfo != null)
                {
                    if (VersionHelper.CompareVersion(myFileVersionInfo, joeySoftVersion) == false)
                    {
                        Logging.WriteLog("检查最新版本：" + myFileVersionInfo.FileVersion);
                        MessageBox.Show("已是最新版本Version：" + this.version);
                        return;
                    }
                }
                if (myFileVersionInfo == null || joeySoftVersion.Version != this.version)
                {
                    DialogResult dialogResult = MessageBox.Show("当前软件版本Version：" + this.version + "，检查到最新版本" + joeySoftVersion.Version + "，是否需要更新？",
                        "提示", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        isUpdate = true;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("已是最新版本Version：" + this.version);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        /// <summary>
        /// 关于工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版本号（Version）：" + this.version);
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email：zhoujr01@mysoft.com.cn");
        }

        private void customizePathCBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            customizePath = this.customizePathCBX.Text;
        }

        private void CancalSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.updateTriSatateTreeView.SelectedNode != null)
            {
                this.updateTriSatateTreeView.SelectedNode = null;
            }
        }

        /// <summary>
        /// 排序按名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 排序按时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderByUpdateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
