namespace JoeySoft.TfsDevelopWinFrom
{
    partial class TfsDevelopFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfsDevelopFrom));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.showCustomizeFileBtn = new System.Windows.Forms.Button();
            this.customizePathCBX = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.isTrueCheckoutRadioBtn = new System.Windows.Forms.RadioButton();
            this.isFalseCheckoutRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isTrueCopyRadioBtn = new System.Windows.Forms.RadioButton();
            this.isFalseCopyRadioBtn = new System.Windows.Forms.RadioButton();
            this.updateFilesTV = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.updateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.customizebtn = new System.Windows.Forms.Button();
            this.updateFilesRTB = new System.Windows.Forms.RichTextBox();
            this.pathTBx = new System.Windows.Forms.TextBox();
            this.ReadRootFileBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.showCustomizeFileBtn);
            this.tabPage2.Controls.Add(this.customizePathCBX);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.updateFilesTV);
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
            // showCustomizeFileBtn
            // 
            this.showCustomizeFileBtn.Location = new System.Drawing.Point(695, 695);
            this.showCustomizeFileBtn.Name = "showCustomizeFileBtn";
            this.showCustomizeFileBtn.Size = new System.Drawing.Size(111, 23);
            this.showCustomizeFileBtn.TabIndex = 21;
            this.showCustomizeFileBtn.Text = "显示二开元数据";
            this.showCustomizeFileBtn.UseVisualStyleBackColor = true;
            this.showCustomizeFileBtn.Click += new System.EventHandler(this.showCustomizeFileBtn_Click);
            // 
            // customizePathCBX
            // 
            this.customizePathCBX.FormattingEnabled = true;
            this.customizePathCBX.Location = new System.Drawing.Point(6, 653);
            this.customizePathCBX.Name = "customizePathCBX";
            this.customizePathCBX.Size = new System.Drawing.Size(674, 20);
            this.customizePathCBX.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(813, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 24);
            this.button3.TabIndex = 19;
            this.button3.Text = "自动签入";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
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
            this.customizebtn.Location = new System.Drawing.Point(695, 653);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(41, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 760);
            this.tabControl1.TabIndex = 5;
            // 
            // TfsDevelopFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 826);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TfsDevelopFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品更新二开";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button showCustomizeFileBtn;
        private System.Windows.Forms.ComboBox customizePathCBX;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton isTrueCheckoutRadioBtn;
        private System.Windows.Forms.RadioButton isFalseCheckoutRadioBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton isTrueCopyRadioBtn;
        private System.Windows.Forms.RadioButton isFalseCopyRadioBtn;
        private System.Windows.Forms.TreeView updateFilesTV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker updateDateTimePicker;
        private System.Windows.Forms.Button customizebtn;
        private System.Windows.Forms.RichTextBox updateFilesRTB;
        private System.Windows.Forms.TextBox pathTBx;
        private System.Windows.Forms.Button ReadRootFileBtn;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

