using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace JoeySoft.Framework.CreateIndex
{
    internal class Program
    {
        private static string application = "0221";

        //材料、采招、计划、售楼、成本
        private static Dictionary<string, string> applications = new Dictionary<string, string>();

        //当前目录
        private static string currentDirectoryPath = Environment.CurrentDirectory;

        private static void Main(string[] args)
        {
            applications.Add("0221", "材料系统");
            applications.Add("0220", "采招系统");
            applications.Add("0202", "计划系统");
            applications.Add("0011", "售楼系统");
            applications.Add("0201", "成本系统");
            //站点根目录
            string rootPath = Environment.CurrentDirectory;

            if (args.Length > 0)
            {
                if (applications.ContainsKey(args[0]) == false)
                {
                    Console.WriteLine("请输入正确的应用系统编码！");
                    Console.WriteLine("0221 材料 0220 采招 0202 计划 0011 售楼 0201 成本");
                    Console.ReadKey();
                    return;
                }
                application = args[0];
            }
            else
            {
                string code = string.Empty;
                while (code == string.Empty)
                {
                    Console.WriteLine("请输入明源产品应用系统编码！");
                    Console.WriteLine("0221 材料 0220 采招 0202 计划 0011 售楼 0201 成本");
                    code = Console.ReadLine();
                }
                while (applications.ContainsKey(code) == false)
                {
                    Console.WriteLine("请输入正确的应用系统编码！");
                    Console.WriteLine("0221 材料 0220 采招 0202 计划 0011 售楼 0201 成本");
                    code = Console.ReadLine();
                }
            }
            if (args.Length > 1)
            {
                if (Directory.Exists(args[1]) == false)
                {
                    Console.WriteLine("请输入正确系统站点目录！");
                    Console.ReadKey();
                    return;
                }
                rootPath = args[1];
            }

            //元数据文件夹
            string metadataDirectoryName = Path.Combine(rootPath, "_metadata");

            while (Directory.Exists(metadataDirectoryName) == false)
            {
                Console.WriteLine("请在站点目录下运行，或输入正确的站点目录！");
                //Console.WriteLine("在当前目录（" + rootPath + "）下没有找到元数据文件夹（_metadata）！");
                metadataDirectoryName = Path.Combine(Console.ReadLine(), "_metadata");
            }

            //实体元数据文件夹
            string entityDirectoryName = Path.Combine(metadataDirectoryName, "Entity");
            string[] entityFiles = Directory.GetFiles(entityDirectoryName);

            //视图元数据文件夹
            string viewDirectoryName = Path.Combine(metadataDirectoryName, "View");
            string[] viewFiles = Directory.GetFiles(viewDirectoryName);

            //关联关系元数据文件夹
            string metadataRelationshipDirectoryName = Path.Combine(metadataDirectoryName, "MetadataRelationship");
            string[] metadataRelationshipFiles = Directory.GetFiles(metadataRelationshipDirectoryName);

            List<MetadataRelationship> metadataRelationships = new List<MetadataRelationship>();
            foreach (var metadataRelationshipFile in metadataRelationshipFiles)
            {
                metadataRelationships.Add(XmlHelper.DeserializeFilePath<MetadataRelationship>(metadataRelationshipFile));
            }
            metadataRelationships = metadataRelationships.Where(n => n.Application == application).ToList();


            List<MetadataEntity> metadataEntitys = new List<MetadataEntity>();
            foreach (var entityFile in entityFiles)
            {
                metadataEntitys.Add(XmlHelper.DeserializeFilePath<MetadataEntity>(entityFile));
            }

            List<ViewMetadata> viewMetadatas = new List<ViewMetadata>();
            foreach (var viewFile in viewFiles)
            {
                viewMetadatas.Add(XmlHelper.DeserializeFilePath<ViewMetadata>(viewFile));
            }


            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();
            int count = 1;
            foreach (var metadataRelationship in metadataRelationships)
            {
                if (metadataRelationship.Type == "OneToMore" || metadataRelationship.Type == "OneToOne")
                {
                    MetadataEntity metadataEntity = metadataEntitys.FirstOrDefault(n => n.EntityId == metadataRelationship.RelatedEntityId);
                    if (metadataEntity == null)
                    {
                        continue;
                    }

                    MetadataAttribute metadataAttribute = metadataEntity.Attributes.FirstOrDefault(n => n.AttributeId == metadataRelationship.RelatedAttributeId);
                    string tableName = metadataEntity.Name.Replace("cl_", "").Replace("cb_", "").Replace("cg", "").Replace("Cg", "").Replace("jh_", "").Replace("p_", "").Replace("s_", "").Replace("x_", "");
                    string IndexName = $"IDX_{tableName}_{metadataAttribute.Name}";
                    //如果是主键就不创建索引直接返回
                    if (tableName + "GUID" == metadataAttribute.Name)
                    {
                        continue;
                    }
                    if (Dictionary.ContainsKey(IndexName) == false)
                    {
                        Dictionary.Add(IndexName, $@"--{count++}.{metadataEntity.DisplayName}添加{metadataAttribute.DisplayName}索引
IF NOT EXISTS(select * from sysindexes where id=object_id('{metadataEntity.Name}') and name='{IndexName}')
CREATE NONCLUSTERED INDEX {IndexName} ON {metadataEntity.Name}({metadataAttribute.Name});");
                    }

                    if (metadataRelationship.Type == "OneToOne")
                    {
                        metadataEntity = metadataEntitys.FirstOrDefault(n => n.EntityId == metadataRelationship.PrimaryEntityId);
                        if (metadataEntity == null)
                        {
                            continue;
                        }

                        metadataAttribute = metadataEntity.Attributes.FirstOrDefault(n => n.AttributeId == metadataRelationship.PrimaryAttributeId);
                        tableName = metadataEntity.Name.Replace("cl_", "").Replace("cb_", "").Replace("cg", "").Replace("Cg", "").Replace("jh_", "").Replace("p_", "").Replace("s_", "").Replace("x_", "");
                        IndexName = $"IDX_{tableName}_{metadataAttribute.Name}";
                        //如果是主键就不创建索引直接返回
                        if (tableName + "GUID" == metadataAttribute.Name)
                        {
                            continue;
                        }
                        if (Dictionary.ContainsKey(IndexName) == false)
                        {
                            Dictionary.Add(IndexName, $@"--{count++}.{metadataEntity.DisplayName}添加{metadataAttribute.DisplayName}索引
IF NOT EXISTS(select * from sysindexes where id=object_id('{metadataEntity.Name}') and name='{IndexName}')
CREATE NONCLUSTERED INDEX {IndexName} ON {metadataEntity.Name}({metadataAttribute.Name});");
                        }
                    }
                }
                else if (metadataRelationship.Type == "MoreToOne")
                {
                    MetadataEntity metadataEntity = metadataEntitys.FirstOrDefault(n => n.EntityId == metadataRelationship.PrimaryEntityId);
                    if (metadataEntity == null)
                    {
                        continue;
                    }
                    MetadataAttribute metadataAttribute = metadataEntity.Attributes.FirstOrDefault(n => n.AttributeId == metadataRelationship.RelatedAttributeId);
                    string tableName = metadataEntity.Name.Replace("cl_", "").Replace("cb_", "").Replace("cg", "").Replace("Cg", "").Replace("jh_", "").Replace("p_", "").Replace("s_", "").Replace("x_", "");
                    string IndexName = $"IDX_{tableName}_{metadataAttribute.Name}";
                    //如果是主键就不创建索引直接返回
                    if (tableName + "GUID" == metadataAttribute.Name)
                    {
                        continue;
                    }
                    if (Dictionary.ContainsKey(IndexName) == false)
                    {
                        Dictionary.Add(IndexName, $@"--{count++}.{metadataEntity.DisplayName}添加{metadataAttribute.DisplayName}索引
IF NOT EXISTS(select * from sysindexes where id=object_id('{metadataEntity.Name}') and name='{IndexName}')
CREATE NONCLUSTERED INDEX {IndexName} ON {metadataEntity.Name}({metadataAttribute.Name});");
                    }
                }
            }
            foreach (var item in Dictionary)
            {
                sb.AppendLine(item.Value);
                sb.AppendLine();
            }

            File.WriteAllText(Path.Combine(currentDirectoryPath, applications[application] + "CreateIndex.sql"), sb.ToString(), Encoding.GetEncoding("GB2312"));

            Console.WriteLine("已经在当前目录下生成" + applications[application] + "CreateIndex.sql文件！");
        }
    }
}
