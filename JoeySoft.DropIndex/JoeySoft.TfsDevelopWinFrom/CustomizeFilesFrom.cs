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

namespace JoeySoft.TfsDevelopWinFrom
{
    public partial class CustomizeFilesFrom : Form
    {
        public CustomizeFilesFrom(string path, List<FileInfo> _metadataCustomizeFilePath)
        {
            InitializeComponent();

            this.customizeFiletView.Nodes.Clear();

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
                        treeNode1.Nodes.Add(treeNode2);
                    }
                    this.customizeFiletView.Nodes.Add(treeNode1);
                }
            }
        }
    }
}
