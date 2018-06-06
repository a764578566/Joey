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

namespace JoeySoft.TfsDevelopWinFrom
{
    public partial class DeleteIndexFrom : Form
    {
        #region 生成删除索引
        private static string textTemplateSqlText;

        private string DeleteIndexDirectory = "DeleteIndexSql";

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

        public DeleteIndexFrom()
        {
            InitializeComponent();

            try
            {
                rootProductPath = ConfigurationManager.AppSettings[KeyProduct];

                rootCustomizePaths = ConfigurationManager.AppSettings[KeyCustomize].Split(',');

                metadataDirectory = ConfigurationManager.AppSettings["MetadataDirectory"];

                CustomizeSlnFileName = ConfigurationManager.AppSettings["CustomizeSlnFileName"];

                updateDirectorys = ConfigurationManager.AppSettings["UpdateDirectory"].Split(',');
            }
            catch (Exception e)
            {
                MessageBox.Show("请配置APP.config节点！");
                return;
            }
            textTemplateSqlText = File.ReadAllText("TextTemplate.txt");

            this.updateDateTimePicker.Text = DateTime.Now.ToString("yyyy-MM-dd");

            //如果目录不存在 创建
            if (!Directory.Exists(DeleteIndexDirectory))
            {
                Directory.CreateDirectory(DeleteIndexDirectory);
            }
            this.pathTBx.Text = rootProductPath;

            this.customizePathCBX.Text = rootCustomizePaths[0];

            this.customizePathCBX.Items.AddRange(rootCustomizePaths);

            //是否直接复制到指定目录 否
            this.isFalseCopyRadioBtn.Select();
            //是否直接签入二开 否
            this.isTrueCheckoutRadioBtn.Select();

            this.tabPage1.Parent = null;
        }

        /// <summary>
        /// 生成删除索引按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteIndexbtn_Click(object sender, EventArgs e)
        {
            //读取文件
            string sqlText = this.sqlRtb.Text;
            if (string.IsNullOrEmpty(sqlText))
            {
                return;
            }
            string[] sqlIndexs = sqlText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //匹配索引
            string regexIndexText = @"CREATE [a-zA-Z]+ INDEX ([1-9a-zA-Z_]+)";
            //匹配表
            string regexTableText = @"ON ([1-9a-zA-Z_\[.\]]+) \(";

            //匹配索引与表
            string regexIndexTableText = @"CREATE [a-zA-Z]+ INDEX ([1-9a-zA-Z_]+) ON ([1-9a-zA-Z_\[.\]]+) \(";
            //匹配说明
            string regexRemarkText = @"--(.*)";
            string indexName = "", remark = "";
            foreach (var sqlIndex in sqlIndexs)
            {
                var math2 = Regex.Matches(sqlIndex, regexRemarkText, RegexOptions.IgnoreCase);
                if (math2.Count > 0)
                {
                    if (math2[0].Groups.Count > 1)
                    {
                        remark = math2[0].Groups[1].Value;
                        continue;
                    }
                }
                var math3 = Regex.Matches(sqlIndex, regexIndexTableText, RegexOptions.IgnoreCase);
                if (math3.Count > 0)
                {
                    if (math3[0].Groups.Count > 1)
                    {
                        var textSqlText = string.Format(textTemplateSqlText, math3[0].Groups[2].Value, math3[0].Groups[1].Value, "删除" + remark);
                        this.delIndexRtb.AppendText(textSqlText + "\n");
                        continue;
                    }
                }

                var match = Regex.Matches(sqlIndex, regexIndexText, RegexOptions.IgnoreCase);
                if (match.Count > 0)
                {
                    if (match[0].Groups.Count > 1)
                    {
                        indexName = match[0].Groups[1].Value;
                        continue;
                    }
                }
                var match1 = Regex.Matches(sqlIndex, regexTableText, RegexOptions.IgnoreCase);
                if (match1.Count > 0)
                {
                    if (match1[0].Groups.Count > 1)
                    {
                        var textSqlText = string.Format(textTemplateSqlText, match1[0].Groups[1].Value, indexName, "删除" + remark);
                        this.delIndexRtb.AppendText(textSqlText + "\n");
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 打开sql索引按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sql文件|*.sql|文本文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = "F:\\公司文档\\clerp\\01 SQL提交-重构\\性能优化脚本";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileName = openFileDialog.FileName;
                this.filePathTbx.Text = openFileName;
                //读取文件
                string sqlText = File.ReadAllText(openFileName, Encoding.GetEncoding("GB2312"));

                this.sqlRtb.AppendText(sqlText);
            }
        }

        /// <summary>
        /// 导出删除索引脚本sql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "sql文件|*.sql|文本文件|*.*";

            sfd.FileName = Path.GetFileNameWithoutExtension(openFileName) + "-删除索引.sql";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                //获取删除索引数据
                string sqlText = this.delIndexRtb.Text;
                //输出删除索引
                File.WriteAllText(localFilePath, sqlText, Encoding.GetEncoding("GB2312"));
            }
        }

        #endregion

        #region 生成二开更新包

