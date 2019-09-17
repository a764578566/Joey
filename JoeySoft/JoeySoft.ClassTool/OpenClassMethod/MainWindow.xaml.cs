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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace OpenClassMethod
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml");
            this.XmlFileCmbox.ItemsSource = files;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.XmlFileCmbox.SelectedIndex == -1)
            {
                return;
            }
            XmlDocument xmlDoc = new XmlDocument();

            var nameSpace = System.IO.Path.GetFileNameWithoutExtension(this.XmlFileCmbox.SelectedItem.ToString());

            xmlDoc.Load(this.XmlFileCmbox.SelectedItem.ToString());

            string className = this.MethodNameTbox.Text;

            var list = xmlDoc.SelectNodes($"/doc/members/member[starts-with(@name,'M:{nameSpace}.AppServices.{className}AppService')]");

            int i = 1;

            this.MethodNamesTbox.Clear();

            StringBuilder showStr = new StringBuilder();

            showStr.AppendLine("AppService");

            foreach (XmlNode item in list)
            {

                string method = item.Attributes["name"].InnerText.Replace($"M:{nameSpace}.AppServices.{className}AppService.", "");

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

            var list2 = xmlDoc.SelectNodes($"/doc/members/member[starts-with(@name,'M:{nameSpace}.DomainServices.{className}DomainService')]");

            int j = 1;
            showStr.AppendLine();
            showStr.AppendLine("DomainService");

            foreach (XmlNode item in list2)
            {

                string method = item.Attributes["name"].InnerText.Replace($"M:{nameSpace}.DomainServices.{className}DomainService.", "");
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

            this.MethodNamesTbox.Text = showStr.ToString();
        }
    }
}
