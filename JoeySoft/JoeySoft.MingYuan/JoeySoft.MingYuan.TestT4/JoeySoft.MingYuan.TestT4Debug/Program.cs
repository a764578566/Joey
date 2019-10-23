using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JoeySoft.MingYuan.TestT4Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            DomainServiceDebug();

            Console.ReadKey();
        }

        /// <summary>
        /// Appservice调试
        /// </summary>
        public static void AppserviceDebug()
        {
            #region Appservice

            var moduleName = "Clgyl" + "." + "SaleMng";
            var currentPath = @"E:\mysoft\git\clxt\src\06 销售管理\Mysoft.Clgyl.SaleMng.UnitTest";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"E:\mysoft\git\clxt\src\06 销售管理\Mysoft.Clgyl.SaleMng\bin\Mysoft.Clgyl.SaleMng.XML");

            var appPath = currentPath.Substring(0, currentPath.LastIndexOf("."));
            foreach (var item in Directory.GetFiles(Path.Combine(appPath, "AppServices")))
            {
                //WriteLine(item);

                var fileName = Path.GetFileNameWithoutExtension(item) + "Test";

                var entityName = Path.GetFileNameWithoutExtension(item).Replace("AppService", "");


                var classDescriptionNode = xmlDoc.SelectSingleNode($"/doc/members/member[starts-with(@name,'T:Mysoft." + moduleName + ".AppServices." + entityName + "AppService')]");

                var classDescription = string.Format("{0}", classDescriptionNode.SelectSingleNode("summary").InnerText.Replace("\r\n", "").Replace(" ", ""));

                var list = xmlDoc.SelectNodes("/doc/members/member[starts-with(@name,'M:Mysoft." + moduleName + ".AppServices." + entityName + "AppService')]");

                List<string> methodNames = new List<string>();
                List<string> descriptions = new List<string>();

                foreach (XmlNode node in list)
                {
                    string method = node.Attributes["name"].InnerText.Replace("M:Mysoft." + moduleName + ".AppServices." + entityName + "AppService.", "");
                    if (method.IndexOf('(') == -1)
                    {
                        methodNames.Add(string.Format("{0}", method));
                    }
                    else
                    {
                        methodNames.Add(string.Format("{0}", method.Substring(0, method.IndexOf('('))));
                    }

                    descriptions.Add(string.Format("{0}", node.SelectSingleNode("summary").InnerText.Replace("\r\n", "").Replace(" ", "")));
                }

                var list2 = xmlDoc.SelectNodes($"/doc/members/member[starts-with(@name,'F:Mysoft." + moduleName + ".AppServices." + entityName + "AppService.')]");

                List<string> publicServiceNames = new List<string>();
                List<string> domainServiceNames = new List<string>();

                List<string> testMockServiceResolvers = new List<string>();

                foreach (XmlNode node in list2)
                {
                    //_projectOverviewDomainService
                    string name = node.Attributes["name"].InnerText.Replace($"F:Mysoft." + moduleName + ".AppServices." + entityName + "AppService.", "");
                    if (name.IndexOf("_i") == -1)
                    {
                        if (name.ToLower().IndexOf("domainservice") != -1)
                        {
                            string str = name.Replace("_", "");
                            str = str[0].ToString().ToUpper() + str.Substring(1, str.Length - 1);
                            domainServiceNames.Add(string.Format("private readonly Stub{0} {1} = new Stub{0}();", str, name));
                            testMockServiceResolvers.Add(string.Format("TestMockServiceResolver.RegisterInstance<{0}, Stub{0}>({1});", str, name));
                        }
                        else if (name.ToLower().IndexOf("aggregateservice") != -1)
                        {
                            string str = name.Replace("_", "");
                            str = str[0].ToString().ToUpper() + str.Substring(1, str.Length - 1);
                            domainServiceNames.Add(string.Format("private readonly Stub{0} {1} = new Stub{0}();", str, name));
                            testMockServiceResolvers.Add(string.Format("TestMockServiceResolver.RegisterInstance<{0}, Stub{0}>({1});", str, name));
                        }
                    }
                    else
                    {
                        string str = name.Replace("_", "");
                        str = str[0].ToString().ToUpper() + str.Substring(1, str.Length - 1);
                        publicServiceNames.Add(string.Format("private readonly Stub{0} {1} = new Stub{0}();", str, name));
                        testMockServiceResolvers.Add(string.Format("TestMockServiceResolver.RegisterInstance<{0}, Stub{0}>({1});", str, name));
                    }
                }

            }
            #endregion
        }

        /// <summary>
        /// DomainService调试
        /// </summary>
        public static void DomainServiceDebug()
        {
            #region DomainService

            var serviceNames = new string[] { "AggregateService", "DomainService" };

            var moduleName = "Clgyl" + "." + "SaleMng";
            var currentPath = @"E:\mysoft\git\clxt\src\06 销售管理\Mysoft.Clgyl.SaleMng.UnitTest";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"E:\mysoft\git\clxt\src\06 销售管理\Mysoft.Clgyl.SaleMng\bin\Mysoft.Clgyl.SaleMng.XML");


            var appPath = currentPath.Substring(0, currentPath.LastIndexOf("."));

            foreach (var item in Directory.GetFiles(Path.Combine(appPath, "DomainServices")))
            {
                foreach (var serviceName in serviceNames)
                {

                    var fileName = Path.GetFileNameWithoutExtension(item) + "Test";
                    var entityName = Path.GetFileNameWithoutExtension(item).Replace(serviceName, "");

                    var classDescriptionNode = xmlDoc.SelectSingleNode($"/doc/members/member[starts-with(@name,'T:Mysoft." + moduleName + ".DomainServices." + entityName + serviceName + "')]");

                    if (classDescriptionNode == null)
                    {
                        continue;
                    }
                    var classDescription = string.Format("{0}", classDescriptionNode.SelectSingleNode("summary").InnerText.Replace("\r\n", "").Replace(" ", ""));

                    var list = xmlDoc.SelectNodes("/doc/members/member[starts-with(@name,'M:Mysoft." + moduleName + ".DomainServices." + entityName + serviceName + "')]");

                    List<string> methodNames = new List<string>();
                    List<string> descriptions = new List<string>();

                    foreach (XmlNode node in list)
                    {
                        string method = node.Attributes["name"].InnerText.Replace("M:Mysoft." + moduleName + ".DomainServices." + entityName + serviceName + ".", "");
                        if (method.IndexOf('(') == -1)
                        {
                            methodNames.Add(string.Format("{0}", method));
                        }
                        else
                        {
                            methodNames.Add(string.Format("{0}", method.Substring(0, method.IndexOf('('))));
                        }

                        descriptions.Add(string.Format("{0}", node.SelectSingleNode("summary").InnerText.Replace("\r\n", "").Replace(" ", "")));
                    }

                    var list2 = xmlDoc.SelectNodes($"/doc/members/member[starts-with(@name,'F:Mysoft." + moduleName + ".DomainServices." + entityName + serviceName + ".')]");

                    List<string> publicServiceNames = new List<string>();
                    List<string> domainServiceNames = new List<string>();
                    List<string> entityServiceNames = new List<string>();
                    List<string> fileJsonNames = new List<string>();
                    List<string> loadDataJsons = new List<string>();

                    List<string> testMockServiceResolvers = new List<string>();

                    foreach (XmlNode node in list2)
                    {

                        //_projectOverviewDomainService
                        string name = node.Attributes["name"].InnerText.Replace($"F:Mysoft." + moduleName + ".DomainServices." + entityName + serviceName + ".", "");
                        if (name.IndexOf("_i") == -1)
                        {
                            foreach (var itemName in serviceNames)
                            {
                                if (name.ToLower().IndexOf(itemName.ToLower()) != -1)
                                {
                                    string str = name.Replace("_", "");
                                    str = str[0].ToString().ToUpper() + str.Substring(1, str.Length - 1);
                                    domainServiceNames.Add(string.Format("private readonly Stub{0} {1} = new Stub{0}();", str, name));
                                    testMockServiceResolvers.Add(string.Format("TestMockServiceResolver.RegisterInstance<{0}, Stub{0}>({1});", str, name));
                                }
                            }
                            if (name.IndexOf("EntityService") != -1)
                            {
                                string str = name.Replace("_", "").Replace("EntityService", "");
                                str = str[0].ToString().ToUpper() + str.Substring(1, str.Length - 1);
                                entityServiceNames.Add(string.Format("private readonly EntityMocker<{0}> {1}Mock = new EntityMocker<{0}>();", str, name.Replace("EntityService", "")));
                                fileJsonNames.Add(string.Format("private readonly string {0}FileJsonName = \"{1}.json\";", name.Replace("EntityService", ""), str));
                                loadDataJsons.Add(string.Format("{0}Mock.LoadData({0}FileJsonName);", name.Replace("EntityService", "")));
                            }
                        }
                        else
                        {
                            string str = name.Replace("_", "");
                            str = str[0].ToString().ToUpper() + str.Substring(1, str.Length - 1);
                            publicServiceNames.Add(string.Format("private readonly Stub{0} {1} = new Stub{0}();", str, name));
                            testMockServiceResolvers.Add(string.Format("TestMockServiceResolver.RegisterInstance<{0}, Stub{0}>({1});", str, name));
                        }
                    }

                }
            }
            #endregion
        }
    }
}
