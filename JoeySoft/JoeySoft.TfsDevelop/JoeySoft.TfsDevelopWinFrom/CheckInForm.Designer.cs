namespace JoeySoft.TfsDevelopWinFrom
{
    partial class CheckInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInForm));
            this.checkInbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.remarktbx = new System.Windows.Forms.TextBox();
            this.updateTriSatateTreeView = new SmartSolutions.Controls.TriStateTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.undobtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkInbtn
            // 
            this.checkInbtn.Location = new System.Drawing.Point(616, 145);
            this.checkInbtn.Name = "checkInbtn";
            this.checkInbtn.Size = new System.Drawing.Size(75, 23);
            this.checkInbtn.TabIndex = 1;
            this.checkInbtn.Text = "签入";
            this.checkInbtn.UseVisualStyleBackColor = true;
            this.checkInbtn.Click += new System.EventHandler(this.checkInbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "签入说明：";
            // 
            // remarktbx
            // 
            this.remarktbx.Location = new System.Drawing.Point(618, 27);
            this.remarktbx.Multiline = true;
            this.remarktbx.Name = "remarktbx";
            this.remarktbx.Size = new System.Drawing.Size(154, 112);
            this.remarktbx.TabIndex = 3;
            // 
            // updateTriSatateTreeView
            // 
            this.updateTriSatateTreeView.CheckBoxes = true;
            this.updateTriSatateTreeView.CheckedImageIndex = 3;
            this.updateTriSatateTreeView.ImageKey = "TIM图片20180612182821.ico";
            this.updateTriSatateTreeView.ImageList = this.imageList1;
            this.updateTriSatateTreeView.IndeterminateImageIndex = 4;
            this.updateTriSatateTreeView.Location = new System.Drawing.Point(12, 12);
            this.updateTriSatateTreeView.Name = "updateTriSatateTreeView";
            this.updateTriSatateTreeView.SelectedImageIndex = 1;
            this.updateTriSatateTreeView.Size = new System.Drawing.Size(598, 538);
            this.updateTriSatateTreeView.TabIndex = 0;
            this.updateTriSatateTreeView.UncheckedImageIndex = 5;
            this.updateTriSatateTreeView.UseCustomImages = true;
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
            // undobtn
            // 
            this.undobtn.Location = new System.Drawing.Point(697, 145);
            this.undobtn.Name = "undobtn";
            this.undobtn.Size = new System.Drawing.Size(75, 23);
            this.undobtn.TabIndex = 4;
            this.undobtn.Text = "撤消";
            this.undobtn.UseVisualStyleBackColor = true;
            this.undobtn.Click += new System.EventHandler(this.undobtn_Click);
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.undobtn);
            this.Controls.Add(this.updateTriSatateTreeView);
            this.Controls.Add(this.remarktbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkInbtn);
            this.Name = "CheckInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "签入窗体";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button checkInbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox remarktbx;
        private SmartSolutions.Controls.TriStateTreeView updateTriSatateTreeView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button undobtn;
    }
}