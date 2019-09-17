using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.OpenApi.Readers;
using System.IO;
using System.Xml.XPath;
using System.Xml;
using System.Text;

namespace JoeySoft.ClassTool
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("Mysoft.Clgyl.ProjectPrep.xml");

            string className = "ContractProvider";

            var list = xmlDoc.SelectNodes($"/doc/members/member[starts-with(@name,'M:Mysoft.Clgyl.ProjectPrep.AppServices.{className}AppService')]");

            int i = 1;

            StringBuilder showStr = new StringBuilder();

            showStr.AppendLine("AppService");

            foreach (XmlNode item in list)
            {

                string method = item.Attributes["name"].InnerText.Replace($"M:Mysoft.Clgyl.ProjectPrep.AppServices.{className}AppService.", "");

                if (method.IndexOf('(') == -1)
                {
                    showStr.Append(string.Format("{0}.{1}", i++, method));
                }
                else
                {
                    showStr.Append(string.Format("{0}.{1}", i++, method.Substring(0, method.IndexOf('('))));
                }

                showStr.AppendLine(string.Format(" {0}", item.SelectSingleNode("summary").InnerText.Replace("\r\n", "").Replace(" ", "")));
            }

            var list2 = xmlDoc.SelectNodes($"/doc/members/member[starts-with(@name,'M:Mysoft.Clgyl.ProjectPrep.DomainServices.{className}DomainService')]");

            int j = 1;
            showStr.AppendLine();
            showStr.AppendLine("DomainService");

            foreach (XmlNode item in list2)
            {

                string method = item.Attributes["name"].InnerText.Replace($"M:Mysoft.Clgyl.ProjectPrep.DomainServices.{className}DomainService.", "");
                if (method.IndexOf('(') == -1)
                {
                    showStr.Append(string.Format("{0}.{1}", j++, method));
                }
                else
                {
                    showStr.Append(string.Format("{0}.{1}", j++, method.Substring(0, method.IndexOf('('))));
                }

                showStr.AppendLine(string.Format(" {0}", item.SelectSingleNode("summary").InnerText.Replace("\r\n", "").Replace(" ", "")));
            }

            Console.WriteLine(showStr.ToString());

            Console.ReadKey();
        }

    }
}
