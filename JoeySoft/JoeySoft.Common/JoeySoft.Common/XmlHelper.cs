using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace JoeySoft.Common
{
    /// <summary>
    /// Xml帮助类
    /// </summary>
    public class XmlHelper
    {
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="path">XML文件地址</param>  
        /// <returns></returns>  
        public static T DeserializeFilePath<T>(string path)
        {
            using (System.IO.FileStream stream = new FileStream(path, FileMode.Open))
            {
                return Deserialize<T>(stream);
            }
        }

        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="xml">XML字符串</param>  
        /// <returns></returns>  
        public static T Deserialize<T>(string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(typeof(T));
                return (T)xmldes.Deserialize(sr);
            }
        }

        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type"></param>  
        /// <param name="xml"></param>  
        /// <returns></returns>  
        public static T Deserialize<T>(Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(typeof(T));
            return (T)xmldes.Deserialize(stream);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer<T>(T obj)
        {
            StringBuilder str = new StringBuilder();
            using (MemoryStream Stream = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                //序列化对象
                xml.Serialize(Stream, obj);
                Stream.Position = 0;
                using (StreamReader sr = new StreamReader(Stream))
                {
                    str.Append(sr.ReadToEnd());
                }
            }
            return str.ToString();
        }



        /// <summary>
        /// 新增或修改xml属性，不存在属性新增，存在属性修改
        /// </summary>
        /// <param name="xmlPath">xml地址</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="AttributeName">属性名称</param>
        /// <param name="value">属性值</param>
        public static void ModifyAttribute(string xmlPath, string nodeName, string AttributeName, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlElement element = (XmlElement)xmlDoc.SelectSingleNode(nodeName);
            element.SetAttribute(AttributeName, value);
            xmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// 在Xml节点下新增Xml文本数据
        /// </summary>
        /// <param name="xmlDoc">xml文档</param>
        /// <param name="xmlText">新增的Xml文本数据</param>
        /// <param name="NodeName">Xml节点名称</param>
        public static void AppendChild(XmlDocument xmlDoc, string xmlText, string NodeName)
        {
            //规则组
            XmlElement element = (XmlElement)xmlDoc.SelectSingleNode(NodeName);

            XmlDocument xmlDocTemp = new XmlDocument();

            TextReader trRoot = new StringReader("<root>" + xmlText + "</root>");

            xmlDocTemp.Load(trRoot);
            XmlNode xmlNode = xmlDocTemp.SelectSingleNode("root");
            foreach (var ChildNode in xmlNode.ChildNodes)
            {
                element.AppendChild(xmlDoc.ImportNode((XmlElement)ChildNode, true));
            }
        }
    }
}
