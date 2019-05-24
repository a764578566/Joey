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

        //自定义页面数量
        private Dictionary<string, FunctionPage> metadataCustomizeFunctionPages { get; set; } = new Dictionary<string, FunctionPage>();

        //业务参数页面数量
        private Dictionary<string, FunctionPage> metadataParamFunctionPages { get; set; } = new Dictionary<string, FunctionPage>();

        public MainWindow()
        {
            InitializeComponent();
            this.rootPath.Text = defalutRootPath;
            LoadFunctionPag(this.rootPath.Text);
        }

        private string defalutRootPath = @"E:\mysoft\git\clxt V1.7\clxt\src\00_根目录";

        private string application = "0221";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = this.rootPath.Text;
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.rootPath.Text = folderBrowserDialog.SelectedPath;
                LoadFunctionPag(this.rootPath.Text);
            }
        }

        private void LoadFunctionPag(string webRootPath)
        {
            //元数据文件夹
            string metadataDirectoryName = System.IO.Path.Combine(webRootPath, "_metadata");

            while (Directory.Exists(metadataDirectoryName) == false)
            {
                Console.WriteLine("请在站点目录下运行，或输入正确的站点目录！");
                //Console.WriteLine("在当前目录（" + rootPath + "）下没有找到元数据文件夹（_metadata）！");
                metadataDirectoryName = System.IO.Path.Combine(Console.ReadLine(), "_metadata");
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
            metadataCustomizeFunctionPages = new Dictionary<string, FunctionPage>();
            metadataParamFunctionPages = new Dictionary<string, FunctionPage>();

            foreach (var metadatafunctionPagFile in functionPagFiles)
            {
                var functionPag = XmlHelper.DeserializeFilePath<FunctionPage>(metadatafunctionPagFile);
                if (functionPag.Application == application)
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
            this.Customize.Content = metadataCustomizeFunctionPages.Count;
            this.Param.Content = metadataParamFunctionPages.Count;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var item in metadataNotAllowEditFunctionPages)
            {
                //不是业务参数页面、不是Aspx界面
                if (metadataParamFunctionPages.ContainsKey(item.Key) == false && metadataAspxFunctionPages.ContainsKey(item.Key) == false)
                {
                    XmlHelper.ModifyAttribute(item.Key, "functionPage", "isAllowEdit", "true");
                    XmlHelper.ModifyAttribute(item.Key, "functionPage", "editMode", "AllowAll");
                }
            }

            foreach (var item in metadataAllowAddFunctionPages)
            {
                //不是业务参数页面、不是Aspx界面
                if (metadataParamFunctionPages.ContainsKey(item.Key) == false && metadataAspxFunctionPages.ContainsKey(item.Key) == false)
                {
                    XmlHelper.ModifyAttribute(item.Key, "functionPage", "editMode", "AllowAll");
                }
            }

            System.Windows.MessageBox.Show("修改成功！");
        }
    }
}
