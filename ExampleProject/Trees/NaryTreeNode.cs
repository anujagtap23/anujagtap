using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Trees
{
    public class NaryTreeNode
    {
        public int Value { get; set; }

        public List<NaryTreeNode> Children { get; set; }



        public NaryTreeNode(int val)
        {
            Value = val;
            Children = new List<NaryTreeNode>();
        }

        public List<List<int>> GetValuesByLevel(NaryTreeNode root)//BFS traversal
        {
            List<List<int>> result = new List<List<int>>();

            if (root != null)
            {
                Queue<NaryTreeNode> queue = new Queue<NaryTreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    int currCount = queue.Count;
                    List<int> currLevelQ = new List<int>();

                    for (int i = 0; i < currCount; i++)
                    {
                        NaryTreeNode node = queue.Dequeue();
                        currLevelQ.Add(node.Value);
                        if (root.Children != null)
                        {
                            foreach (NaryTreeNode child in root.Children)
                                queue.Enqueue(child);
                        }
                    }
                    result.Add(currLevelQ);
                }
            }

            return result;
        }

        public List<List<int>> GetValuesByBottomUpLevel(NaryTreeNode root)//BFS traversal
        {
            List<List<int>> result = new List<List<int>>();

            if (root != null)
            {
                Queue<NaryTreeNode> queue = new Queue<NaryTreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    int currCount = queue.Count;
                    List<int> currLevelQ = new List<int>();

                    for (int i = 0; i < currCount; i++)
                    {
                        NaryTreeNode node = queue.Dequeue();
                        currLevelQ.Add(node.Value);
                        if (root.Children != null)
                        {
                            foreach (NaryTreeNode child in root.Children)
                                queue.Enqueue(child);
                        }
                    }
                    result.Add(currLevelQ);
                }
            }

            result.Reverse(); //bottom up
            return result;
        }

        public List<List<int>> GetValuesByLevelInZigZagOrder(NaryTreeNode root)//BFS traversal
        {
            List<List<int>> result = new List<List<int>>();

            if (root != null)
            {
                Queue<NaryTreeNode> queue = new Queue<NaryTreeNode>();
                queue.Enqueue(root);
                bool reverse = false;

                while (queue.Count > 0)
                {
                    int currCount = queue.Count;
                    List<int> currLevelQ = new List<int>();

                    for (int i = 0; i < currCount; i++)
                    {
                        NaryTreeNode node = queue.Dequeue();
                        currLevelQ.Add(node.Value);
                        if (root.Children != null)
                        {
                            foreach (NaryTreeNode child in root.Children)
                                queue.Enqueue(child);
                        }
                    }

                    if (reverse)
                        currLevelQ.Reverse();

                    reverse = !reverse;
                    result.Add(currLevelQ);
                }
            }

            return result;
        }

        public List<int> RightSideViewByLevel(NaryTreeNode root)//BFS traversal
        {
            List<int> result = new List<int>();

            if (root != null)
            {
                Queue<NaryTreeNode> queue = new Queue<NaryTreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    int currCount = queue.Count;
                    int rightMostElement = 0;

                    for (int i = 0; i < currCount; i++)
                    {
                        NaryTreeNode node = queue.Dequeue();
                        rightMostElement = node.Value;
                        if (root.Children != null)
                        {
                            foreach (NaryTreeNode child in root.Children)
                                queue.Enqueue(child);
                        }
                    }
                    result.Add(rightMostElement);
                }
            }

            return result;
        }

        private int result = 0;

        //559. Maximum Depth of N-ary Tree
        public int MaxDepth(NaryTreeNode root)
        {

            if (root != null)
                MaxDepthHelper(root, 1);
            return result;
        }

        public void MaxDepthHelper(NaryTreeNode root, int height)
        {
            if (root.Children == null || root.Children.Count == 0)
                result = Math.Max(result, height);
            else
            {

                if (root.Children != null || root.Children.Count > 0)
                {
                    foreach (NaryTreeNode child in root.Children)
                    {
                        MaxDepthHelper(child, height + 1);
                    }
                }
            }
        }

    }
}