        //获取修改当前日期
        private DateTime dt;
        //更新目录
        private string _metadata = "_metadata";
        private string _bin = "bin";

        //更新文件夹
        private string[] updateDirectorys;

        //需要更新的文件信息
        private List<FileInfo> updateFiles;

        /// <summary>
        /// 打开更新的文件目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RootFileBtn_Click(object sender, EventArgs e)
        {
            this.updateFiles = new List<FileInfo>();
            this.updateFilesTV.Nodes.Clear();
            //获取修改当前日期
            dt = DateTime.Parse(DateTime.Parse(this.updateDateTimePicker.Text).ToString("yyyy/MM/dd"));
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
                updateFiles.AddRange(GetMetadataFiles(this.pathTBx.Text));
                updateFiles.AddRange(GetBinFiles(this.pathTBx.Text));

                //获取需要更新的文件夹信息
                foreach (var updateDirectory in updateDirectorys)
                {
                    openFileName = Path.Combine(this.pathTBx.Text, updateDirectory);
                    updateFiles.AddRange(GetUpdateFiles(openFileName));
                }


                IEnumerable<IGrouping<string, FileInfo>> dictionarys = updateFiles.GroupBy(n => n.DirectoryName);
                if (updateFiles != null && updateFiles.Count > 0)
                {
                    foreach (var dictionary in dictionarys)
                    {
                        TreeNode treeNode1 = new TreeNode();
                        treeNode1.Text = dictionary.Key.Replace(this.pathTBx.Text + "\\", "");
                        foreach (var metadataFile in dictionary)
                        {
                            TreeNode treeNode2 = new TreeNode();
                            treeNode2.Text = metadataFile.Name;
                            treeNode1.Nodes.Add(treeNode2);
                        }
                        this.updateFilesTV.Nodes.Add(treeNode1);
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
                foreach (var directoryName in directoryNames)
                {
                    string[] fileNameAppForm = Directory.GetFiles(Path.Combine(openFileName, directoryName));
                    foreach (var fileName in fileNameAppForm)
                    {
                        FileInfo file = new FileInfo(fileName);
                        //判断修改时间是否大于当前时间
                        if (file.LastWriteTime >= dt)
                        {
                            metadataFiles.Add(file);
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
            List<FileInfo> metadataFiles = new List<FileInfo>();
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
                        if (file.LastWriteTime >= dt)
                        {
                            metadataFiles.Add(file);
                        }
                    }
                }
            }
            return metadataFiles;
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
            if (file.LastWriteTime >= dt && file.Name.IndexOf("Fakes") == -1 && file.Name.IndexOf("UnitTest") == -1)
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
            //复制文件
            if (CopyUpdateFile())
            {
                if (this.isTrueCheckoutRadioBtn.Checked)
                {
                    //签出编辑
                    if (Checkout())
                    {
                        MessageBox.Show("复制成功并签出编辑成功！");
                    }
                }
                else
                {
                    this.CopyFilebtn.Enabled = false;
                    this.customizebtn.Enabled = false;
                    MessageBox.Show("复制成功！");
                }
            }
        }

        /// <summary>
        /// 复制更新文件并签出编辑
        /// </summary>
        private bool CopyUpdateFile()
        {
            if (this.updateFiles == null)
            {
                MessageBox.Show("请选择读取产品修改信息！");
                return false;
            }
            //复制文件
            List<FileInfo> removeFiles = new List<FileInfo>();
            foreach (var updateFile in this.updateFiles)
            {
                var directoryName = updateFile.DirectoryName.Replace(this.pathTBx.Text + "\\", "");
                var fileName = Path.Combine(this.customizePathCBX.Text, directoryName, updateFile.Name);
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
                this.updateFiles.Remove(removeFile);
            }
            return true;
        }

        /// <summary>
        /// 签出编辑
        /// </summary>
        private bool Checkout()
        {
            if (this.updateFiles == null)
            {
                MessageBox.Show("请选择产品目录！");
                return false;
            }
            if (this.updateFiles.Count == 0)
            {
                MessageBox.Show("没有需要签入的文件！");
                return false;
            }
            //Tfs帮助类
            TFSHelper tfsHelper = new TFSHelper(Directory.GetParent(this.customizePathCBX.Text).FullName, CustomizeSlnFileName);
            //签出编辑
            foreach (var updateFile in this.updateFiles)
            {
                var directoryName = updateFile.DirectoryName.Replace(this.pathTBx.Text + "\\", "");
                var fileName = Path.Combine(this.customizePathCBX.Text, directoryName, updateFile.Name);
                tfsHelper.CheckOut(fileName);
            }
            return true;
        }

        #endregion

        private void Checkoutbtn_Click(object sender, EventArgs e)
        {
            if (Checkout())
            {
                MessageBox.Show("签出编辑成功！");
            }
            this.CopyFilebtn.Enabled = true;
            this.customizebtn.Enabled = true;
        }

        private void CopyFilebtn_Click(object sender, EventArgs e)
        {
            if (CopyUpdateFile())
            {
                this.CopyFilebtn.Enabled = false;
                this.customizebtn.Enabled = false;
                MessageBox.Show("复制成功！");
            }
        }
    }
}
