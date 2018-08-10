using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartSolutions.Controls;

namespace JoeySoft.FromCore
{
    /// <summary>
    /// 树形控件帮助类
    /// </summary>
    public static class TriStateTreeNodeHelper
    {
        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="treeNodeCollection"></param>
        /// <param name="isChecked"></param>
        public static void Checked(TriStateTreeView tstv, TreeNode tNode, bool isChecked)
        {
            foreach (TriStateTreeNode node in tNode.Nodes)
            {
                node.Checked = isChecked;
            }
            tstv.Refresh();
        }

        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="treeNodeCollection"></param>
        /// <param name="isChecked"></param>
        public static void Checked(TriStateTreeView tstv, bool isChecked)
        {
            foreach (TriStateTreeNode node in tstv.Nodes)
            {
                node.Checked = isChecked;
            }
            tstv.Refresh();
        }

        /// <summary>
        /// 获取要编辑签入的文件信息
        /// </summary>
        /// <returns></returns>
        public static List<FileInfo> GetTreeNodeChecked(TreeNodeCollection nodes)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            List<TriStateTreeNode> treeNodes = new List<TriStateTreeNode>();
            foreach (TriStateTreeNode treeNode in nodes)
            {
                treeNodes.AddRange(GetCheckedNodes(treeNode));
            }
            foreach (var treeNode in treeNodes)
            {
                if (treeNode.Tag is FileInfo)
                {
                    fileInfos.Add(treeNode.Tag as FileInfo);
                }
            }
            return fileInfos;
        }

        /// <summary>
        /// 获取子集
        /// </summary>
        /// <returns></returns>
        private static List<TriStateTreeNode> GetCheckedNodes(TriStateTreeNode treeNode)
        {
            List<TriStateTreeNode> childNodeList = new List<TriStateTreeNode>();
            foreach (TriStateTreeNode childNode in treeNode.Nodes)
            {
                childNodeList.AddRange(GetCheckedNodes(childNode));
            }
            if (treeNode.Nodes.Count == 0 && treeNode.Checked == true)
            {
                childNodeList.Add(treeNode);
            }
            return childNodeList;
        }
    }
}
