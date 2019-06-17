using JoeySoft.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace 文件打产品标识
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = this.rootPath.Text;
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.rootPath.Text = folderBrowserDialog.SelectedPath;
                //LoadFunctionPag(this.rootPath.Text, myApplication);
            }
        }

        private void LoadMetadata(string webRootPath)
        {
            //元数据文件夹
            string metadataDirectoryName = System.IO.Path.Combine(webRootPath);

            if (metadataDirectoryName.Contains("_metadata") == false)
            {
                System.Windows.MessageBox.Show("请在选择正确的元数据目录！");
                return;
            }
            DirectoryInfo di = new DirectoryInfo(metadataDirectoryName);

            List<FileInfo> fileInfos = new List<FileInfo>();

            foreach (var item in di.GetDirectories())
            {
                fileInfos.AddRange(item.GetFiles().ToList());
            }
            fileInfos.AddRange(di.GetFiles().ToList());

            FileInfo[] infos = fileInfos.ToArray();
            FileHelper.SortAsFileCreationTime(ref infos);

            fileInfos = new List<FileInfo>();

            foreach (var item in infos)
            {
                if (item.FullName.Contains("settings.metadata.config") == true || item.FullName.Contains("PagesTemplates") == true)
                {
                    continue;
                }
                fileInfos.Add(item);
            }

            GridComboBox.ItemsSource = fileInfos;
            GridComboBox.DisplayMemberPath = "Name";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.rootPath.Text) == false)
            {
                LoadMetadata(this.rootPath.Text);
            }
        }

        private void RootPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.rootPath.Text) == false)
            {
                LoadMetadata(this.rootPath.Text);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.GridComboBox.SelectedIndex >= 0)
            {
                XmlDocument xmlDoc = new XmlDocument();
                var file = (FileInfo)this.GridComboBox.SelectedItem;

                xmlDoc.Load(file.FullName);

                XmlNode xmlNode = xmlDoc.LastChild;

                if (xmlNode.Attributes["application"] == null)
                {
                    XmlHelper.ModifyAttribute(file.FullName, xmlNode.Name, "application", this.application.Text);
                }
                System.Windows.MessageBox.Show("单个新增成功！");
            }
            else
            {
                System.Windows.MessageBox.Show("请在选择要修改的元数据！");
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string metadataDirectoryName = System.IO.Path.Combine(this.rootPath.Text);

            if (metadataDirectoryName.Contains("_metadata") == false)
            {
                System.Windows.MessageBox.Show("请在选择正确的元数据目录！");
                return;
            }

            DirectoryInfo di = new DirectoryInfo(metadataDirectoryName);

            List<FileInfo> fileInfos = new List<FileInfo>();

            foreach (var item in di.GetDirectories())
            {
                fileInfos.AddRange(item.GetFiles().ToList());
            }

            fileInfos.AddRange(di.GetFiles().ToList());

            foreach (var fileInfo in fileInfos)
            {
                if (fileInfo.FullName.Contains("settings.metadata.config") == true || fileInfo.FullName.Contains("PagesTemplates") == true)
                {
                    continue;
                }
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.Load(fileInfo.FullName);

                XmlNode xmlNode = xmlDoc.LastChild;

                if (xmlNode.Attributes["application"] == null)
                {
                    XmlHelper.ModifyAttribute(fileInfo.FullName, xmlNode.Name, "application", this.application.Text);
                }
            }
            System.Windows.MessageBox.Show("全部新增成功！");
        }
    }
}
