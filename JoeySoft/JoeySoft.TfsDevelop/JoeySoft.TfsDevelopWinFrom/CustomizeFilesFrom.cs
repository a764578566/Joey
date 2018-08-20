using JoeySoft.TfsDevelopWinFrom.model;
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
using System.Xml;

namespace JoeySoft.TfsDevelopWinFrom
{
    public partial class CustomizeFilesFrom : Form
    {
        public CustomizeFilesFrom(string path, List<FileInfo> _metadataCustomizeFilePath)
        {
            InitializeComponent();

            this.customizeFiletView.Nodes.Clear();

            //匹配名称
            string regexnameText = "name=\"([\\u4e00-\\u9fa5]+)\"";

            //匹配页面名称
            string regexpageNameText = "pageName=\"([\\u4e00-\\u9fa5]+)\"";

            //匹配表名称
            string regexDisplayNameText = "DisplayName=\"([\\u4e00-\\u9fa5]+)\"";

            IEnumerable<IGrouping<string, FileInfo>> dictionarys = _metadataCustomizeFilePath.GroupBy(n => n.DirectoryName);
            if (_metadataCustomizeFilePath != null && _metadataCustomizeFilePath.Count > 0)
            {
                foreach (var dictionary in dictionarys)
                {
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Text = dictionary.Key.Replace(path + "\\", "");
                    foreach (var metadataFile in dictionary)
                    {
                        TreeNode treeNode2 = new TreeNode();
                        treeNode2.Text = metadataFile.Name;
                        if (metadataFile.FullName.IndexOf(ConfigClass.x_MetaData) != -1)
                        {
                            XmlDocument xml = new XmlDocument();
                            xml.Load(metadataFile.FullName);
                            MatchCollection math2 = null;

                            //读取表实体元数据界面名称
                            if (metadataFile.FullName.IndexOf(ConfigClass.x_MetaData + "\\Entity") != -1)
                            {
                                XmlNode root = xml.SelectSingleNode("/MetadataEntity");
                                math2 = Regex.Matches(root.OuterXml, regexDisplayNameText, RegexOptions.IgnoreCase);
                            }

                            //读取表单元数据界面名称
                            if (metadataFile.FullName.IndexOf(ConfigClass.x_MetaData + "\\AppForm") != -1)
                            {
                                XmlNode root = xml.SelectSingleNode("/form");
                                math2 = Regex.Matches(root.OuterXml, regexnameText, RegexOptions.IgnoreCase);
                            }
                            //读取列表元数据界面名称
                            if (metadataFile.FullName.IndexOf(ConfigClass.x_MetaData + "\\AppGrid") != -1)
                            {
                                XmlNode root = xml.SelectSingleNode("/grid");
                                math2 = Regex.Matches(root.OuterXml, regexnameText, RegexOptions.IgnoreCase);
                            }
                            //读取树列表元数据界面名称
                            if (metadataFile.FullName.IndexOf(ConfigClass.x_MetaData + "\\AppTreeGrid") != -1)
                            {
                                XmlNode root = xml.SelectSingleNode("/treeGrid");
                                math2 = Regex.Matches(root.OuterXml, regexnameText, RegexOptions.IgnoreCase);
                            }

                            //读取主页面元数据界面名称
                            if (metadataFile.FullName.IndexOf(ConfigClass.x_MetaData + "\\FunctionPage") != -1)
                            {
                                XmlNode root = xml.SelectSingleNode("/functionPage");
                                math2 = Regex.Matches(root.OuterXml, regexpageNameText, RegexOptions.IgnoreCase);
                            }

                            if (math2 != null && math2.Count > 0)
                            {
                                treeNode2.Text += " 界面名称：" + math2[0].Groups[1].Value;
                            }
                        }
                        treeNode1.Nodes.Add(treeNode2);
                    }
                    this.customizeFiletView.Nodes.Add(treeNode1);
                }
            }
        }

        private void customizeFiletView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.C)
            {
                TreeNode treeNode = this.customizeFiletView.SelectedNode;
                //复制剪切数据
                Clipboard.SetDataObject(treeNode.Text);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = this.customizeFiletView.SelectedNode;
            //复制剪切数据
            Clipboard.SetDataObject(treeNode.Text);
        }
    }
}
