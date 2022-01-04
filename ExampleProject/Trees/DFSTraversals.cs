using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Trees
{


    class DFSTraversals
    {
        static bool globalResult = false;
        public bool HasPathSum(TreeNode root, int targetSum)
        {

            if (root == null) return false;

            CheckSum(root, targetSum, 0);
            return globalResult;

        }

        public void CheckSum(TreeNode node, int targetSum, int runningSum)
        {
            if (node.right == null && node.left == null)
            {
                if ((runningSum + node.val) == targetSum)
                    globalResult = true;

                return;
            }
            else
            {
                if (node.left != null) CheckSum(node.left, targetSum, runningSum + node.val);
                if (node.right != null) CheckSum(node.right, targetSum, runningSum + node.val);

            }
        }

        //LC 113. Path Sum II
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {

            IList<IList<int>> result = new List<IList<int>>();
            if (root != null)
                helper(root, targetSum, 0, new List<int>(), result);
            return result;
        }

        public void helper(TreeNode node, int targetSum, int runningSum, List<int> soFar, IList<IList<int>> result)
        {
            if (node.right == null && node.left == null)
            {
                if ((runningSum + node.val) == targetSum)
                {
                    soFar.Add(node.val);
                    result.Add(new List<int>(soFar));
                    soFar.RemoveAt(soFar.Count - 1);//very important
                }
                return;
            }
            else
            {
                if (node.left != null)
                {
                    soFar.Add(node.val);
                    helper(node.left, targetSum, runningSum + node.val, soFar, result);
                    soFar.RemoveAt(soFar.Count - 1);
                }
                if (node.right != null)
                {
                    soFar.Add(node.val);
                    helper(node.right, targetSum, runningSum + node.val, soFar, result);
                    soFar.RemoveAt(soFar.Count - 1);
                }

            }
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {

            if (nums == null || nums.Length == 0) return null;

            return helper(nums, 0, nums.Length - 1);

        }

        public TreeNode helper(int[] nums, int start, int end)
        {
            if (start > end)
                return null;
            else
            {
                int mid = (start + end) / 2;

                TreeNode root = new TreeNode(nums[mid]);
                root.left = helper(nums, start, mid - 1);
                root.right = helper(nums, mid + 1, end);
                return root;
            }
        }


        public TreeNode BuildTreeFromPre_InOrder(int[] preorder, int[] inorder)
        {

            if (preorder == null || inorder == null || preorder.Length != inorder.Length || preorder.Length == 0) return null;
            return BuildTreeHelper(preorder, 0, preorder.Length - 1, inorder, 0, preorder.Length - 1);

        }

        TreeNode BuildTreeHelper(int[] preOrder, int preIndx, int preIndxEnd, int[] inOrder, int start, int end)
        {
            if (start > end)
                return null;
            else
            {
                TreeNode root = new TreeNode(preOrder[preIndx]);
                int mid = GetRootIndex(inOrder, preOrder[preIndx]);
                int midLeft = mid - start;
                int midRight = end - mid;

                root.left = BuildTreeHelper(preOrder, preIndx + 1, preIndx + midLeft, inOrder, start, mid - 1);
                root.right = BuildTreeHelper(preOrder, preIndx + midLeft + 1, preIndxEnd, inOrder, mid + 1, end);

                return root;
            }
        }

        int GetRootIndex(int[] inOrder, int preVal)
        {
            for (int i = 0; i < inOrder.Length; i++)
                if (inOrder[i] == preVal)
                    return i;
            return -1;
        }

        //https://uplevel.interviewkickstart.com/resource/rc-codingproblem-10241-106155-51-318
        static List<List<int>> allPathsOfABinaryTree(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
            if (root != null)
                AllPathsOfABinaryTreeHelper(root, new List<int>(), result);
            return result;

        }

        static void AllPathsOfABinaryTreeHelper(TreeNode root, List<int> soFar, List<List<int>> result)
        {
            if (root.left == null && root.right == null)
            {
                soFar.Add(root.val);
                result.Add(new List<int>(soFar));
                soFar.RemoveAt(soFar.Count - 1);
                return;
            }
            else
            {
                soFar.Add(root.val);
                if (root.left != null)
                {
                    AllPathsOfABinaryTreeHelper(root.left, soFar, result);
                }

                if (root.right != null)
                {
                    AllPathsOfABinaryTreeHelper(root.right, soFar, result);
                }

                soFar.RemoveAt(soFar.Count - 1);
            }
        }

        static TreeNode treeRoot = null;
        static TreeNode flipUpsideDown(TreeNode root)
        {

            if (root == null)
            {
                return root;
            }

            flipUpsideDownHelper(root);
            return treeRoot;
        }

        //https://uplevel.interviewkickstart.com/resource/rc-codingproblem-10241-106155-51-322
        static void flipUpsideDownHelper(TreeNode root)
        {
            //basecase
            if (root.left == null && root.right == null)
            {
                treeRoot = root;
                return;
            }
            else
            {
                if (root.left != null)
                {
                    flipUpsideDownHelper(root.left);
                    TreeNode curr = root.left;
                    curr.left = root.right;
                    curr.right = root;
                    root.right = null;
                    root.left = null;
                }
            }
        }

        //https://uplevel.interviewkickstart.com/resource/rc-codingproblem-10241-106155-51-321
        //merge 2 BSTs 
        //convert two trees to inorder lists
        //merge to inorder lists
        //build binary search tree from the inorder list recursively

        //https://uplevel.interviewkickstart.com/resource/rc-codingproblem-10241-106155-51-317
        public static List<int> postorder_traversal_iterative(TreeNode root)
        {

            List<int> result = new List<int>();
            if (root != null)
            {
                Stack<TreeNode> stack1 = new Stack<TreeNode>();
                Stack<TreeNode> stack2 = new Stack<TreeNode>();

                stack1.Push(root);

                while (stack1.Count > 0)
                {
                    TreeNode node = stack1.Pop();

                    if (node.left != null)
                        stack1.Push(node.left);
                    if (node.right != null)
                        stack1.Push(node.right);

                    stack2.Push(node);
                }

                while (stack2.Count > 0)
                {
                    TreeNode node = stack2.Pop();
                    result.Add(node.val);
                }
            }

            return result;

        }


    }
}
