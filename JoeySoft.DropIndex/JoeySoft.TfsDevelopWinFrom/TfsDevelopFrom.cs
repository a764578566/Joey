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
using JoeySofy.TFS;
using JoeySoft.Core;
using SmartSolutions.Controls;

namespace JoeySoft.TfsDevelopWinFrom
{
    public partial class TfsDevelopFrom : Form
    {
        private string openFileName;

        //产品目录
        private string KeyProduct = "ProductRootPath";
        private string rootProductPath;

        //二开目录
        private string KeyCustomize = "CustomizeRootPath";
        private string[] rootCustomizePaths;

        //迁移元数据目录
        private string metadataDirectory;

        //二开解决方案名称
        private string CustomizeSlnFileName;

        public TfsDevelopFrom()
        {
            InitializeComponent();

            try
            {
                rootProductPath = ConfigurationManager.AppSettings[KeyProduct];

                rootCustomizePaths = ConfigurationManager.AppSettings[KeyCustomize].Split(',');

                metadataDirectory = ConfigurationManager.AppSettings["MetadataDirectory"];

                CustomizeSlnFileName = ConfigurationManager.AppSettings["CustomizeSlnFileName"];

                _updateDirectorys = ConfigurationManager.AppSettings["UpdateDirectory"].Split(',').ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("请配置APP.config节点！");
                return;
            }

            this.updateDateTimePicker.Text = DateTime.Now.ToString("yyyy-MM-dd");

            this.pathTBx.Text = rootProductPath;

            this.customizePathCBX.Text = rootCustomizePaths[0];

            this.customizePathCBX.Items.AddRange(rootCustomizePaths);

            //是否直接复制到指定目录 否
            this.isFalseCopyRadioBtn.Select();
            //是否直接签入二开 否
            this.isTrueCheckoutRadioBtn.Select();
        }

        //获取修改当前日期
        private DateTime _dt;
        //更新目录
        private string _metadata = "_metadata";
        private string _bin = "bin";

        //更新文件夹
        private List<string> _updateDirectorys;

        //需要更新的文件信息
        private List<FileInfo> _updateFiles;

        //二开的元数据文件路径
        private List<FileInfo> _metadataCustomizeFilePath = new List<FileInfo>();

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
            this.pathTBx.Text = this.pathTBx.Text;
            if (!File.Exists(this.pathTBx.Text + "\\Web.config"))
            {
                MessageBox.Show("请选择产品根目录！");
            }
            else
            {
                _updateFiles.AddRange(GetMetadataFiles(this.pathTBx.Text));
                if (isTip)
                {
                    _updateFiles = null;
                    MessageBox.Show("产品有未签入的元数据，不可以迁移二开！");
                    return;
                }

                _updateFiles.AddRange(GetBinFiles(this.pathTBx.Text));

                //获取需要更新的文件夹信息
                foreach (var updateDirectory in _updateDirectorys)
                {
                    openFileName = Path.Combine(this.pathTBx.Text, updateDirectory);
                    _updateFiles.AddRange(GetUpdateFiles(openFileName));
                }


                IEnumerable<IGrouping<string, FileInfo>> dictionarys = _updateFiles.GroupBy(n => n.DirectoryName);
                if (_updateFiles != null && _updateFiles.Count > 0)
                {
                    foreach (var dictionary in dictionarys)
                    {
                        TriStateTreeNode treeNode1 = new TriStateTreeNode();
                        treeNode1.Text = dictionary.Key.Replace(this.pathTBx.Text + "\\", "");
                        treeNode1.CheckboxVisible = true;
                        treeNode1.Checked = true;
                        treeNode1.IsContainer = true;//文件夹
                        foreach (var metadataFile in dictionary)
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
                        CopyUpdateFileAndCheckout();
                    }
                }
            }
        }

