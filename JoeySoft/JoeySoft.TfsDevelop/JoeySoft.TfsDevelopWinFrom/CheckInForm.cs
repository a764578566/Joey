using JoeySoft.FromCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JoeySoft.TFS;
using SmartSolutions.Controls;

namespace JoeySoft.TfsDevelopWinFrom
{
    public partial class CheckInForm : Form
    {
        //Tfs帮助类
        private TFSHelper tfsHelper;
        public CheckInForm(string path, string customizeSlnFileName)
        {
            InitializeComponent();
            ConfigureTreeView(path, customizeSlnFileName);
        }

        private void ConfigureTreeView(string path, string customizeSlnFileName)
        {
            this.updateTriSatateTreeView.Nodes.Clear();

            try
            {
                //Tfs帮助类
                tfsHelper = new TFSHelper(Directory.GetParent(path).FullName, customizeSlnFileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            List<FileInfo> fileInfos = tfsHelper.GetPendingChange();

            if (fileInfos != null && fileInfos.Count > 0)
            {
                IEnumerable<IGrouping<string, FileInfo>> dictionarys = fileInfos.GroupBy(n => n.DirectoryName);

                foreach (var dictionary in dictionarys)
                {
                    TriStateTreeNode treeNode1 = new TriStateTreeNode();
                    treeNode1.Text = dictionary.Key.Replace(path + "\\", "");
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
            }
        }

        /// <summary>
        /// 签入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkInbtn_Click(object sender, EventArgs e)
        {
            if (tfsHelper != null)
            {
                List<FileInfo> fileInfos = TriStateTreeNodeHelper.GetTreeNodeChecked(this.updateTriSatateTreeView.Nodes);

                if (fileInfos.Count == 0)
                {
                    MessageBox.Show("没有要签入的文件！");
                    return;
                }

                if (string.IsNullOrEmpty(this.remarktbx.Text))
                {
                    MessageBox.Show("请输入签入说明！");
                    return;
                }

                try
                {
                    if (tfsHelper.CheckIn(fileInfos, this.remarktbx.Text) == false)
                    {
                        MessageBox.Show("有文件没有签入，请打开VS查看详情！");
                        return;
                    }
                    else
                    {
                        JoeyLog.Logging.WriteLog("签入成功！说明：" + this.remarktbx.Text);
                        MessageBox.Show("签入成功！");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    JoeyLog.Logging.WriteErrorLog(ex);
                    MessageBox.Show("可能有冲突，请打开VS解决冲突！");
                }
            }
        }

        /// <summary>
        /// 撤销挂起的更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undobtn_Click(object sender, EventArgs e)
        {
            if (tfsHelper != null)
            {
                List<FileInfo> fileInfos = TriStateTreeNodeHelper.GetTreeNodeChecked(this.updateTriSatateTreeView.Nodes);

                if (fileInfos.Count == 0)
                {
                    MessageBox.Show("没有要撤销的文件！");
                    return;
                }

                try
                {
                    if (tfsHelper.Undo(fileInfos) == false)
                    {
                        MessageBox.Show("有文件没有撤销，请打开VS查看详情！");
                        return;
                    }
                    else
                    {
                        JoeyLog.Logging.WriteLog("撤销成功！");
                        MessageBox.Show("撤销成功！");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    JoeyLog.Logging.WriteErrorLog(ex);
                    MessageBox.Show("可能有冲突，请打开VS解决冲突！");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tfsHelper.GetHistory();
        }
    }
}
