using JoeySoft.FromCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoeySoft.TfsDevelopWinFrom
{
    public partial class CheckInForm : Form
    {
        public CheckInForm()
        {
            InitializeComponent();
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //只处理鼠标点击引起的状态变化  
            if (e.Action == TreeViewAction.ByMouse)
            {
                //更新子节点状态  
                UpdateChildNodes(e.Node);
            }
        }

        private void UpdateChildNodes(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = node.Checked;
                UpdateChildNodes(child);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //只处理鼠标点击引起的状态变化  
            if (e.Action == TreeViewAction.ByMouse)
            {
                //更新子节点状态  
                UpdateChildNodes(e.Node);

                //更新父节点状态  
                UpdateParents(e.Node);
            }
        }


        private void UpdateParents(TreeNode node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                //设置父节点状态  
                SetNodeState(parent);
                parent = parent.Parent;
            }
        }

        private void SetNodeState(TreeNode parent)
        {
            //if (parent.Nodes.IsAllChecked())
            //{
            //    //子节点全选中  
            //    parent.Checked = true;
            //    parent.Tag = 1;
            //}
            //else if (parent.Nodes.IsAllUnChecked())
            //{
            //    //子节点全未选中  
            //    parent.Checked = false;
            //    parent.Tag = 0;
            //    //还要判断子节点中是否有半选中状态  
            //    foreach (TreeNode child in parent.Nodes)
            //    {
            //        if (child.Tag != null && (int)child.Tag == 2)
            //        {
            //            //用蓝色标记半选中状态  
            //            parent.Tag = 2;
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    //子节点有的选中有的未选中  
            //    parent.Checked = false;
            //    parent.Tag = 2;
            //}
            if (parent.Nodes.IsAllChecked())
            {
                //子节点全选中  
                parent.Checked = true;
                parent.ForeColor = Color.Black;
            }
            else if (parent.Nodes.IsAllUnChecked())
            {
                //子节点全未选中  
                parent.Checked = false;
                parent.ForeColor = Color.Black;
                //还要判断子节点中是否有半选中状态  
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.ForeColor == Color.Blue)
                    {
                        //用蓝色标记半选中状态  
                        parent.ForeColor = Color.Blue;
                        break;
                    }
                }
            }
            else
            {
                //子节点有的选中有的未选中  
                parent.Checked = false;
                parent.ForeColor = Color.Blue;
            }
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Bounds.Location.X <= 0)
            {
                return;
            }

            var treeview = sender as TreeView;
            var brush = Brushes.Black;
            if (e.Node.ForeColor == Color.Blue)
            {
                var location = e.Node.Bounds.Location;
                location.Offset(-11, 2);
                var size = new Size(9, 9);
                brush = Brushes.Blue;
                e.Graphics.FillRectangle(brush, new Rectangle(location, size));
            }
            //绘制文本  
            e.Graphics.DrawString(e.Node.Text, treeview.Font, brush, e.Bounds.Left, e.Bounds.Top);
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            ////只处理鼠标点击引起的状态变化  
            //if (e.Button == MouseButtons.Left)
            //{
            //    TreeNode tn = (TreeNode)sender;
            //    tn.Checked = !tn.Checked;
            //    //更新子节点状态  
            //    UpdateChildNodes(tn);
            //}
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //////只处理鼠标点击引起的状态变化  
            //if (e.Button == MouseButtons.Left)
            //{
            //    e.Node.Checked = !e.Node.Checked;
            //    //更新子节点状态  
            //    UpdateChildNodes(e.Node);
            //}
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Checked = !e.Node.Checked;
            UpdateChildNodes(e.Node);
        }
    }
}
