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
            this.OpenIndexSqlFileBtn = new System.Windows.Forms.Button();
            this.filePathTbx = new System.Windows.Forms.TextBox();
            this.OutputBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IndexCountLabel = new System.Windows.Forms.Label();
            this.DeleteIndexCountLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqlRtb
            // 
            this.sqlRtb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sqlRtb.Location = new System.Drawing.Point(3, 36);
            this.sqlRtb.Name = "sqlRtb";
            this.sqlRtb.Size = new System.Drawing.Size(493, 600);
            this.sqlRtb.TabIndex = 0;
            this.sqlRtb.Text = "";
            // 
            // delIndexRtb
            // 
            this.delIndexRtb.Location = new System.Drawing.Point(522, 36);
            this.delIndexRtb.Name = "delIndexRtb";
            this.delIndexRtb.Size = new System.Drawing.Size(450, 600);
            this.delIndexRtb.TabIndex = 0;
            this.delIndexRtb.Text = "";
            // 
            // DeleteIndexbtn
            // 
            this.DeleteIndexbtn.Location = new System.Drawing.Point(816, 7);
            this.DeleteIndexbtn.Name = "DeleteIndexbtn";
            this.DeleteIndexbtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteIndexbtn.TabIndex = 1;
            this.DeleteIndexbtn.Text = "生成";
            this.DeleteIndexbtn.UseVisualStyleBackColor = true;
            this.DeleteIndexbtn.Click += new System.EventHandler(this.DeleteIndexbtn_Click);
            // 
            // OpenIndexSqlFileBtn
            // 
            this.OpenIndexSqlFileBtn.Location = new System.Drawing.Point(3, 7);
            this.OpenIndexSqlFileBtn.Name = "OpenIndexSqlFileBtn";
            this.OpenIndexSqlFileBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenIndexSqlFileBtn.TabIndex = 2;
            this.OpenIndexSqlFileBtn.Text = "打开文件";
            this.OpenIndexSqlFileBtn.UseVisualStyleBackColor = true;
            this.OpenIndexSqlFileBtn.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // filePathTbx
            // 
            this.filePathTbx.Location = new System.Drawing.Point(104, 7);
            this.filePathTbx.Name = "filePathTbx";
            this.filePathTbx.Size = new System.Drawing.Size(706, 21);
            this.filePathTbx.TabIndex = 3;
            // 
            // OutputBtn
            // 
            this.OutputBtn.Location = new System.Drawing.Point(897, 6);
            this.OutputBtn.Name = "OutputBtn";
            this.OutputBtn.Size = new System.Drawing.Size(75, 23);
            this.OutputBtn.TabIndex = 4;
            this.OutputBtn.Text = "导出脚本";
            this.OutputBtn.UseVisualStyleBackColor = true;
            this.OutputBtn.Click += new System.EventHandler(this.OutputBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(41, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 760);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DeleteIndexCountLabel);
            this.tabPage1.Controls.Add(this.IndexCountLabel);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.delIndexRtb);
            this.tabPage1.Controls.Add(this.OutputBtn);
            this.tabPage1.Controls.Add(this.sqlRtb);
            this.tabPage1.Controls.Add(this.filePathTbx);
            this.tabPage1.Controls.Add(this.DeleteIndexbtn);
            this.tabPage1.Controls.Add(this.OpenIndexSqlFileBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1016, 734);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生成索引删除脚本";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 663);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(520, 663);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "数量：";
            // 
            // IndexCountLabel
            // 
            this.IndexCountLabel.AutoSize = true;
            this.IndexCountLabel.Location = new System.Drawing.Point(53, 663);
            this.IndexCountLabel.Name = "IndexCountLabel";
            this.IndexCountLabel.Size = new System.Drawing.Size(11, 12);
            this.IndexCountLabel.TabIndex = 7;
            this.IndexCountLabel.Text = "0";
            // 
            // DeleteIndexCountLabel
            // 
            this.DeleteIndexCountLabel.AutoSize = true;
            this.DeleteIndexCountLabel.Location = new System.Drawing.Point(567, 663);
            this.DeleteIndexCountLabel.Name = "DeleteIndexCountLabel";
            this.DeleteIndexCountLabel.Size = new System.Drawing.Size(11, 12);
            this.DeleteIndexCountLabel.TabIndex = 7;
            this.DeleteIndexCountLabel.Text = "0";
            // 
            // DeleteIndexFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 826);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteIndexFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成索引删除脚本";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox sqlRtb;
        private System.Windows.Forms.RichTextBox delIndexRtb;
        private System.Windows.Forms.Button DeleteIndexbtn;
        private System.Windows.Forms.Button OpenIndexSqlFileBtn;
        private System.Windows.Forms.TextBox filePathTbx;
        private System.Windows.Forms.Button OutputBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label DeleteIndexCountLabel;
        private System.Windows.Forms.Label IndexCountLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

