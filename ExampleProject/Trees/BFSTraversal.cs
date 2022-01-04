using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleProject.Trees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Node
    {
        public int val;
        public IList<Node> children;
        public Node parent;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
    public class Solution
    {
        //LC 102
        public IList<IList<int>> LevelOrderBinaryTree(TreeNode root)
        {

            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);


            while (queue.Count > 0)
            {
                int numNodes = queue.Count;
                List<int> levelNodes = new List<int>();

                for (int i = 0; i < numNodes; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelNodes.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                result.Add(levelNodes);
            }

            return result;
        }

        //LC 107
        public IList<IList<int>> LevelOrderBinaryTreeBottomUp(TreeNode root)
        {

            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);


            while (queue.Count > 0)
            {
                int numNodes = queue.Count;
                List<int> levelNodes = new List<int>();

                for (int i = 0; i < numNodes; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelNodes.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                result.Add(levelNodes);
            }
            //result = (IList<IList<int>>)result.Reverse();
            Reverse(result);
            return result;
        }

        public void Reverse(IList<IList<int>> result)
        {
            if (result != null && result.Count > 0)
            {
                int start = 0, end = result.Count - 1;

                while (start < end)
                {
                    IList<int> temp = result[end];
                    result[end] = result[start];
                    result[start] = temp;
                    start++; end--;
                }
            }

        }

        //LC199 right view

        public IList<int> RightViewBinaryTree(TreeNode root)
        {

            IList<int> result = new List<int>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);


            while (queue.Count > 0)
            {
                int numNodes = queue.Count;

                TreeNode node = null;
                for (int i = 0; i < numNodes; i++)
                {
                    node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                result.Add(node.val);
            }

            return result;
        }

        //LC 103. Binary Tree Zigzag Level Order Traversal

        public IList<IList<int>> ZigZagBinaryTree(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            bool isReverse = false;

            while (queue.Count > 0)
            {
                int numNodes = queue.Count;
                List<int> levelNodes = new List<int>();

                for (int i = 0; i < numNodes; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelNodes.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                if (isReverse) levelNodes.Reverse();
                isReverse = !isReverse;
                result.Add(levelNodes);
            }
            return result;
        }

        //LC 429. N-ary Tree Level Order Traversal
        public IList<IList<int>> LevelOrderNary(Node root)
        {

            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);


            while (queue.Count > 0)
            {
                int numNodes = queue.Count;
                List<int> levelNodes = new List<int>();

                for (int i = 0; i < numNodes; i++)
                {
                    Node node = queue.Dequeue();
                    levelNodes.Add(node.val);
                    if (node.children != null)
                    {
                        foreach (Node n in node.children)
                            queue.Enqueue(n);
                    }

                }
                result.Add(levelNodes);
            }
            return result;
        }
    }
}
