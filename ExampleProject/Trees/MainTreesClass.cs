using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Trees
{
    public static class MainTreesClass
    {
        public static void RunTreeProblems()
        {
            BinaryTreeNode<int> treeClass = new BinaryTreeNode<int>();
            BinaryTreeNode<int>  root = treeClass.BuildTree(new int[] { int.MinValue, 3, 1, 5, 0, 2, 4, 6});
            BinaryTreeNode<int> root1 = treeClass.BuildTree(new int[] { int.MinValue, 5, 4, 6, int.MinValue, int.MinValue, 3, 7});
            BinaryTreeNode<int> root2 = treeClass.BuildTree(new int[] { int.MinValue, 1, 1});
            BinaryTreeNode<int> root3 = treeClass.BuildTree(new int[] { int.MinValue, -2147483648 });

            bool result = treeClass.IsBST(root1); //however this implementaiton has a flaw cause it cannot accurately capture all scenarios of invalid BSTs
            //e,g, [5,4,6,null,null,3,7]  it fails for this, Hence use inorder traversal implementation

            bool inorderBST = treeClass.IsBSTUsingInOrderTraversal(root);//should return false
            inorderBST = treeClass.IsBSTUsingInOrderTraversal(root1);//should return false
            inorderBST = treeClass.IsBSTUsingInOrderTraversal(root2);//should return false
            inorderBST = treeClass.IsBSTUsingInOrderTraversal(root3);//should return true


            List<int> postOrderlistIterative = treeClass.PostOrderTraversalIterative(root);//0,2,1,4,6,5,3
            List<int> preOrderlistIterative = treeClass.PreOrderTraversalIterative(root);//3,1,0,2,5,4,6
            List<int> preOrderlistRecursive = treeClass.PreOrderTraversal(root);//3,1,0,2,5,4,6

            List<List<int>> allpaths = treeClass.AllPathsOfABinaryTreeIterative(root);
            List<List<int>> allpathsRecursive = treeClass.AllPathsOfABinaryTreeRecursive(root);

            BinaryTreeNode<int> dllroot = treeClass.BuildTree(new int[] { int.MinValue, 3, 1, 5, 0, 2, 4, 6 });
            BinaryTreeNode<int> dll = treeClass.BTtoDoublyLinkedListInorderTraversal(dllroot);
            BinaryTreeNode<int> prnt = dll;
            while(prnt.RightChild != dll)
            {
                Console.WriteLine(prnt.Key);
                prnt = prnt.RightChild;
            }
            Console.WriteLine(prnt.Key);

        }
    }
}
