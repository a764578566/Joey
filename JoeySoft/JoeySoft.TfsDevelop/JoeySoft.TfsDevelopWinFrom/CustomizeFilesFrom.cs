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

            //匹配名称说明
            string regexnameText = "name=\"([\\u4e00-\\u9fa5]+)\"";

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
                        //读取元数据界面名称
                        if (metadataFile.FullName.IndexOf(ConfigClass.x_MetaData) != -1)
                        {
                            XmlDocument xml = new XmlDocument();
                            xml.Load(metadataFile.FullName);
                            XmlNode root = xml.SelectSingleNode("/form");
                            var math2 = Regex.Matches(root.OuterXml, regexnameText, RegexOptions.IgnoreCase);
                            if (math2.Count > 0)
                            {
                                treeNode2.Text += " 界面名称："+ math2[0].Groups[1].Value;
                            }
                        }

                        treeNode1.Nodes.Add(treeNode2);
                    }
                    this.customizeFiletView.Nodes.Add(treeNode1);
                }
            }
        }
    }
}
