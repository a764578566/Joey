using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace OpenEdit
{
    /// <summary>
    /// xml帮助类
    /// </summary>
    public static class XmlHelper
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
        /// xml属性修改
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="AttributeName"></param>
        /// <param name="value"></param>
        public static void ModifyAttribute(string xmlPath, string nodeName, string AttributeName, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlElement element = (XmlElement)xmlDoc.SelectSingleNode(nodeName);
            element.SetAttribute(AttributeName, value);
            xmlDoc.Save(xmlPath);
        }
    }
}
