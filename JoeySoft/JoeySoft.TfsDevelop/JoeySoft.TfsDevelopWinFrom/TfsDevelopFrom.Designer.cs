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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfsDevelopFrom));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.updateTriSatateTreeView = new SmartSolutions.Controls.TriStateTreeView();
            this.contextMenuStripTV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.allSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CheckInBtn = new System.Windows.Forms.Button();
            this.showCustomizeFileBtn = new System.Windows.Forms.Button();
            this.customizePathCBX = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.isTrueCheckoutRadioBtn = new System.Windows.Forms.RadioButton();
            this.isFalseCheckoutRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isTrueCopyRadioBtn = new System.Windows.Forms.RadioButton();
            this.isFalseCopyRadioBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.updateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.customizebtn = new System.Windows.Forms.Button();
            this.pathTBx = new System.Windows.Forms.TextBox();
            this.ReadRootFileBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2.SuspendLayout();
            this.contextMenuStripTV.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.updateTriSatateTreeView);
            this.tabPage2.Controls.Add(this.CheckInBtn);
            this.tabPage2.Controls.Add(this.showCustomizeFileBtn);
            this.tabPage2.Controls.Add(this.customizePathCBX);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.updateDateTimePicker);
            this.tabPage2.Controls.Add(this.customizebtn);
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
            // updateTriSatateTreeView
            // 
            this.updateTriSatateTreeView.CheckBoxes = true;
            this.updateTriSatateTreeView.CheckedImageIndex = 3;
            this.updateTriSatateTreeView.ContextMenuStrip = this.contextMenuStripTV;
            this.updateTriSatateTreeView.ImageKey = "TIM图片20180612182821.ico";
            this.updateTriSatateTreeView.ImageList = this.imageList1;
            this.updateTriSatateTreeView.IndeterminateImageIndex = 4;
            this.updateTriSatateTreeView.Location = new System.Drawing.Point(6, 35);
            this.updateTriSatateTreeView.Name = "updateTriSatateTreeView";
            this.updateTriSatateTreeView.SelectedImageIndex = 1;
            this.updateTriSatateTreeView.Size = new System.Drawing.Size(798, 600);
            this.updateTriSatateTreeView.TabIndex = 23;
            this.updateTriSatateTreeView.UncheckedImageIndex = 5;
            this.updateTriSatateTreeView.UseCustomImages = true;
            this.updateTriSatateTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.updateTriSatateTreeView_AfterCheck);
            // 
            // contextMenuStripTV
            // 
            this.contextMenuStripTV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allSelectToolStripMenuItem,
            this.noSelectToolStripMenuItem});
            this.contextMenuStripTV.Name = "contextMenuStripTV";
            this.contextMenuStripTV.Size = new System.Drawing.Size(113, 48);
            // 
            // allSelectToolStripMenuItem
            // 
            this.allSelectToolStripMenuItem.Name = "allSelectToolStripMenuItem";
            this.allSelectToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.allSelectToolStripMenuItem.Text = "全选";
            this.allSelectToolStripMenuItem.Click += new System.EventHandler(this.allSelectToolStripMenuItem_Click);
            // 
            // noSelectToolStripMenuItem
            // 
            this.noSelectToolStripMenuItem.Name = "noSelectToolStripMenuItem";
            this.noSelectToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.noSelectToolStripMenuItem.Text = "全不选";
            this.noSelectToolStripMenuItem.Click += new System.EventHandler(this.noSelectToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "TIM图片20180612182821.ico");
            this.imageList1.Images.SetKeyName(1, "TIM图片20180612183126.ico");
            this.imageList1.Images.SetKeyName(2, "企业微信截图_15287984943050.ico");
            this.imageList1.Images.SetKeyName(3, "TIM图片20180612181930.ico");
            this.imageList1.Images.SetKeyName(4, "TIM图片20180612181859.ico");
            this.imageList1.Images.SetKeyName(5, "TIM图片20180612182002.ico");
            // 
            // CheckInBtn
            // 
            this.CheckInBtn.Location = new System.Drawing.Point(833, 653);
            this.CheckInBtn.Name = "CheckInBtn";
            this.CheckInBtn.Size = new System.Drawing.Size(111, 23);
            this.CheckInBtn.TabIndex = 22;
            this.CheckInBtn.Text = "查看正在挂起更改";
            this.CheckInBtn.UseVisualStyleBackColor = true;
            this.CheckInBtn.Click += new System.EventHandler(this.CheckInBtn_Click);
            // 
            // showCustomizeFileBtn
            // 
            this.showCustomizeFileBtn.Location = new System.Drawing.Point(695, 695);
            this.showCustomizeFileBtn.Name = "showCustomizeFileBtn";
            this.showCustomizeFileBtn.Size = new System.Drawing.Size(111, 23);
            this.showCustomizeFileBtn.TabIndex = 21;
            this.showCustomizeFileBtn.Text = "显示二开文件";
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
            this.customizePathCBX.SelectedIndexChanged += new System.EventHandler(this.customizePathCBX_SelectedIndexChanged);
            this.customizePathCBX.TextChanged += new System.EventHandler(this.customizePathCBX_TextChanged);
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
            // pathTBx
            // 
            this.pathTBx.Location = new System.Drawing.Point(6, 8);
            this.pathTBx.Name = "pathTBx";
            this.pathTBx.Size = new System.Drawing.Size(701, 21);
            this.pathTBx.TabIndex = 1;
            this.pathTBx.TextChanged += new System.EventHandler(this.pathTBx_TextChanged);
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
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.feedbackToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkVersionToolStripMenuItem,
            this.versionToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // checkVersionToolStripMenuItem
            // 
            this.checkVersionToolStripMenuItem.Name = "checkVersionToolStripMenuItem";
            this.checkVersionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.checkVersionToolStripMenuItem.Text = "检查最新版本";
            this.checkVersionToolStripMenuItem.Click += new System.EventHandler(this.checkVersionToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.versionToolStripMenuItem.Text = "关于工具";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // feedbackToolStripMenuItem
            // 
            this.feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            this.feedbackToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.feedbackToolStripMenuItem.Text = "反馈";
            this.feedbackToolStripMenuItem.Click += new System.EventHandler(this.feedbackToolStripMenuItem_Click);
            // 
            // TfsDevelopFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 826);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TfsDevelopFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品更新二开";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TfsDevelopFrom_FormClosed);
            this.Load += new System.EventHandler(this.TfsDevelopFrom_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.contextMenuStripTV.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button showCustomizeFileBtn;
        private System.Windows.Forms.ComboBox customizePathCBX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton isTrueCheckoutRadioBtn;
        private System.Windows.Forms.RadioButton isFalseCheckoutRadioBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton isTrueCopyRadioBtn;
        private System.Windows.Forms.RadioButton isFalseCopyRadioBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker updateDateTimePicker;
        private System.Windows.Forms.Button customizebtn;
        private System.Windows.Forms.TextBox pathTBx;
        private System.Windows.Forms.Button ReadRootFileBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button CheckInBtn;
        private SmartSolutions.Controls.TriStateTreeView updateTriSatateTreeView;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTV;
        private System.Windows.Forms.ToolStripMenuItem allSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noSelectToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
    }
}

