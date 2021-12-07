using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleProject.Trees
{
    public class BinaryTreeNode<T>
    {
        public int Key { get; set; }
        public T Value { get; set; }

        public BinaryTreeNode()
        {
        }
            public BinaryTreeNode(int key, T val)
        {
            Key = key;
            Value = val;
            LeftChild = null;
            RightChild = null;
        }

        public BinaryTreeNode(int key)
        {
            Key = key;
            LeftChild = null;
            RightChild = null;
        }

        public BinaryTreeNode<T> BuildTree(int[] arr)//1st index based tree parent = i, left = 2i, right = 2i+1
        {
            BinaryTreeNode<T> root = null;
            if (arr.Length >= 1)//atleast one node, 1st index based array
            {
                root = new BinaryTreeNode<T>(arr[1]);
                BuildTreeHelper(arr, 1, root);
            }

            return root;
        }

        public void BuildTreeHelper(int[] arr, int index, BinaryTreeNode<T> parent)//1st index based tree parent = i, left = 2i, right = 2i+1
        {
            if(index < arr.Length)
            {
                int left = 2 * index;
                int right = left + 1;

                if (left < arr.Length && arr[left] != int.MinValue)
                {
                    parent.LeftChild = new BinaryTreeNode<T>(arr[left]);
                    BuildTreeHelper(arr, left, parent.LeftChild);
                }
                else
                    parent.LeftChild = null;

                if (right < arr.Length && arr[right] != int.MinValue)
                {
                    parent.RightChild = new BinaryTreeNode<T>(arr[right]);
                    BuildTreeHelper(arr, right, parent.RightChild);
                }
                else
                    parent.RightChild = null;

            }
            return;
        }


        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

        public BinaryTreeNode<T> Search(BinaryTreeNode<T> root, int key)
        {
            BinaryTreeNode<T> curr = root;

            while (curr != null)
            {
                if (curr.Key == key)
                    return curr;
                else if (key < curr.Key)
                    curr = curr.LeftChild;
                else
                    curr = curr.RightChild;
            }
            return curr;

        }

        public BinaryTreeNode<T> FindMinKey(BinaryTreeNode<T> root)
        {
            if (root == null) return null;

            BinaryTreeNode<T> curr = root;

            while (curr.LeftChild != null)
            {
                curr = curr.LeftChild;
            }

            return curr;

        }

        public BinaryTreeNode<T> FindMax(BinaryTreeNode<T> root)
        {
            if (root == null) return null;

            BinaryTreeNode<T> curr = root;

            while (curr.RightChild != null)
            {
                curr = curr.RightChild;
            }

            return curr;
        }


        public BinaryTreeNode<T> FindSuccessor(BinaryTreeNode<T> root, BinaryTreeNode<T> p)
        {
            if (root == null) return null;

            BinaryTreeNode<T> curr = root;

            // if there is right child then min in that right tree will be successor
            if (p.RightChild != null)
            {
                curr = p.RightChild;
                while (curr.LeftChild != null)
                    curr = curr.LeftChild;
                return curr;
            }

            //maintian deepest such event where we go to the left child, and that node is successor

            BinaryTreeNode<T> ancestor = null;
            curr = root;
            while (p != curr)
            {
                if (p.Key < curr.Key)
                {
                    ancestor = curr;
                    curr = curr.LeftChild;
                }
                else
                {
                    curr = curr.RightChild;
                }
            }
            return ancestor;//if null is returned that means thats the max element of the tree and has no ancestor 
        }


        public BinaryTreeNode<T> FindPredecessor(BinaryTreeNode<T> root, BinaryTreeNode<T> p)
        {
            if (root == null) return null;

            BinaryTreeNode<T> curr = root;

            // if there is left child then max in that right tree will be predecessor
            if (p.LeftChild != null)
            {
                curr = p.LeftChild;
                while (curr.RightChild != null)
                    curr = curr.RightChild;
                return curr;
            }

            //starting from root, maintian deepest such event where we go to the right child, and that node is successor

            BinaryTreeNode<T> predecessor = null;
            curr = root;
            while (p != curr)
            {
                if (p.Key > curr.Key)
                {
                    predecessor = curr;
                    curr = curr.RightChild;
                }
                else
                {
                    curr = curr.LeftChild;
                }
            }
            return predecessor;//if null is returned that means thats the min element of the tree and has no predecessor 
        }

        public BinaryTreeNode<T> Insert(BinaryTreeNode<T> root, int key, T value)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(key, value);

            if (root == null)
                return newNode;

            BinaryTreeNode<T> prev = null;
            BinaryTreeNode<T> curr = root;

            while (curr != null)
            {
                if (curr.Key == key)
                    return root;
                else if (key < curr.Key)
                {
                    prev = curr;
                    curr = curr.LeftChild;
                }
                else
                {
                    prev = curr;
                    curr = curr.RightChild;
                }
            }

            if (key < prev.Key)
                prev.LeftChild = newNode;
            else if (key > prev.Key)
                prev.RightChild = newNode;

            return root;

        }

        public BinaryTreeNode<T> Delete(BinaryTreeNode<T> root, int key)
        {
            if (root != null)
            {
                BinaryTreeNode<T> curr = root;
                BinaryTreeNode<T> prev = null;

                while (curr != null)
                {
                    if (key == curr.Key)
                    {
                        break;
                    }
                    if (key < curr.Key)
                    {
                        prev = curr;
                        curr = curr.LeftChild;
                    }
                    else if (key > curr.Key)
                    {
                        prev = curr;
                        curr = curr.RightChild;
                    }
                }

                BinaryTreeNode<T> child = null;
                BinaryTreeNode<T> successor = null;

                if (curr.RightChild != null && curr.LeftChild != null)// node has both childrens
                {
                    successor = curr.RightChild; //find successor (this can be implemented with predecessor as well)
                    prev = curr;
                    while (successor.LeftChild != null)
                    {
                        prev = successor;
                        successor = successor.LeftChild;
                    }

                    curr.Key = successor.Key; // replace curr with successor 
                    curr = successor; // set successor to be the new node to be deleted
                }

                if (curr.LeftChild == null && curr.RightChild == null) //leaf node
                    child = null;

                if (curr.LeftChild != null && curr.RightChild == null) // node has only left child
                    child = curr.LeftChild;

                if (curr.RightChild != null && curr.LeftChild == null)// node has only right child
                    child = curr.RightChild;

                if (prev != null)
                {
                    if (curr == prev.RightChild) prev.RightChild = child;
                    if (curr == prev.LeftChild) prev.LeftChild = child;
                    return root;
                }
                else
                {
                    return child; // new root
                }
            }
            return root;
        }

        public void BFSTraversal(BinaryTreeNode<T> root)
        {
            if (root == null) return;
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                BinaryTreeNode<T> node = queue.Dequeue();
                Console.WriteLine($"{node.Key},");
                if(root.LeftChild != null) queue.Enqueue(root.LeftChild);
                if (root.RightChild != null) queue.Enqueue(root.RightChild);
            }
        }

        public List<List<int>> GetValuesByLevel(BinaryTreeNode<T> root)//BFS traversal
        {
            List<List<int>> result = new List<List<int>>();

            if (root != null)
            {
                Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    int currCount = queue.Count;
                    List<int> currLevelQ = new List<int>();

                    for (int i = 0; i < currCount; i++)
                    {
                        BinaryTreeNode<T> node = queue.Dequeue();
                        currLevelQ.Add(node.Key);
                        if (root.LeftChild != null) queue.Enqueue(root.LeftChild);
                        if (root.RightChild != null) queue.Enqueue(root.RightChild);
                    }
                    result.Add(currLevelQ);
                }
            }

            return result;
        }


        public List<int> RightSideViewByLevel(BinaryTreeNode<T> root)//BFS traversal
        {
            List<int> result = new List<int>();

            if (root != null)
            {
                Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    int currCount = queue.Count;
                    int rightmostElement = 0;

                    for (int i = 0; i < currCount; i++)
                    {
                        BinaryTreeNode<T> node = queue.Dequeue();
                        rightmostElement = node.Key;
                        if (root.LeftChild != null) queue.Enqueue(root.LeftChild);
                        if (root.RightChild != null) queue.Enqueue(root.RightChild);
                    }
                    result.Add(rightmostElement);
                }
            }
            return result;
        }


        public List<List<int>> GetValuesByLevelInZigZagOrder(BinaryTreeNode<T> root)//BFS traversal
        {
            List<List<int>> result = new List<List<int>>();

            if (root != null)
            {
                Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
                queue.Enqueue(root);
                bool reverse = false;

                while (queue.Count > 0)
                {
                    int currCount = queue.Count;
                    List<int> currLevelQ = new List<int>();

                    for (int i = 0; i < currCount; i++)
                    {
                        BinaryTreeNode<T> node = queue.Dequeue();
                        currLevelQ.Add(node.Key);
                        if (root.LeftChild != null) queue.Enqueue(root.LeftChild);
                        if (root.RightChild != null) queue.Enqueue(root.RightChild);
                    }

                    if (reverse)
                        currLevelQ.Reverse();

                    reverse = !reverse;

                    result.Add(currLevelQ);
                }
            }

            return result;
        }

        public List<List<int>> GetValuesByBottomUpLevel(BinaryTreeNode<T> root)//BFS traversal
        {
            List<List<int>> result = new List<List<int>>();

            if (root != null)
            {
                Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    int currCount = queue.Count;
                    List<int> currLevelQ = new List<int>();

                    for (int i = 0; i < currCount; i++)
                    {
                        BinaryTreeNode<T> node = queue.Dequeue();
                        currLevelQ.Add(node.Key);
                        if (root.LeftChild != null) queue.Enqueue(root.LeftChild);
                        if (root.RightChild != null) queue.Enqueue(root.RightChild);
                    }
                    result.Add(currLevelQ);
                }
            }

            result.Reverse(); //bottom up
            return result;
        }

        public List<List<int>> AllPathsOfABinaryTreeRecursive(BinaryTreeNode<T> root)
        {
            List<List<int>> result = new List<List<int>>();
            if (root != null)
                AllPathsOfABinaryTreeRecursiveHelper(root, new List<int>(), result);
            return result;
        }

        public void AllPathsOfABinaryTreeRecursiveHelper(BinaryTreeNode<T> root, List<int> soFar, List<List<int>> result)
        {
            //base case
            if(root.LeftChild == null && root.RightChild == null)
            {
                soFar.Add(root.Key);//add leaf
                result.Add(new List<int>(soFar)); //make sure to make a new copy of the list
                soFar.RemoveAt(soFar.Count - 1);//remove leaf
                return;
            }
            
            //add currNode
            soFar.Add(root.Key);
            //recurse
            if (root.LeftChild != null) AllPathsOfABinaryTreeRecursiveHelper(root.LeftChild, soFar, result);
            if (root.RightChild != null) AllPathsOfABinaryTreeRecursiveHelper(root.RightChild, soFar, result);
            //remove currNode
            soFar.RemoveAt(soFar.Count - 1);
        }

        public List<List<int>> AllPathsOfABinaryTreeIterative(BinaryTreeNode<T> root)
        {
            List<List<int>> result = new List<List<int>>();
            Stack<BinaryTreeNode<T>> stackNode = new Stack<BinaryTreeNode<T>>();
            Stack<List<int>> stackPath = new Stack<List<int>>();

            if (root != null)
            {
                stackNode.Push(root);
                stackPath.Push(new List<int>() { root.Key });

                while(stackNode.Count > 0)
                {
                    BinaryTreeNode<T> currNode = stackNode.Pop();
                    List<int> currList = stackPath.Pop();

                    if (currNode.LeftChild == null && currNode.RightChild == null)
                        result.Add(currList);

                    if (currNode.LeftChild != null)
                    {
                        List<int> leftList = currList.Append(currNode.LeftChild.Key).ToList();
                        stackPath.Push(leftList);
                        stackNode.Push(currNode.LeftChild);
                    }

                    if (currNode.RightChild != null)
                    {
                        List<int> rightList = currList.Append(currNode.RightChild.Key).ToList();
                        stackPath.Push(rightList);
                        stackNode.Push(currNode.RightChild);
                    }
                }
                
            }

            return result;
        }

        public List<int> PostOrderTraversalIterative(BinaryTreeNode<T> root)
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();//start with root and then push L R
            List<int> postOrder = new List<int>();
            
            if (root != null)
            {
                stack.Push(root);
                while (stack.Count > 0)
                {
                    BinaryTreeNode<T> currNode = stack.Pop();
                    postOrder.Add(currNode.Key);

                    if (currNode.LeftChild != null)
                        stack.Push(currNode.LeftChild);

                    if (currNode.RightChild != null)
                        stack.Push(currNode.RightChild);
                }
            }
            postOrder.Reverse();
            return postOrder;
        }

        public List<int> PreOrderTraversalIterative(BinaryTreeNode<T> root)
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();//start with root and then push R L
            List<int> preOrder = new List<int>();

            if (root != null)
            {
                stack.Push(root);
                while (stack.Count > 0)
                {
                    BinaryTreeNode<T> currNode = stack.Pop();
                    preOrder.Add(currNode.Key);

                    if (currNode.RightChild != null)
                        stack.Push(currNode.RightChild);

                    if (currNode.LeftChild != null)
                        stack.Push(currNode.LeftChild);
                }
            }
            return preOrder;
        }

        public void InOrderTraversal(BinaryTreeNode<T> root)
        {
            if (root == null) return;

            InOrderTraversal(root.LeftChild);
            Console.WriteLine($"{root.Key},");
            InOrderTraversal(root.RightChild);
        }

        public List<int> PreOrderTraversal(BinaryTreeNode<T> root)
        {
            List<int> result = new List<int>();
            if (root != null)
            {
                PreOrderTraversalHelper(root, result);
            }
            return result;
        }

        public void PreOrderTraversalHelper(BinaryTreeNode<T> root, List<int> result)
        {
            result.Add(root.Key);
            if(root.LeftChild != null) PreOrderTraversalHelper(root.LeftChild, result);
            if(root.RightChild != null) PreOrderTraversalHelper(root.RightChild, result);
        }

        public void PostOrderTraversal(BinaryTreeNode<T> root)
        {
            if (root == null) return;

            InOrderTraversal(root.LeftChild);
            InOrderTraversal(root.RightChild);
            Console.WriteLine($"{root.Key},");
        }

        public BinaryTreeNode<T> ReconstructTreeFromPreInorderTraversal(int[] preOrder, int[] inOrder)
        {
            return null;
        }

        public BinaryTreeNode<T> ReconstructTreeFromPreInorderTraversalHelper(int[] preOrder, int[] inOrder, int start, int end)
        {
            return null;
        }

        public BinaryTreeNode<T> ReconstructTreeFromPostInorderTraversal(int[] postOrder, int[] inOrder)
        {
            return null;
        }

        public BinaryTreeNode<T> ReconstructTreeFromPostInorderTraversalHelper(int[] postOrder, int[] inOrder, int start, int end)
        {
            return null;
        }

        public BinaryTreeNode<T> ReconstructBinarySearchTreeFromPreOrderTraversal(int[] preOrder)
        {
            return null;
        }

        public BinaryTreeNode<T> ReconstructBinarySearchTreeFromPreOrderTraversalHelper(int[] preOrder, int[] inOrder, int start, int end)
        {
            return null;
        }

        public BinaryTreeNode<T> ReconstructBinarySearchTreeFromPostOrderTraversalHelper(int[] postOrder, int[] inOrder, int start, int end)
        {
            return null;
        }
        public BinaryTreeNode<T> ReconstructBinarySearchTreeFromPostOrderTraversal(int[] postOrder)
        {
            return null;
        }

        public bool RootToLeafPathSum(BinaryTreeNode<T> root, int sum)
        {
            if (root == null) return false;
            return RootToLeafPathSumHelper(root, sum, 0);
        }

        public bool RootToLeafPathSumHelper(BinaryTreeNode<T> root, int sum, int runningSum) //tree might have -v value so make sure to go till leaf to find out if target sum is achieved
        {
            bool leftPath = false, rightPath = false;

            if (root != null)
            {
                if(root.LeftChild == null && root.RightChild == null)
                {
                   return (sum == (runningSum + root.Key));
                }
                if(root.LeftChild != null) leftPath = RootToLeafPathSumHelper(root.LeftChild, sum, runningSum + root.Key);
                if (leftPath) return leftPath; //return early if we have already fond the path
                if (root.RightChild != null) rightPath = RootToLeafPathSumHelper(root.RightChild, sum, runningSum + root.Key);
            }
            return leftPath || rightPath;
        }

        public List<List<int>> RootToLeafPathSum2(BinaryTreeNode<T> root, int sum)//time and space is N(log N)  top down DFS
        {
            List<List<int>> result = new List<List<int>>();
            if (root == null) return result;
            RootToLeafPathSumHelper2(root, sum, 0, new List<int>(), result);

            return result;
        }

        public void RootToLeafPathSumHelper2(BinaryTreeNode<T> root, int sum, int runningSum, List<int> runningArr, List<List<int>> result) //tree might have -v value so make sure to go till leaf to find out if target sum is achieved
        {
            if (root != null)
            {
                runningArr.Add(root.Key);
                if (root.LeftChild == null && root.RightChild == null)
                {
                    if (sum == (runningSum + root.Key))
                    {
                        result.Add(new List<int>(runningArr));
                        runningArr.RemoveAt(runningArr.Count - 1);//we return immediately from here so remove
                        return; //this can be removed too as it will directly go to removeAt() line below and then return
                    }
                }
                if (root.LeftChild != null)
                {
                    RootToLeafPathSumHelper2(root.LeftChild, sum, runningSum + root.Key, runningArr, result);
                }

                if (root.RightChild != null)
                {
                    RootToLeafPathSumHelper2(root.RightChild, sum, runningSum + root.Key, runningArr, result);
                }

                runningArr.RemoveAt(runningArr.Count - 1); //if node is added it needs to be removed before it returns
            }

            return;
        }

        public int MaxDiameterOfBinaryTree(BinaryTreeNode<T> root)//bottom up DFS
        {
            int[] result = new int[0];
            if (root == null) return 0;
            DiameterOfBinaryTreeHelper(root, result);

            return result[0];
        }

        public int DiameterOfBinaryTreeHelper(BinaryTreeNode<T> root, int[] result)
        {
            if (root != null)
            {
                int leftHeight = 0, rightHeight = 0, currDiameter = 0;

                if (root.LeftChild == null && root.RightChild == null)
                   return 0;

                if (root.LeftChild != null)
                {
                    leftHeight = DiameterOfBinaryTreeHelper(root.LeftChild, result) + 1;
                }

                if (root.RightChild != null)
                {
                    rightHeight = DiameterOfBinaryTreeHelper(root.RightChild, result) + 1;
                }

                currDiameter = leftHeight + rightHeight;

                result[0] = Math.Max(currDiameter, result[0]);

                return leftHeight > rightHeight ? leftHeight : rightHeight;
            }
            return 0;
        }

        //Given a binary tree, find the number of unival subtrees.
        //An unival tree is a tree that has the same value in every node.
        public int NumOfUniValueSubTrees(BinaryTreeNode<T> root)//bottom up DFS, Time O(n)  Space avg O(log n) worst O(n)
        {
            int[] result = new int[0];
            if (root == null) return 0;
            NumOfUniValueSubTreesHelper(root, result);

            return result[0];
        }

        public bool NumOfUniValueSubTreesHelper(BinaryTreeNode<T> root, int[] result)
        {
                bool leftUniVal = true, rightUniVal = true, amIUniVal = false; //if one of the children are not present then the value never gets set to true and causes solution to fail..e.g.consider only 2 nodes in a tree

                if (root.LeftChild == null && root.RightChild == null) //leaf node
                    return true;

                if (root.LeftChild != null)
                {
                    leftUniVal = NumOfUniValueSubTreesHelper(root.LeftChild, result) && root.Key == root.LeftChild.Key;
                }

                if (root.RightChild != null)
                {
                    rightUniVal = NumOfUniValueSubTreesHelper(root.RightChild, result) && root.Key == root.RightChild.Key;
                }

                if (leftUniVal && rightUniVal)
                    amIUniVal = true;

                if(amIUniVal)
                   result[0] = result[0] + 1;

                return amIUniVal;
        }

        public bool IsBSTUsingInOrderTraversal(BinaryTreeNode<T> root)
        {
            return IsBSTUsingInOrderTraversalHelper(root, new List<int>());
        }
        public bool IsBSTUsingInOrderTraversalHelper(BinaryTreeNode<T> root, List<int> lastValue)
        {
            if (root == null) return true;

            if (!IsBSTUsingInOrderTraversalHelper(root.LeftChild, lastValue))
                return false;

            if (lastValue.Count > 0 && root.Key <= lastValue[0]) return false;
            else if (lastValue.Count == 0) lastValue.Add(root.Key);
            else lastValue[0] = root.Key;

            return IsBSTUsingInOrderTraversalHelper(root.RightChild, lastValue);
        }

        public bool IsBST(BinaryTreeNode<T> root)//bottom up DFS, Time O(n)  Space O (n)
        {//however this implementaiton has a flaw cause it cannot accurately capture all scenarios of invalid BSTs
            //e,g, [5,4,6,null,null,3,7]  it fails for this, Hence use inorder traversal implementation
            if (root == null) return true;
            List<int> leftList = new List<int>(root.Key);
            List<int> righttList = new List<int>(root.Key);
            return IsBSTHelper(root, leftList, righttList);
        }

        public bool IsBSTHelper(BinaryTreeNode<T> root, List<int> leftList, List<int> righttList)
        {
            if (root != null)
            {
                bool leftBST = true, rightBST = true; //if one of the children are not present then the value never gets set to true and causes solution to fail..e.g.consider only 2 nodes in a tree

                if (root.LeftChild == null && root.RightChild == null) //leaf node
                    return true;

                if (root.LeftChild != null)
                {
                    leftList.Add(root.Key);
                    leftBST = IsBSTHelper(root.LeftChild, leftList, righttList) && root.LeftChild.Key <= root.Key;
                    leftList.RemoveAt(leftList.Count - 1);
                    if (leftList.Where(i => root.Key >= i).Any())//isCurrGreaterthanParents
                        return false;

                }

                if (root.RightChild != null)
                {
                    righttList.Add(root.Key);
                    rightBST = IsBSTHelper(root.RightChild, leftList, righttList) && root.RightChild.Key >= root.Key;
                    righttList.RemoveAt(righttList.Count - 1);
                    if (righttList.Where(i => root.Key <= i).Any())//isCurrLesserthanParents
                        return false;
                }

                return leftBST && rightBST;
            }

            return false ;
        }
        public BinaryTreeNode<int> AscSortedArrayToBST(int[] arr)
        {
            if (arr.Length > 0)
                return AscSortedArrayToBSTHelper(arr, 0, arr.Length - 1);

            return null;
        }

        public BinaryTreeNode<int> AscSortedArrayToBSTHelper(int[] arr, int start, int end)
        {
            if (start > end)
                return null;

            if(start == end)
                return new BinaryTreeNode<int>(arr[start], start);

            int mid = (start + end) / 2;

            BinaryTreeNode<int> root = new BinaryTreeNode<int>(arr[mid], mid);
            root.LeftChild = AscSortedArrayToBSTHelper(arr, start, mid - 1);
            root.RightChild = AscSortedArrayToBSTHelper(arr, mid + 1, end);

            return root;
        }

        BinaryTreeNode<T> sentinel = null; // create one extra node to keep pointint to the head of the tree;
        BinaryTreeNode<T> predecessor = null;

        public BinaryTreeNode<T> BTtoDoublyLinkedListInorderTraversal( BinaryTreeNode<T> root)
        {
            if (root == null) return null;//this is important ptherwise "predecessor.RightChild = sentinel;" will throw null pointer
            BTtoDoublyLinkedListInorderTraversalHelper(root);
            predecessor.RightChild = sentinel;
            sentinel.LeftChild = predecessor;
            return sentinel; // root
        }

        public void BTtoDoublyLinkedListInorderTraversalHelper(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                if (node.LeftChild != null) BTtoDoublyLinkedListInorderTraversalHelper(node.LeftChild);
                if (predecessor != null)
                {
                    predecessor.RightChild = node;
                    node.LeftChild = predecessor;
                }
                else
                {
                    sentinel = node;
                }
                predecessor = node;

                if (node.RightChild != null) BTtoDoublyLinkedListInorderTraversalHelper(node.RightChild);
            }
        }

        /* public int LeastCommonAncestor(BinaryTreeNode<int> root)
         * {
         * return -1;
         * }
         * 
         * 
         * BinaryTreeNode<T> MergeTwoBSTs(BinaryTreeNode<T> root)
         * {
         *  return null;
         *  
         *  2) list_merging_solution.java
                  Store values of BST-1 in an array, using the in-order traversal to keep them sorted.
                  Store values of BST-2 in another array, using in-order traversal.
                  Merge the two arras into a new sorted array (as we do in merge sort or in “Merge One Sorted Array Into Another” problem).
                  Build a balanced BST using recursive function build(). This is explained in detail in “Balanced BST From A Sorted Array” problem.

                  Time Complexity:
                  O(N1 + N2).
                  Time complexity of the first operation is O(N1).
                  Time complexity of the second operation is O(N2).
                  Time complexity of the third operation is O(N1 + N2).
                  Time complexity of the fourth operation is O(N1 + N2) as we visit each node once and do a constant amount of work per node.

                  Auxiliary Space Used:
                  O(N1 + N2).

                  Space Complexity: 
                  O(N1 + N2).

         * }
         * public BinaryTreeNode<int> InPreOrderArrayToBinaryTree(int[] preOrder, int[] inOrder)
         {
             if (inOrder.Length > 0 && preOrder.Length == inOrder.Length)
                 return InPreOrderArrayToBinaryTreeHelper(preOrder, inOrder,0, 0, inOrder.Length - 1);

             return null;
         }

         public BinaryTreeNode<int> InPreOrderArrayToBinaryTreeHelper(List<int> preOrder, List<int> inOrder, int preOrderIndex, int inOrderStart, int inOrderEnd)
         {
             if (inOrderStart > inOrderEnd)
                 return null;

             if (inOrderStart == inOrderEnd)
                 return new BinaryTreeNode<int>(inOrder[inOrderStart]);

             BinaryTreeNode<int> root = new BinaryTreeNode<int>(preOrder[preOrderIndex]);

             int preOrderFoundInsideInOrder = inOrder.IndexOf()

             root.LeftChild = AscSortedArrayToBSTHelper(arr, start, mid - 1);
             root.RightChild = AscSortedArrayToBSTHelper(arr, mid + 1, end);

             return root;
         }

         public BinaryTreeNode<int> TreeToPredecessorSuccessorDoublyLinkedList(List<int> preOrder, List<int> inOrder)
         {
             if (inOrder.Count > 0 && preOrder.Count == inOrder.Count)
                 return TreeToPredecessorSuccessorDoublyLinkedListHelper(preOrder, inOrder, 0, 0, inOrder.Count - 1);

             return null;
         }

         public BinaryTreeNode<T> TreeToPredecessorSuccessorDoublyLinkedListHelper(List<int> preOrder, List<int> inOrder, int preOrderIndex, int inOrderStart, int inOrderEnd)
         {
             return null;
         }*/

    }
}
