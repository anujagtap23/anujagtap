using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Trees
{
    public class UnivalTrees
    {

        private int Result = 0;

        public int CountUnivalSubtrees(TreeNode root)
        {//bottom up DFS, Time O(n)  Space avg O(log n) worst O(n)


            if (root == null) return 0;
            NumOfUniValueSubTreesHelper(root);

            return this.Result;
        }

        public bool NumOfUniValueSubTreesHelper(TreeNode root)
        {
            if (root != null)
            {
                bool leftUniVal = false, rightUniVal = false, amIUniVal = false;

                if (root.left == null && root.right == null) //leaf node
                {
                    this.Result += 1;
                    return true;
                }

                if (root.left != null)
                {
                    leftUniVal = NumOfUniValueSubTreesHelper(root.left) && root.val == root.left.val;
                }

                if (root.right != null)
                {
                    rightUniVal = NumOfUniValueSubTreesHelper(root.right) && root.val == root.right.val;
                }

                if ((leftUniVal || root.left == null) && (rightUniVal || root.right == null))
                    amIUniVal = true;

                if (amIUniVal)
                    this.Result += 1;

                return amIUniVal;
            }
            return false;
        }

    }
}