        /// <summary>
        /// 获取元数据内信息
        /// </summary>
        /// <param name="openFileName"></param>
        /// <returns></returns>
        private List<FileInfo> GetMetadataFiles(string openFileName)
        {
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

                    //_metadata下子级目录下目录
                    GetDirectorie(parentDirectoryName, directoryFileNamelist);

                    foreach (var directoryFileName in directoryFileNamelist)
                    {
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
                        if (file.LastWriteTime >= _dt)
                        {
                            filesInfo.Add(file);
                        }
                    }
                }
            }
            return filesInfo;
        }

        /// <summary>
        /// 获取js信息
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
        /// 是否添加DLL目录下该文件
        /// </summary>
        /// <param name="fileName"></param>
        private bool IsAddBinDll(FileInfo file)
        {
            //判断修改时间是否大于当前时间
            if (file.LastWriteTime >= _dt && file.Name.IndexOf("Fakes") == -1 && file.Name.IndexOf("UnitTest") == -1)
            {
                if (file.Name.IndexOf("Web_Clgyl") == -1 && file.Name.IndexOf("License.xml") == -1)
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
                    }
                    else
                    {
                        CopyUpdateFileAndCheckout();
                    }
                }
            }
            else
            {
                CopyUpdateFileAndCheckout();
            }
        }

        /// <summary>
        /// 复制更新文件
        /// </summary>
        private void CopyUpdateFileAndCheckout()
        {
            this._updateFiles = GetTreeNodeChecked();
            //Tfs帮助类
            TFSHelper tfsHelper = new TFSHelper(Directory.GetParent(this.customizePathCBX.Text).FullName, CustomizeSlnFileName);
            //复制文件
            if (CopyUpdateFile(tfsHelper))
            {
                if (this.isTrueCheckoutRadioBtn.Checked)
                {
                    //签出编辑
                    if (Checkout(tfsHelper))
                    {
                        MessageBox.Show("复制成功并签出编辑成功！");
                    }
                }
                else
                {
                    this.customizebtn.Enabled = false;
                    MessageBox.Show("复制成功！");
                }
            }

            if (CustomizeFileIsTrue() && this._metadataCustomizeFilePath.Count > 0)
            {
                MessageBox.Show("有二开文件，请点击“显示二开元数据”查看详情信息！");
            }
        }

        /// <summary>
        /// 复制更新文件并签出编辑
        /// </summary>
        private bool CopyUpdateFile(TFSHelper tfsHelper)
        {
            if (this._updateFiles == null)
            {
                MessageBox.Show("请选择读取产品修改信息！");
                return false;
            }
            //复制文件
            List<FileInfo> removeFiles = new List<FileInfo>();
            foreach (var updateFile in this._updateFiles)
            {
                var directoryName = updateFile.DirectoryName.Replace(this.pathTBx.Text + "\\", "");
                var fileName = Path.Combine(this.customizePathCBX.Text, directoryName, updateFile.Name);
                //获取文件所在目录的最新版本
                tfsHelper.GetLatest(fileName);

                if (File.Exists(fileName))
                {
                    FileInfo fi = new FileInfo(fileName);
                    //修改文件只读
                    if ((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                    //如果相同文件没有修改过
                    if (MD5Helper.CompareFile(updateFile.FullName, fileName))
                    {
                        removeFiles.Add(updateFile);
                        continue;
                    }
                }
                else
                {
                    //生成新目录
                    string dir = Path.GetDirectoryName(fileName);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                }
                try
                {
                    File.Copy(updateFile.FullName, fileName, true);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }

            foreach (var removeFile in removeFiles)
            {
                this._updateFiles.Remove(removeFile);
            }
            return true;
        }

        /// <summary>
        /// 签出编辑
        /// </summary>
        private bool Checkout(TFSHelper tfsHelper)
        {
            if (this._updateFiles == null)
            {
                MessageBox.Show("请选择产品目录！");
                return false;
            }
            if (this._updateFiles.Count == 0)
            {
                MessageBox.Show("没有需要签入的文件！");
                return false;
            }
            //签出编辑
            foreach (var updateFile in this._updateFiles)
            {
                var directoryName = updateFile.DirectoryName.Replace(this.pathTBx.Text + "\\", "");
                var fileName = Path.Combine(this.customizePathCBX.Text, directoryName, updateFile.Name);
                tfsHelper.CheckOut(fileName);
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
            _metadataCustomizeFilePath = new List<FileInfo>();
            //校验是否二开过
            if (CustomizeFileIsTrue())
            {
                if (_metadataCustomizeFilePath.Count == 0)
                {
                    MessageBox.Show("没有二开过的元数据！");
                    return;
                }

                CustomizeFilesFrom customizeFilesFrom = new CustomizeFilesFrom(this.customizePathCBX.Text, _metadataCustomizeFilePath);

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
                    var filePath = Path.Combine(this.customizePathCBX.Text, directoryName.Replace(_metadata, "Customize\\x_MetaData"), updateFile.Name);
                    if (File.Exists(filePath))
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        _metadataCustomizeFilePath.Add(fileInfo);
                    }
                }
            }
            return true;
        }

        private void CheckInBtn_Click(object sender, EventArgs e)
        {
            CheckInForm checkInForm = new CheckInForm(this.customizePathCBX.Text, this._updateFiles);

            checkInForm.ShowDialog();
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
        /// 获取要编辑签入的文件信息
        /// </summary>
        /// <returns></returns>
        private List<FileInfo> GetTreeNodeChecked()
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            List<TriStateTreeNode> treeNodes = new List<TriStateTreeNode>();
            foreach (TriStateTreeNode treeNode in this.updateTriSatateTreeView.Nodes)
            {
                treeNodes.AddRange(GetCheckedNodes(treeNode));
            }
            foreach (var treeNode in treeNodes)
            {
                if (treeNode.Tag is FileInfo)
                {
                    fileInfos.Add(treeNode.Tag as FileInfo);
                }
            }
            return fileInfos;
        }

        /// <summary>
        /// 获取子集
        /// </summary>
        /// <returns></returns>
        private List<TriStateTreeNode> GetCheckedNodes(TriStateTreeNode treeNode)
        {
            List<TriStateTreeNode> childNodeList = new List<TriStateTreeNode>();
            foreach (TriStateTreeNode childNode in treeNode.Nodes)
            {
                childNodeList.AddRange(GetCheckedNodes(childNode));
            }
            if (treeNode.Nodes.Count == 0 && treeNode.Checked == true)
            {
                childNodeList.Add(treeNode);
            }
            return childNodeList;
        }
    }
}
