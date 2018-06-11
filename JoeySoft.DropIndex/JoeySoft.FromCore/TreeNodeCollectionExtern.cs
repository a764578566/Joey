using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoeySoft.FromCore
{
    public static class TreeNodeCollectionExtern
    {
        public static bool IsAllChecked(this TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.Checked == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsAllUnChecked(this TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.Checked == true)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
