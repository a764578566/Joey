using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoeySoft.DropIndexWinFrom
{
    public partial class DeleteIndexFrom : Form
    {
        #region 生成删除索引
        private static string textTemplateSqlText;

        private string DeleteIndexDirectory = "DeleteIndexSql";

        private string openFileName;


        public DeleteIndexFrom()
        {
            InitializeComponent();

            textTemplateSqlText = File.ReadAllText("TextTemplate.txt");

            this.updateDateTimePicker.Text = DateTime.Now.ToString("yyyy-MM-dd");

            //如果目录不存在 创建
            if (!Directory.Exists(DeleteIndexDirectory))
            {
                Directory.CreateDirectory(DeleteIndexDirectory);
            }
            this.customizePathTBx.Text = rootCustomizePath;
            FileUserHelper.SetAccess("Users", rootCustomizePath);
            //是否直接复制到指定目录 否
            this.isFalseCopyRadioBtn.Select();
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
        private string _clgyl = "Clgyl";
        private string _bin = "bin";

        //产品地址
        string rootProductPath = @"E:\mysoft\tfs_new\10.5.10.96\WH-ProductDev\住宅ERP-新平台\ERP-V1.0\60_材料供应链系统\03_主干-开发分支\00_根目录";
        //二开地址
        private string rootCustomizePath = @"E:\mysoft\tfs_new\10.5.10.70\星河二开项目\总部星河\明源云ERPv1.0SP5星河孵化\源代码\分支1\00-ERP站点";

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
            //选择文件夹
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = rootProductPath;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //选择的文件夹
                string openFileName = folderBrowserDialog.SelectedPath;
                this.pathTBx.Text = openFileName;
                if (!File.Exists(openFileName + "\\Web.config"))
                {
                    MessageBox.Show("请选择产品根目录！");
                }
                else
                {
                    updateFiles.AddRange(GetMetadataFiles(openFileName));
                    updateFiles.AddRange(GetClgylJsFiles(openFileName));
                    updateFiles.AddRange(GetBinFiles(openFileName));

                    IEnumerable<IGrouping<string, FileInfo>> dictionarys = updateFiles.GroupBy(n => n.DirectoryName);
                    if (updateFiles != null && updateFiles.Count > 0)
                    {
                        foreach (var dictionary in dictionarys)
                        {
                            TreeNode treeNode1 = new TreeNode();
                            treeNode1.Text = dictionary.Key.Replace(openFileName + "\\", "");
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
                            foreach (var updateFile in this.updateFiles)
                            {
                                var directoryName = updateFile.DirectoryName.Replace(this.pathTBx.Text + "\\", "");
                                var fileName = Path.Combine(this.customizePathTBx.Text, directoryName, updateFile.Name);

                                if (File.Exists(fileName))
                                {
                                    File.Delete(fileName);
                                }
                                File.Copy(updateFile.FullName, fileName);
                            }
                            MessageBox.Show("复制成功！");
                        }
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

            string[] directoryNames = new string[]
            {
                "AppForm", //表单
                "AppGrid", //列表
                "AppTreeGrid", //树列表
                "AppCard", //卡片
                "Entity", //实体
                "View", //视图
                "MetadataRelationship" //关系
            };
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
        /// 获取js信息
        /// </summary>
        /// <param name="openFileName"></param>
        /// <returns></returns>
        private List<FileInfo> GetClgylJsFiles(string openFileName)
        {
            openFileName = Path.Combine(openFileName, _clgyl);
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
                        //判断修改时间是否大于当前时间
                        if (file.LastWriteTime >= dt && file.Name.IndexOf("Fakes") == -1 && file.Name.IndexOf("UnitTest") == -1)
                        {
                            if (file.Name.IndexOf("Web_Clgyl") == -1 && file.Name.IndexOf("License.xml") == -1)
                            {
                                metadataFiles.Add(file);
                            }
                        }
                    }
                }

            }
            return metadataFiles;
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
            if (string.IsNullOrEmpty(this.customizePathTBx.Text))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.SelectedPath = rootCustomizePath;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //选择的文件夹
                    string openFileName = folderBrowserDialog.SelectedPath;
                    FileUserHelper.SetAccess("Users", openFileName);
                    this.customizePathTBx.Text = openFileName;
                    if (!File.Exists(openFileName + "\\Web.config"))
                    {
                        MessageBox.Show("请选择二开根目录！");
                    }
                    else
                    {
                        foreach (var updateFile in this.updateFiles)
                        {
                            var directoryName = updateFile.DirectoryName.Replace(this.pathTBx.Text, "");
                            var path = Path.Combine(openFileName, directoryName, updateFile.Name);
                            File.Copy(updateFile.FullName, path, true);
                        }
                    }
                }
            }
            else
            {
                foreach (var updateFile in this.updateFiles)
                {
                    var directoryName = updateFile.DirectoryName.Replace(this.pathTBx.Text + "\\", "");
                    var fileName = Path.Combine(this.customizePathTBx.Text, directoryName, updateFile.Name);

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    File.Copy(updateFile.FullName, fileName);
                }
                MessageBox.Show("复制成功！");
            }
        }

        #endregion

    }
}
