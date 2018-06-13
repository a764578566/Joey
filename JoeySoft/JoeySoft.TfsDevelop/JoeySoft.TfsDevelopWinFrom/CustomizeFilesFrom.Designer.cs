namespace JoeySoft.TfsDevelopWinFrom
{
    partial class CustomizeFilesFrom
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
            this.customizeFiletView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // customizeFiletView
            // 
            this.customizeFiletView.Location = new System.Drawing.Point(12, 12);
            this.customizeFiletView.Name = "customizeFiletView";
            this.customizeFiletView.Size = new System.Drawing.Size(760, 538);
            this.customizeFiletView.TabIndex = 0;
            // 
            // CustomizeFilesFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.customizeFiletView);
            this.Name = "CustomizeFilesFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "二开过的元数据";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView customizeFiletView;
    }
}