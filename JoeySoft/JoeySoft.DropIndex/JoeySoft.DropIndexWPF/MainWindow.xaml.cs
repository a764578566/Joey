using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace JoeySoft.DropIndexWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string textTemplateSqlText;

        private string DeleteIndexDirectory = "DeleteIndexSql";

        private string openFileName;

        private string regexStr = @"--(.*)(\r\n)+IF\s+NOT\s+EXISTS\s*\(.+\)\s*(\r\n)*CREATE\s+[a-zA-Z\s]+INDEX\s+([1-9a-zA-Z_]+)\s+ON\s+([1-9a-zA-Z_\[.\]]+)\s*\(";


        public MainWindow()
        {
            InitializeComponent();

            textTemplateSqlText = File.ReadAllText("TextTemplate.txt");

            //如果目录不存在 创建
            if (!Directory.Exists(DeleteIndexDirectory))
            {
                Directory.CreateDirectory(DeleteIndexDirectory);
            }
        }

        /// <summary>
        /// 打开脚本事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenIndexSqlFileBtn_Click(object sender, RoutedEventArgs e)
        {
            this.sqlRtb.Document.Blocks.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sql文件|*.sql|文本文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = @"F:\公司文档\clerp\01 SQL提交\02 SQL提交-重构V1.0\性能优化脚本";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog().Value == true)
            {
                this.IndexCountLabel.Content = "0";

                openFileName = openFileDialog.FileName;
                this.filePathTbx.Text = openFileName;
                //读取文件
                string sqlText = File.ReadAllText(openFileName, Encoding.GetEncoding("GB2312"));

                var maths = Regex.Matches(sqlText, regexStr, RegexOptions.IgnoreCase);
                if (maths.Count > 0)
                {
                    this.IndexCountLabel.Content = (int.Parse(this.IndexCountLabel.Content.ToString()) + maths.Count).ToString();
                }
                Paragraph paragraph = new Paragraph();
                Run r = new Run(sqlText);
                paragraph.Inlines.Add(r);
                this.sqlRtb.Document.Blocks.Add(paragraph);
            }
        }

        /// <summary>
        /// 生成删除索引脚本事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteIndexbtn_Click(object sender, RoutedEventArgs e)
        {
            TextRange documentTextRange = new TextRange(sqlRtb.Document.ContentStart, sqlRtb.Document.ContentEnd);
            //读取文件
            string sqlText = documentTextRange.Text;
            if (string.IsNullOrEmpty(sqlText))
            {
                return;
            }
            this.delIndexRtb.Document.Blocks.Clear();
            this.DeleteIndexCountLabel.Content = "0";
            var maths = Regex.Matches(sqlText, regexStr, RegexOptions.IgnoreCase);
            if (maths.Count > 0)
            {
                Paragraph paragraph = new Paragraph();
                for (int i = 0; i < maths.Count; i++)
                {
                    if (maths[i].Groups.Count > 3)
                    {
                        var textSqlText = string.Format(textTemplateSqlText, maths[i].Groups[4].Value, maths[i].Groups[5].Value, "删除" + maths[i].Groups[1].Value);
                        Run r = new Run(textSqlText + "\r\n");
                        paragraph.Inlines.Add(r);
                        this.DeleteIndexCountLabel.Content = (int.Parse(this.DeleteIndexCountLabel.Content.ToString()) + 1).ToString();
                    }
                }
                this.delIndexRtb.Document.Blocks.Add(paragraph);
            }
        }

        /// <summary>
        /// 导出脚本删除索引脚本事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "sql文件|*.sql|文本文件|*.*";

            sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(openFileName) + "-删除索引.sql";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog().Value)
            {
                //获得文件路径 
                string localFilePath = sfd.FileName.ToString(); 
                //获取删除索引数据
                TextRange documentTextRange = new TextRange(sqlRtb.Document.ContentStart, sqlRtb.Document.ContentEnd);
                string sqlText = documentTextRange.Text;
                //输出删除索引
                File.WriteAllText(localFilePath, sqlText, Encoding.GetEncoding("GB2312"));
            }
        }

        /// <summary>
        /// 鼠标拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
