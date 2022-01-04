using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Graphs
{
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
    public class PAthFromSrcToDestLCA
    {

        List<char> pathToStart = new List<char>();
        List<char> pathToDest = new List<char>();
        bool IsLcaFound = false;

        public string GetDir()
        {
            string s;
            Trees.TreeNode root = new Trees.TreeNode(5);
            root.left = new Trees.TreeNode(1);
            root.right = new Trees.TreeNode(2);
            root.left.left = new Trees.TreeNode(3);
            root.right.left = new Trees.TreeNode(6);
            root.right.right = new Trees.TreeNode(4);

            return GetDirections(root, 3, 6);
        }
        public string GetDirections(Trees.TreeNode root, int startValue, int destValue)
        {

            dfs(root, startValue, destValue, new List<char>());

            if (IsLcaFound)
            {
                StringBuilder result = new StringBuilder();

                int i = 0, j = 0;

                while (i < pathToStart.Count && j < pathToDest.Count)
                {
                    if (pathToStart[i] != pathToDest[j])
                        break;

                    i++; j++;
                }

                while (i < pathToStart.Count)
                {
                    result.Append("U");
                    i++;
                }

                while (j < pathToDest.Count)
                {
                    result.Append(pathToDest[j]);
                    j++;
                }

                return result.ToString();
            }

            return "";

        }

        public bool dfs(Trees.TreeNode root, int start, int dest, List<char> soFar)
        {
            if (root == null)
                return false;

            bool left = false, right = false;

            soFar.Add('L');
            left = dfs(root.left, start, dest, soFar);
            soFar.RemoveAt(soFar.Count - 1);

            soFar.Add('R');
            right = dfs(root.right, start, dest, soFar);
            soFar.RemoveAt(soFar.Count - 1);

            if (left && right) //root is lca
            {
                IsLcaFound = true;
                return true;
            }
            else if (left && root.val == start)
            {
                pathToStart = new List<char>(soFar);
                IsLcaFound = true;
                return true;
            }
            else if (left && root.val == dest)
            {
                pathToDest = new List<char>(soFar);
                IsLcaFound = true;
                return true;
            }
            else if (right && root.val == start)
            {
                pathToStart = new List<char>(soFar);
                IsLcaFound = true;
                return true;
            }
            else if (right && root.val == dest)
            {
                pathToDest = new List<char>(soFar);
                IsLcaFound = true;
                return true;
            }
            else if (root.val == start)
            {
                pathToStart = new List<char>(soFar);
                return true;
            }
            else if (root.val == dest)
            {
                pathToDest = new List<char>(soFar);
                return true;
            }
            
            return left || right || root.val == start || root.val == dest;
        }
    }
}
