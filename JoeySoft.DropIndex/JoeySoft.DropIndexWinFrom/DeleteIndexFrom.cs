using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoeySoft.DropIndexWinFrom
{
    public partial class DeleteIndexFrom : Form
    {
        #region 生成删除索引
        private static string textTemplateSqlText;

        private string DeleteIndexDirectory = "DeleteIndexSql";

        private string openFileName;


        public DeleteIndexFrom()
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
        /// 生成删除索引按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteIndexbtn_Click(object sender, EventArgs e)
        {
            //读取文件
            string sqlText = this.sqlRtb.Text;
            if (string.IsNullOrEmpty(sqlText))
            {
                return;
            }
            string[] sqlIndexs = sqlText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //匹配索引
            string regexIndexText = @"CREATE\s+[a-zA-Z]+\s+INDEX\s+([1-9a-zA-Z_]+)";
            //匹配表
            string regexTableText = @"ON\s+([1-9a-zA-Z_\[.\]]+)\s+\(";

            //匹配索引与表
            string regexIndexTableText = @"CREATE\s+[a-zA-Z]+\sINDEX\s+([1-9a-zA-Z_]+)\s+ON\s+([1-9a-zA-Z_\[.\]]+)\s+\(";
            //匹配说明
            string regexRemarkText = @"--(.*)";
            string indexName = "", remark = "";
            foreach (var sqlIndex in sqlIndexs)
            {
                var math2 = Regex.Matches(sqlIndex, regexRemarkText, RegexOptions.IgnoreCase);
                if (math2.Count > 0)
                {
                    if (math2[0].Groups.Count > 1)
                    {
                        remark = math2[0].Groups[1].Value;
                        continue;
                    }
                }
                var math3 = Regex.Matches(sqlIndex, regexIndexTableText, RegexOptions.IgnoreCase);
                if (math3.Count > 0)
                {
                    if (math3[0].Groups.Count > 1)
                    {
                        var textSqlText = string.Format(textTemplateSqlText, math3[0].Groups[2].Value, math3[0].Groups[1].Value, "删除" + remark);
                        this.delIndexRtb.AppendText(textSqlText + "\n");
                        continue;
                    }
                }

                var match = Regex.Matches(sqlIndex, regexIndexText, RegexOptions.IgnoreCase);
                if (match.Count > 0)
                {
                    if (match[0].Groups.Count > 1)
                    {
                        indexName = match[0].Groups[1].Value;
                        continue;
                    }
                }
                var match1 = Regex.Matches(sqlIndex, regexTableText, RegexOptions.IgnoreCase);
                if (match1.Count > 0)
                {
                    if (match1[0].Groups.Count > 1)
                    {
                        var textSqlText = string.Format(textTemplateSqlText, match1[0].Groups[1].Value, indexName, "删除" + remark);
                        this.delIndexRtb.AppendText(textSqlText + "\n");
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 打开sql索引按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sql文件|*.sql|文本文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = "F:\\公司文档\\clerp\\01 SQL提交-重构\\性能优化脚本";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileName = openFileDialog.FileName;
                this.filePathTbx.Text = openFileName;
                //读取文件
                string sqlText = File.ReadAllText(openFileName, Encoding.GetEncoding("GB2312"));

                this.sqlRtb.AppendText(sqlText);
            }
        }

        /// <summary>
        /// 导出删除索引脚本sql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "sql文件|*.sql|文本文件|*.*";

            sfd.FileName = Path.GetFileNameWithoutExtension(openFileName) + "-删除索引.sql";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                //获取删除索引数据
                string sqlText = this.delIndexRtb.Text;
                //输出删除索引
                File.WriteAllText(localFilePath, sqlText, Encoding.GetEncoding("GB2312"));
            }
        }

        #endregion
    }
}
