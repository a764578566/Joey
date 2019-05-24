using OpenEdit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenEdit
{
    internal class Program
    {
        private static string application = "0221";

        private static void Main(string[] args)
        {
            //站点根目录
            string rootPath = @"E:\mysoft\git\clxt\src\00_根目录";

            //元数据文件夹
            string metadataDirectoryName = Path.Combine(rootPath, "_metadata");

            while (Directory.Exists(metadataDirectoryName) == false)
            {
                Console.WriteLine("请在站点目录下运行，或输入正确的站点目录！");
                //Console.WriteLine("在当前目录（" + rootPath + "）下没有找到元数据文件夹（_metadata）！");
                metadataDirectoryName = Path.Combine(Console.ReadLine(), "_metadata");
            }

            //界面元数据文件夹
            string functionPageDirectoryName = Path.Combine(metadataDirectoryName, "FunctionPage");
            string[] functionPagFiles = Directory.GetFiles(functionPageDirectoryName);

            Dictionary<string, FunctionPage> metadataNotAllowEditFunctionPages = new Dictionary<string, FunctionPage>();

            Dictionary<string, FunctionPage> metadataAllowAllFunctionPages = new Dictionary<string, FunctionPage>();

            Dictionary<string, FunctionPage> metadataAllowAddFunctionPages = new Dictionary<string, FunctionPage>();

            foreach (var metadatafunctionPagFile in functionPagFiles)
            {
                var functionPag = XmlHelper.DeserializeFilePath<FunctionPage>(metadatafunctionPagFile);
                if (functionPag.Application == application)
                {
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
                }
            }

            foreach (var item in metadataNotAllowEditFunctionPages)
            {
                XmlHelper.ModifyAttribute(item.Key, "functionPage", nameof(item.Value.IsAllowEdit), "true");
                XmlHelper.ModifyAttribute(item.Key, "functionPage", nameof(item.Value.EditMode), "AllowAll");
            }

            foreach (var item in metadataAllowAddFunctionPages)
            {
                XmlHelper.ModifyAttribute(item.Key, "functionPage", nameof(item.Value.EditMode), "AllowAll");
            }

        }
    }
}
