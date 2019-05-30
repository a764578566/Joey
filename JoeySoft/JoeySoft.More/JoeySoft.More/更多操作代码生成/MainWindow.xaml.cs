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

namespace 更多操作代码生成
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            this.itemTextBox.Text = File.ReadAllText("TextFile1.txt");

            this.configTextBox.Text = File.ReadAllText("TextFile2.txt");

            this.groupTextBox.Text = File.ReadAllText("TextFile3.txt");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guid guid0 = Guid.NewGuid();
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();
            this.item1TextBox.Text = string.Format(this.itemTextBox.Text, guid0, guid1, guid2);

            this.config1TextBox.Text = string.Format(this.configTextBox.Text, guid0, guid1, guid2,
                guid3, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            this.group1TextBox.Text = this.groupTextBox.Text.Replace("{0}", guid3.ToString());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.rootPath.Text) == false)
            {
                LoadGrid(this.rootPath.Text);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = this.rootPath.Text;
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.rootPath.Text = folderBrowserDialog.SelectedPath;
                //LoadFunctionPag(this.rootPath.Text, myApplication);
            }
        }

        private void LoadGrid(string webRootPath)
        {
            //元数据文件夹
            string metadataDirectoryName = System.IO.Path.Combine(webRootPath, "_metadata");

            while (Directory.Exists(metadataDirectoryName) == false)
            {
                System.Windows.MessageBox.Show("请在选择正确的正确的站点目录！");
                return;
            }

            //界面元数据文件夹
            string appGridDirectoryName = System.IO.Path.Combine(metadataDirectoryName, "AppGrid");
            //string[] appGridFiles = Directory.GetFiles(appGridDirectoryName);

            DirectoryInfo di = new DirectoryInfo(appGridDirectoryName);

            List<FileInfo> fileInfos = new List<FileInfo>();
            fileInfos.AddRange(di.GetFiles().ToList());

            //菜单元数据文件夹
            string appTreeGridDirectoryName = System.IO.Path.Combine(metadataDirectoryName, "AppTreeGrid");
            //string[] appTreeGridFiles = Directory.GetFiles(appTreeGridDirectoryName);

            DirectoryInfo di2 = new DirectoryInfo(appTreeGridDirectoryName);
            fileInfos.AddRange(di2.GetFiles().ToList());

            FileInfo[] infos = fileInfos.ToArray();
            FileHelper.SortAsFileCreationTime(ref infos);

            fileInfos = new List<FileInfo>();

            foreach (var item in infos)
            {
                if (item.Name.Contains("design"))
                {
                    fileInfos.Add(item);
                }
            }

            GridComboBox.ItemsSource = fileInfos;
            GridComboBox.DisplayMemberPath = "Name";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.GridComboBox.SelectedIndex >= 0)
            {

                XmlDocument xmlDoc = new XmlDocument();
                var file = (FileInfo)this.GridComboBox.SelectedItem;

                string gridName = file.DirectoryName.Contains("AppGrid") ? "grid" : "treeGrid";

                xmlDoc.Load(file.FullName);

                XmlElement mMoreElement = (XmlElement)xmlDoc.SelectSingleNode(gridName + "/layout/toolbars/toolbar[@type='global']/groups/group[@align='right']/items/item[@id='mMore']");
                if (mMoreElement != null)
                {
                    System.Windows.Forms.MessageBox.Show("更多操作菜单按钮，已经添加！");
                    return;
                }

                XmlElement element = (XmlElement)xmlDoc.SelectSingleNode(gridName + "/layout/toolbars/toolbar[@type='global']/groups/group[@align='right']/items");

                Guid guid0 = Guid.NewGuid();
                Guid guid1 = Guid.NewGuid();
                Guid guid2 = Guid.NewGuid();
                Guid guid3 = Guid.NewGuid();
                this.item1TextBox.Text = string.Format(this.itemTextBox.Text, guid0, guid1, guid2);

                this.config1TextBox.Text = string.Format(this.configTextBox.Text, guid0, guid1, guid2,
                    guid3, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

                this.group1TextBox.Text = this.groupTextBox.Text.Replace("{0}", guid3.ToString());

                XmlDocument xmlDoc1 = new XmlDocument();

                TextReader tr = new StringReader(this.item1TextBox.Text);

                xmlDoc1.Load(tr);

                element.AppendChild(xmlDoc.ImportNode(xmlDoc1.SelectSingleNode("item"), true));

                xmlDoc.Save(file.FullName);

                System.Windows.Forms.MessageBox.Show("添加成功！");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (this.GridComboBox.SelectedIndex >= 0)
            {
                XmlDocument xmlDoc = new XmlDocument();
                var file = (FileInfo)this.GridComboBox.SelectedItem;

                string gridName = file.DirectoryName.Contains("AppGrid") ? "grid" : "treeGrid";

                xmlDoc.Load(file.FullName);

                XmlElement mMoreElement = (XmlElement)xmlDoc.SelectSingleNode(gridName + "/layout/toolbars/toolbar[@type='global']/groups/group[@align='right']/items/item[@id='mMore']");
                if (mMoreElement != null)
                {
                    System.Windows.Forms.MessageBox.Show("更多操作菜单按钮，已经添加！");
                    return;
                }

                XmlElement element = (XmlElement)xmlDoc.SelectSingleNode(gridName + "/layout/toolbars/toolbar[@type='global']/groups/group[@align='right']/items");

                Guid guid0 = Guid.NewGuid();
                Guid guid1 = Guid.NewGuid();
                Guid guid2 = Guid.NewGuid();
                Guid guid3 = Guid.NewGuid();
                this.item1TextBox.Text = string.Format(this.itemTextBox.Text, guid0, guid1, guid2);

                this.config1TextBox.Text = string.Format(this.configTextBox.Text, guid0, guid1, guid2,
                    guid3, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

                this.group1TextBox.Text = this.groupTextBox.Text.Replace("{0}", guid3.ToString());

                XmlDocument xmlDocItem = new XmlDocument();

                TextReader tr = new StringReader(this.item1TextBox.Text);

                xmlDocItem.Load(tr);

                element.AppendChild(xmlDoc.ImportNode(xmlDocItem.SelectSingleNode("item"), true));


                //规则配置信息
                XmlElement configsElement = (XmlElement)xmlDoc.SelectSingleNode(gridName + "/layout/rule/configs");

                XmlDocument xmlDocRule = new XmlDocument();

                TextReader trRule = new StringReader(this.config1TextBox.Text);

                xmlDocRule.Load(trRule);
                XmlNode xmlNode = xmlDocRule.SelectSingleNode("root");
                foreach (var ChildNode in xmlNode.ChildNodes)
                {
                    configsElement.AppendChild(xmlDoc.ImportNode(((XmlElement)ChildNode), true));
                }


                //规则组
                XmlElement groupsElement = (XmlElement)xmlDoc.SelectSingleNode(gridName + "/layout/rule/groups");

                XmlDocument xmlDocGroup = new XmlDocument();

                TextReader trGroup = new StringReader(this.group1TextBox.Text);

                xmlDocGroup.Load(trGroup);
                groupsElement.AppendChild(xmlDoc.ImportNode(xmlDocGroup.SelectSingleNode("group"), true));

                xmlDoc.Save(file.FullName);

                System.Windows.Forms.MessageBox.Show("添加成功！");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.rootPath.Text) == false)
            {
                LoadGrid(this.rootPath.Text);
            }
        }
    }
}
