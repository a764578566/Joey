namespace JoeySoft.PackageTool
{
    partial class PackageToolFrm
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
            this.GetPackageVersion = new System.Windows.Forms.Button();
            this.PackagelistBx = new System.Windows.Forms.ListBox();
            this.Packbtn = new System.Windows.Forms.Button();
            this.PackageAdressCBX = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Pushbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetPackageVersion
            // 
            this.GetPackageVersion.Location = new System.Drawing.Point(12, 21);
            this.GetPackageVersion.Name = "GetPackageVersion";
            this.GetPackageVersion.Size = new System.Drawing.Size(99, 23);
            this.GetPackageVersion.TabIndex = 0;
            this.GetPackageVersion.Text = "获取包版本信息";
            this.GetPackageVersion.UseVisualStyleBackColor = true;
            this.GetPackageVersion.Click += new System.EventHandler(this.GetPackageVersion_Click);
            // 
            // PackagelistBx
            // 
            this.PackagelistBx.FormattingEnabled = true;
            this.PackagelistBx.ItemHeight = 12;
            this.PackagelistBx.Location = new System.Drawing.Point(121, 21);
            this.PackagelistBx.Name = "PackagelistBx";
            this.PackagelistBx.Size = new System.Drawing.Size(651, 100);
            this.PackagelistBx.TabIndex = 1;
            this.PackagelistBx.SelectedIndexChanged += new System.EventHandler(this.PackagelistBx_SelectedIndexChanged);
            // 
            // Packbtn
            // 
            this.Packbtn.Location = new System.Drawing.Point(616, 223);
            this.Packbtn.Name = "Packbtn";
            this.Packbtn.Size = new System.Drawing.Size(75, 23);
            this.Packbtn.TabIndex = 2;
            this.Packbtn.Text = "打包";
            this.Packbtn.UseVisualStyleBackColor = true;
            this.Packbtn.Click += new System.EventHandler(this.Packbtn_Click);
            // 
            // PackageAdressCBX
            // 
            this.PackageAdressCBX.FormattingEnabled = true;
            this.PackageAdressCBX.Location = new System.Drawing.Point(121, 188);
            this.PackageAdressCBX.Name = "PackageAdressCBX";
            this.PackageAdressCBX.Size = new System.Drawing.Size(651, 20);
            this.PackageAdressCBX.TabIndex = 3;
            this.PackageAdressCBX.SelectedIndexChanged += new System.EventHandler(this.PackageAdressCBX_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "软件包地址：";
            // 
            // Pushbtn
            // 
            this.Pushbtn.Location = new System.Drawing.Point(696, 223);
            this.Pushbtn.Name = "Pushbtn";
            this.Pushbtn.Size = new System.Drawing.Size(75, 23);
            this.Pushbtn.TabIndex = 5;
            this.Pushbtn.Text = "推包";
            this.Pushbtn.UseVisualStyleBackColor = true;
            this.Pushbtn.Click += new System.EventHandler(this.Pushbtn_Click);
            // 
            // PackageToolFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 322);
            this.Controls.Add(this.Pushbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PackageAdressCBX);
            this.Controls.Add(this.Packbtn);
            this.Controls.Add(this.PackagelistBx);
            this.Controls.Add(this.GetPackageVersion);
            this.Name = "PackageToolFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打包工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetPackageVersion;
        private System.Windows.Forms.ListBox PackagelistBx;
        private System.Windows.Forms.Button Packbtn;
        private System.Windows.Forms.ComboBox PackageAdressCBX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Pushbtn;
    }
}

