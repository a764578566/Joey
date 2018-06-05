namespace JoeySoft.TfsDevelopWinFrom
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.Checkoutbtn = new System.Windows.Forms.Button();
            this.CopyFilebtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.isTrueCheckoutRadioBtn = new System.Windows.Forms.RadioButton();
            this.isFalseCheckoutRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isTrueCopyRadioBtn = new System.Windows.Forms.RadioButton();
            this.isFalseCopyRadioBtn = new System.Windows.Forms.RadioButton();
            this.updateFilesTV = new System.Windows.Forms.TreeView();
            this.customizePathTBx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.customizebtn = new System.Windows.Forms.Button();
            this.updateFilesRTB = new System.Windows.Forms.RichTextBox();
            this.pathTBx = new System.Windows.Forms.TextBox();
            this.ReadRootFileBtn = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqlRtb
            // 
            this.sqlRtb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sqlRtb.Location = new System.Drawing.Point(3, 36);
            this.sqlRtb.Name = "sqlRtb";
            this.sqlRtb.Size = new System.Drawing.Size(450, 600);
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
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(41, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 760);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.Checkoutbtn);
            this.tabPage2.Controls.Add(this.CopyFilebtn);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.updateFilesTV);
            this.tabPage2.Controls.Add(this.customizePathTBx);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.updateDateTimePicker);
            this.tabPage2.Controls.Add(this.customizebtn);
            this.tabPage2.Controls.Add(this.updateFilesRTB);
            this.tabPage2.Controls.Add(this.pathTBx);
            this.tabPage2.Controls.Add(this.ReadRootFileBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1016, 734);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "生成二开更新包";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(896, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 24);
            this.button3.TabIndex = 19;
            this.button3.Text = "自动签入";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // Checkoutbtn
            // 
            this.Checkoutbtn.Location = new System.Drawing.Point(896, 5);
            this.Checkoutbtn.Name = "Checkoutbtn";
            this.Checkoutbtn.Size = new System.Drawing.Size(80, 24);
            this.Checkoutbtn.TabIndex = 18;
            this.Checkoutbtn.Text = "签出编辑";
            this.Checkoutbtn.UseVisualStyleBackColor = true;
            this.Checkoutbtn.Visible = false;
            this.Checkoutbtn.Click += new System.EventHandler(this.Checkoutbtn_Click);
            // 
            // CopyFilebtn
            // 
            this.CopyFilebtn.Location = new System.Drawing.Point(810, 6);
            this.CopyFilebtn.Name = "CopyFilebtn";
            this.CopyFilebtn.Size = new System.Drawing.Size(80, 24);
            this.CopyFilebtn.TabIndex = 17;
            this.CopyFilebtn.Text = "复制";
            this.CopyFilebtn.UseVisualStyleBackColor = true;
            this.CopyFilebtn.Visible = false;
            this.CopyFilebtn.Click += new System.EventHandler(this.CopyFilebtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.isTrueCheckoutRadioBtn);
            this.groupBox2.Controls.Add(this.isFalseCheckoutRadioBtn);
            this.groupBox2.Location = new System.Drawing.Point(813, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 47);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "是否编辑签出二开";
            this.groupBox2.Visible = false;
            // 
            // isTrueCheckoutRadioBtn
            // 
            this.isTrueCheckoutRadioBtn.AutoSize = true;
            this.isTrueCheckoutRadioBtn.Location = new System.Drawing.Point(23, 20);
            this.isTrueCheckoutRadioBtn.Name = "isTrueCheckoutRadioBtn";
            this.isTrueCheckoutRadioBtn.Size = new System.Drawing.Size(35, 16);
            this.isTrueCheckoutRadioBtn.TabIndex = 13;
            this.isTrueCheckoutRadioBtn.TabStop = true;
            this.isTrueCheckoutRadioBtn.Text = "是";
            this.isTrueCheckoutRadioBtn.UseVisualStyleBackColor = true;
            // 
            // isFalseCheckoutRadioBtn
            // 
            this.isFalseCheckoutRadioBtn.AutoSize = true;
            this.isFalseCheckoutRadioBtn.Location = new System.Drawing.Point(94, 20);
            this.isFalseCheckoutRadioBtn.Name = "isFalseCheckoutRadioBtn";
            this.isFalseCheckoutRadioBtn.Size = new System.Drawing.Size(35, 16);
            this.isFalseCheckoutRadioBtn.TabIndex = 14;
            this.isFalseCheckoutRadioBtn.TabStop = true;
            this.isFalseCheckoutRadioBtn.Text = "否";
            this.isFalseCheckoutRadioBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isTrueCopyRadioBtn);
            this.groupBox1.Controls.Add(this.isFalseCopyRadioBtn);
            this.groupBox1.Location = new System.Drawing.Point(810, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 50);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "是否读取时直接复制并签出";
            // 
            // isTrueCopyRadioBtn
            // 
            this.isTrueCopyRadioBtn.AutoSize = true;
            this.isTrueCopyRadioBtn.Location = new System.Drawing.Point(23, 20);
            this.isTrueCopyRadioBtn.Name = "isTrueCopyRadioBtn";
            this.isTrueCopyRadioBtn.Size = new System.Drawing.Size(35, 16);
            this.isTrueCopyRadioBtn.TabIndex = 8;
            this.isTrueCopyRadioBtn.TabStop = true;
            this.isTrueCopyRadioBtn.Text = "是";
            this.isTrueCopyRadioBtn.UseVisualStyleBackColor = true;
            // 
            // isFalseCopyRadioBtn
            // 
            this.isFalseCopyRadioBtn.AutoSize = true;
            this.isFalseCopyRadioBtn.Location = new System.Drawing.Point(94, 20);
            this.isFalseCopyRadioBtn.Name = "isFalseCopyRadioBtn";
            this.isFalseCopyRadioBtn.Size = new System.Drawing.Size(35, 16);
            this.isFalseCopyRadioBtn.TabIndex = 10;
            this.isFalseCopyRadioBtn.TabStop = true;
            this.isFalseCopyRadioBtn.Text = "否";
            this.isFalseCopyRadioBtn.UseVisualStyleBackColor = true;
            // 
            // updateFilesTV
            // 
            this.updateFilesTV.Location = new System.Drawing.Point(6, 35);
            this.updateFilesTV.Name = "updateFilesTV";
            this.updateFilesTV.Size = new System.Drawing.Size(798, 600);
            this.updateFilesTV.TabIndex = 11;
            // 
            // customizePathTBx
            // 
            this.customizePathTBx.Location = new System.Drawing.Point(6, 654);
            this.customizePathTBx.Name = "customizePathTBx";
            this.customizePathTBx.Size = new System.Drawing.Size(671, 21);
            this.customizePathTBx.TabIndex = 6;
            this.customizePathTBx.TextChanged += new System.EventHandler(this.customizePathTBx_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(808, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择更新日期";
            // 
            // updateDateTimePicker
            // 
            this.updateDateTimePicker.Location = new System.Drawing.Point(810, 197);
            this.updateDateTimePicker.Name = "updateDateTimePicker";
            this.updateDateTimePicker.Size = new System.Drawing.Size(200, 21);
            this.updateDateTimePicker.TabIndex = 4;
            // 
            // customizebtn
            // 
            this.customizebtn.Location = new System.Drawing.Point(695, 652);
            this.customizebtn.Name = "customizebtn";
            this.customizebtn.Size = new System.Drawing.Size(111, 23);
            this.customizebtn.TabIndex = 3;
            this.customizebtn.Text = "复制并签出编辑";
            this.customizebtn.UseVisualStyleBackColor = true;
            this.customizebtn.Click += new System.EventHandler(this.customizebtn_Click);
            // 
            // updateFilesRTB
            // 
            this.updateFilesRTB.Location = new System.Drawing.Point(6, 35);
            this.updateFilesRTB.Name = "updateFilesRTB";
            this.updateFilesRTB.Size = new System.Drawing.Size(800, 600);
            this.updateFilesRTB.TabIndex = 2;
            this.updateFilesRTB.Text = "";
            // 
            // pathTBx
            // 
            this.pathTBx.Location = new System.Drawing.Point(6, 8);
            this.pathTBx.Name = "pathTBx";
            this.pathTBx.Size = new System.Drawing.Size(701, 21);
            this.pathTBx.TabIndex = 1;
            // 
            // ReadRootFileBtn
            // 
            this.ReadRootFileBtn.Location = new System.Drawing.Point(724, 6);
            this.ReadRootFileBtn.Name = "ReadRootFileBtn";
            this.ReadRootFileBtn.Size = new System.Drawing.Size(80, 24);
            this.ReadRootFileBtn.TabIndex = 0;
            this.ReadRootFileBtn.Text = "读取";
            this.ReadRootFileBtn.UseVisualStyleBackColor = true;
            this.ReadRootFileBtn.Click += new System.EventHandler(this.RootFileBtn_Click);
            // 
            // tabPage1
            // 
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
            // DeleteIndexFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 826);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteIndexFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品更新二开";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox pathTBx;
        private System.Windows.Forms.Button ReadRootFileBtn;
        private System.Windows.Forms.Button customizebtn;
        private System.Windows.Forms.RichTextBox updateFilesRTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker updateDateTimePicker;
        private System.Windows.Forms.TextBox customizePathTBx;
        private System.Windows.Forms.RadioButton isTrueCopyRadioBtn;
        private System.Windows.Forms.RadioButton isFalseCopyRadioBtn;
        private System.Windows.Forms.TreeView updateFilesTV;
        private System.Windows.Forms.RadioButton isFalseCheckoutRadioBtn;
        private System.Windows.Forms.RadioButton isTrueCheckoutRadioBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Checkoutbtn;
        private System.Windows.Forms.Button CopyFilebtn;
    }
}

