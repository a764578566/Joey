using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using OpenEdit.WPF.Model;
using System.Configuration;

namespace OpenEdit.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //完全开放页面数量
        private Dictionary<string, FunctionPage> metadataAllowAllFunctionPages { get; set; } = new Dictionary<string, FunctionPage>();

        //不开放页面数量
        private Dictionary<string, FunctionPage> metadataNotAllowEditFunctionPages { get; set; } = new Dictionary<string, FunctionPage>();

        //部分开放页面数量
        private Dictionary<string, FunctionPage> metadataAllowAddFunctionPages { get; set; } = new Dictionary<string, FunctionPage>();

        //ASPX页面数量
        private Dictionary<string, FunctionPage> metadataAspxFunctionPages { get; set; } = new Dictionary<string, FunctionPage>();

        //图标页面数量
        private Dictionary<string, FunctionPage> metadataChartFunctionPages { get; set; } = new Dictionary<string, FunctionPage>();

        //自定义页面数量
        private Dictionary<string, FunctionPage> metadataCustomizeFunctionPages { get; set; } = new Dictionary<string, FunctionPage>();

        //业务参数页面数量
        private Dictionary<string, FunctionPage> metadataParamFunctionPages { get; set; } = new Dictionary<string, FunctionPage>();

        public MainWindow()
        {
            InitializeComponent();
#if  DEBUG
            this.rootPath.Text = defalutRootPath;
#endif
            var myApplications = (ConfigurationManager.GetSection("MyApplications") as MyApplicationConfigurationSection)?.Items.Cast<MyApplication>().ToList();
            this.xtComboBox.ItemsSource = myApplications;
            this.xtComboBox.SelectedIndex = 0;
        }

        private string defalutRootPath = @"E:\mysoft\git\clxt V1.7\clxt\src\00_根目录";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.xtComboBox.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("请选择系统");
                return;
            }
            var myApplication = (MyApplication)this.xtComboBox.SelectedItem;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = this.rootPath.Text;
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.rootPath.Text = folderBrowserDialog.SelectedPath;
                LoadFunctionPag(this.rootPath.Text, myApplication);
            }
        }

        private void LoadFunctionPag(string webRootPath, MyApplication myApplication)
        {
            //元数据文件夹
            string metadataDirectoryName = System.IO.Path.Combine(webRootPath, "_metadata");

            while (Directory.Exists(metadataDirectoryName) == false)
            {
                System.Windows.MessageBox.Show("请在选择正确的正确的站点目录！");
                return;
            }

            //界面元数据文件夹
            string functionPageDirectoryName = System.IO.Path.Combine(metadataDirectoryName, "FunctionPage");
            string[] functionPagFiles = Directory.GetFiles(functionPageDirectoryName);

            //菜单元数据文件夹
            string myFunctionDirectoryName = System.IO.Path.Combine(metadataDirectoryName, "MyFunction");
            string[] myFunctionFiles = Directory.GetFiles(myFunctionDirectoryName);

            List<Guid> myFunctionGuids = new List<Guid>();

            metadataAllowAllFunctionPages = new Dictionary<string, FunctionPage>();
            metadataNotAllowEditFunctionPages = new Dictionary<string, FunctionPage>();
            metadataAllowAddFunctionPages = new Dictionary<string, FunctionPage>();
            metadataAspxFunctionPages = new Dictionary<string, FunctionPage>();
            metadataChartFunctionPages = new Dictionary<string, FunctionPage>();
            metadataCustomizeFunctionPages = new Dictionary<string, FunctionPage>();
            metadataParamFunctionPages = new Dictionary<string, FunctionPage>();
            List<string> applictionCodes = myApplication.ApplictionCode.Split(';').ToList();
            foreach (var metadatafunctionPagFile in functionPagFiles)
            {
                var functionPag = XmlHelper.DeserializeFilePath<FunctionPage>(metadatafunctionPagFile);
                if (applictionCodes.Exists(n => n == functionPag.Application))
                {
                    myFunctionGuids.Add(functionPag.FunctionGUID);
                    if (functionPag.IsAllowEdit == false)
                    {
                        metadataNotAllowEditFunctionPages.Add(metadatafunctionPagFile, functionPag);
                    }
                    else if (functionPag.EditMode == "AllowAdd")
                    {
                        metadataAllowAddFunctionPages.Add(metadatafunctionPagFile, functionPag);
                    }
                    else if (functionPag.EditMode == "AllowAll")
                    {
                        metadataAllowAllFunctionPages.Add(metadatafunctionPagFile, functionPag);
                    }

                    //ASPX界面
                    if (functionPag.PageType == "1")
                    {
                        metadataAspxFunctionPages.Add(metadatafunctionPagFile, functionPag);
                    }
                    else if (functionPag.PageType == "4")
                    {
                        metadataChartFunctionPages.Add(metadatafunctionPagFile, functionPag);
                    }
                    else if (functionPag.PageType == "5")
                    {
                        metadataCustomizeFunctionPages.Add(metadatafunctionPagFile, functionPag);
                    }

                }
            }

            List<MyFunction> metadataMyFunctions = new List<MyFunction>();
            foreach (var myFunctionFile in myFunctionFiles)
            {
                if (myFunctionGuids.Exists(n => System.IO.Path.GetFileName(myFunctionFile).Contains(n.ToString())))
                {
                    metadataMyFunctions.Add(XmlHelper.DeserializeFilePath<MyFunction>(myFunctionFile));
                }
            }

            foreach (var metadataMyFunction in metadataMyFunctions)
            {
                if (metadataMyFunction.FunctionName == "业务参数")
                {
                    foreach (var item in metadataNotAllowEditFunctionPages)
                    {
                        if (item.Value.FunctionGUID == metadataMyFunction.FunctionGuid)
                        {
                            metadataParamFunctionPages.Add(item.Key, item.Value);
                        }
                    }
                    foreach (var item in metadataAllowAddFunctionPages)
                    {
                        if (item.Value.FunctionGUID == metadataMyFunction.FunctionGuid)
                        {
                            metadataParamFunctionPages.Add(item.Key, item.Value);
                        }
                    }
                    foreach (var item in metadataAllowAllFunctionPages)
                    {
                        if (item.Value.FunctionGUID == metadataMyFunction.FunctionGuid)
                        {
                            metadataParamFunctionPages.Add(item.Key, item.Value);
                        }
                    }
                }
            }

            this.Total.Content = metadataNotAllowEditFunctionPages.Count + metadataAllowAddFunctionPages.Count + metadataAllowAllFunctionPages.Count;

            this.AllowAll.Content = metadataAllowAllFunctionPages.Count;
            this.AllowAdd.Content = metadataAllowAddFunctionPages.Count;
            this.NotAllow.Content = metadataNotAllowEditFunctionPages.Count;

            this.Aspx.Content = metadataAspxFunctionPages.Count;
            this.Chart.Content = metadataChartFunctionPages.Count;
            this.Customize.Content = metadataCustomizeFunctionPages.Count;
            this.Param.Content = metadataParamFunctionPages.Count;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (var item in metadataNotAllowEditFunctionPages)
            {
                //不是业务参数页面、不是Aspx界面
                if (metadataParamFunctionPages.ContainsKey(item.Key) == false
                    && metadataAspxFunctionPages.ContainsKey(item.Key) == false
                    && metadataChartFunctionPages.ContainsKey(item.Key) == false)
                {
                    XmlHelper.ModifyAttribute(item.Key, "functionPage", "isAllowEdit", "true");
                    XmlHelper.ModifyAttribute(item.Key, "functionPage", "editMode", "AllowAll");
                    count++;
                }
            }

            foreach (var item in metadataAllowAddFunctionPages)
            {
                //不是业务参数页面、不是Aspx界面
                if (metadataParamFunctionPages.ContainsKey(item.Key) == false && metadataAspxFunctionPages.ContainsKey(item.Key) == false)
                {
                    XmlHelper.ModifyAttribute(item.Key, "functionPage", "editMode", "AllowAll");
                    count++;
                }
            }

            System.Windows.MessageBox.Show("修改成功，一共修改" + count + "个页面的开放程度！");
            LoadFunctionPag(this.rootPath.Text, (MyApplication)this.xtComboBox.SelectedItem);
        }

        private void XtComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.rootPath.Text) != null && Directory.Exists(this.rootPath.Text))
            {
                LoadFunctionPag(this.rootPath.Text, (MyApplication)this.xtComboBox.SelectedItem);
            }
        }
    }
}
