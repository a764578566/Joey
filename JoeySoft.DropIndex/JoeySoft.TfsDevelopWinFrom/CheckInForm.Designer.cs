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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点5", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点15");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点13", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点17");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点18");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点16", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("节点14", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点11", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("节点7", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("节点8");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点3";
            treeNode1.Text = "节点3";
            treeNode2.Name = "节点0";
            treeNode2.Text = "节点0";
            treeNode3.Name = "节点4";
            treeNode3.Text = "节点4";
            treeNode4.Name = "节点1";
            treeNode4.Text = "节点1";
            treeNode5.Name = "节点6";
            treeNode5.Text = "节点6";
            treeNode6.Name = "节点9";
            treeNode6.Text = "节点9";
            treeNode7.Name = "节点5";
            treeNode7.Text = "节点5";
            treeNode8.Name = "节点2";
            treeNode8.Text = "节点2";
            treeNode9.Name = "节点10";
            treeNode9.Text = "节点10";
            treeNode10.Name = "节点15";
            treeNode10.Text = "节点15";
            treeNode11.Name = "节点13";
            treeNode11.Text = "节点13";
            treeNode12.Name = "节点17";
            treeNode12.Text = "节点17";
            treeNode13.Name = "节点18";
            treeNode13.Text = "节点18";
            treeNode14.Name = "节点16";
            treeNode14.Text = "节点16";
            treeNode15.Name = "节点14";
            treeNode15.Text = "节点14";
            treeNode16.Name = "节点11";
            treeNode16.Text = "节点11";
            treeNode17.Name = "节点12";
            treeNode17.Text = "节点12";
            treeNode18.Name = "节点7";
            treeNode18.Text = "节点7";
            treeNode19.Name = "节点8";
            treeNode19.Text = "节点8";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode8,
            treeNode18,
            treeNode19});
            this.treeView1.Size = new System.Drawing.Size(598, 538);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "签入";
            this.button1.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(618, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 112);
            this.textBox1.TabIndex = 3;
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "CheckInForm";
            this.Text = "CheckInForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}