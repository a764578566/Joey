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

        private string regexStr = @"--(.*)[\n]+IF\s+NOT\s+EXISTS\s*\(.+\)\s*\nCREATE\s+[a-zA-Z\s]+INDEX\s+([1-9a-zA-Z_]+)\s+ON\s+([1-9a-zA-Z_\[.\]]+)\s*\(";

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
            this.delIndexRtb.Text = string.Empty;
            this.DeleteIndexCountLabel.Text = "0";
            var maths = Regex.Matches(sqlText, regexStr, RegexOptions.IgnoreCase);
            if (maths.Count > 0)
            {
                for (int i = 0; i < maths.Count; i++)
                {
                    if (maths[i].Groups.Count > 3)
                    {
                        var textSqlText = string.Format(textTemplateSqlText, maths[i].Groups[3].Value, maths[i].Groups[2].Value, "删除" + maths[i].Groups[1].Value);
                        this.delIndexRtb.AppendText(textSqlText + "\n");
                        this.DeleteIndexCountLabel.Text = (int.Parse(this.DeleteIndexCountLabel.Text) + 1).ToString();
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
            this.sqlRtb.Text = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sql文件|*.sql|文本文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = "F:\\公司文档\\clerp\\01 SQL提交-重构\\性能优化脚本";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.IndexCountLabel.Text = "0";

                openFileName = openFileDialog.FileName;
                this.filePathTbx.Text = openFileName;
                //读取文件
                string sqlText = File.ReadAllText(openFileName, Encoding.GetEncoding("GB2312"));

                var maths = Regex.Matches(sqlText, regexStr, RegexOptions.IgnoreCase);
                if (maths.Count > 0)
                {
                    this.IndexCountLabel.Text = (int.Parse(this.IndexCountLabel.Text) + maths.Count).ToString();
                }
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
