namespace JoeySoft.DropIndexWinFrom
{
    partial class DeleteIndexFrom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteIndexFrom));
            this.sqlRtb = new System.Windows.Forms.RichTextBox();
            this.delIndexRtb = new System.Windows.Forms.RichTextBox();
            this.DeleteIndexbtn = new System.Windows.Forms.Button();
            this.openSqlFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenFile = new System.Windows.Forms.Button();
            this.filePathTbx = new System.Windows.Forms.TextBox();
            this.OutputBtn = new System.Windows.Forms.Button();
            this.saveSqlFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // sqlRtb
            // 
            this.sqlRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlRtb.Location = new System.Drawing.Point(12, 49);
            this.sqlRtb.Name = "sqlRtb";
            this.sqlRtb.Size = new System.Drawing.Size(457, 584);
            this.sqlRtb.TabIndex = 0;
            this.sqlRtb.Text = "";
            // 
            // delIndexRtb
            // 
            this.delIndexRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.delIndexRtb.Location = new System.Drawing.Point(567, 49);
            this.delIndexRtb.Name = "delIndexRtb";
            this.delIndexRtb.Size = new System.Drawing.Size(435, 584);
            this.delIndexRtb.TabIndex = 0;
            this.delIndexRtb.Text = "";
            // 
            // DeleteIndexbtn
            // 
            this.DeleteIndexbtn.Location = new System.Drawing.Point(475, 61);
            this.DeleteIndexbtn.Name = "DeleteIndexbtn";
            this.DeleteIndexbtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteIndexbtn.TabIndex = 1;
            this.DeleteIndexbtn.Text = "生成";
            this.DeleteIndexbtn.UseVisualStyleBackColor = true;
            this.DeleteIndexbtn.Click += new System.EventHandler(this.DeleteIndexbtn_Click);
            // 
            // openSqlFileDialog
            // 
            this.openSqlFileDialog.FileName = "openFileDialog1";
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(12, 20);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(75, 23);
            this.OpenFile.TabIndex = 2;
            this.OpenFile.Text = "打开文件";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // filePathTbx
            // 
            this.filePathTbx.Location = new System.Drawing.Point(113, 20);
            this.filePathTbx.Name = "filePathTbx";
            this.filePathTbx.Size = new System.Drawing.Size(322, 21);
            this.filePathTbx.TabIndex = 3;
            // 
            // OutputBtn
            // 
            this.OutputBtn.Location = new System.Drawing.Point(927, 18);
            this.OutputBtn.Name = "OutputBtn";
            this.OutputBtn.Size = new System.Drawing.Size(75, 23);
            this.OutputBtn.TabIndex = 4;
            this.OutputBtn.Text = "导出脚本";
            this.OutputBtn.UseVisualStyleBackColor = true;
            this.OutputBtn.Click += new System.EventHandler(this.OutputBtn_Click);
            // 
            // DeleteIndexFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 645);
            this.Controls.Add(this.OutputBtn);
            this.Controls.Add(this.filePathTbx);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.DeleteIndexbtn);
            this.Controls.Add(this.delIndexRtb);
            this.Controls.Add(this.sqlRtb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteIndexFrom";
            this.Text = "生成索引删除脚本";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox sqlRtb;
        private System.Windows.Forms.RichTextBox delIndexRtb;
        private System.Windows.Forms.Button DeleteIndexbtn;
        private System.Windows.Forms.OpenFileDialog openSqlFileDialog;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.TextBox filePathTbx;
        private System.Windows.Forms.Button OutputBtn;
        private System.Windows.Forms.SaveFileDialog saveSqlFileDialog;
    }
}

