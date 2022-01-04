using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Trees
{
    class LowestCommonAncestor
    {
		private TreeNode answer;

		public LowestCommonAncestor()
		{
			// Variable to store LCA node.
			this.answer = null;
		}

		//236. Lowest Common Ancestor of a Binary Tree
		public TreeNode LowestCommonAncestorFunc(TreeNode root, TreeNode p, TreeNode q)
		{

			LcaHelper(root, p, q);
			return answer;

		}

		public bool LcaHelper(TreeNode root, TreeNode a, TreeNode b)
		{
			if (root == null)
				return false;


			bool left = LcaHelper(root.left, a, b);
			bool right = LcaHelper(root.right, a, b);

			if (left && right)
			{
				answer = root;
			}
			else if ((left || right) && (root == a || root == b))
			{
				answer = root;
			}

			return left || right || root == a || root == b;

		}

		//another elegant solution
		//236. Lowest Common Ancestor of a Binary Tree
		private bool recurseTree(TreeNode currentNode, TreeNode p, TreeNode q)
		{

			// If reached the end of a branch, return false.
			if (currentNode == null)
			{
				return false;
			}

			// Left Recursion. If left recursion returns true, set left = 1 else 0
			int left = this.recurseTree(currentNode.left, p, q) ? 1 : 0;

			// Right Recursion
			int right = this.recurseTree(currentNode.right, p, q) ? 1 : 0;

			// If the current node is one of p or q
			int mid = (currentNode == p || currentNode == q) ? 1 : 0;


			// If any two of the flags left, right or mid become True
			if (mid + left + right >= 2)
			{
				this.answer = currentNode;
			}

			// Return true if any one of the three bool values is True.
			return (mid + left + right > 0);
		}

		//235. Lowest Common Ancestor of a Binary Search Tree
		public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{

			// Value of current node or parent node.
			int parentVal = root.val;

			// Value of p
			int pVal = p.val;

			// Value of q;
			int qVal = q.val;

			if (pVal > parentVal && qVal > parentVal)
			{
				// If both p and q are greater than parent
				return lowestCommonAncestor(root.right, p, q);
			}
			else if (pVal < parentVal && qVal < parentVal)
			{
				// If both p and q are lesser than parent
				return lowestCommonAncestor(root.left, p, q);
			}
			else
			{
				// We have found the split point, i.e. the LCA node.
				return root;
			}

			
		}
		//LC 1644. Lowest Common Ancestor of a Binary Tree II : above solution 235/236 works for this
		//LC 1257. Smallest Common Region: above solution 235/236 works for this

		//LC 1650. Lowest Common Ancestor of a Binary Tree III
		public Node LowestCommonAncestorWithParentOnly (Node p, Node q)
		{

			if (p == null) return q;
			if (q == null) return q;

			HashSet<Node> nodeSet = new HashSet<Node>();

			Node curr = p;
			nodeSet.Add(curr);
			while (curr.parent != null)
			{
				nodeSet.Add(curr.parent);
				curr = curr.parent;
			}

			if (nodeSet.Contains(q))
				return q;

			curr = q;
			while (curr.parent != null)
			{
				if (nodeSet.Contains(curr.parent))
					return curr.parent;
				else
					curr = curr.parent;
			}

			return null;

		}

		//LC 1676. Lowest Common Ancestor of a Binary Tree IV
		public TreeNode LowestCommonAncestorMultipleNodes(TreeNode root, TreeNode[] nodes)
		{

			if (root == null || nodes == null) return null;
			if (nodes.Length == 1) return nodes[0];
			recurseTree(root, nodes);
			return this.answer;
		}

		private bool recurseTree(TreeNode currentNode, TreeNode[] nodes)
		{

			// If reached the end of a branch, return false.
			if (currentNode == null)
			{
				return false;
			}

			// Left Recursion. If left recursion returns true, set left = 1 else 0
			int left = this.recurseTree(currentNode.left, nodes) ? 1 : 0;

			// Right Recursion
			int right = this.recurseTree(currentNode.right, nodes) ? 1 : 0;

			// If the current node is one of p or q
			int mid = DoesRootInNodes(currentNode, nodes) ? 1 : 0;


			// If any two of the flags left, right or mid become True
			if (mid + left + right >= 2)
			{
				this.answer = currentNode;
			}

			// Return true if any one of the three bool values is True.
			return (mid + left + right > 0);
		}

		private bool DoesRootInNodes(TreeNode root, TreeNode[] nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (root.val == node.val)
				{
					return true;
				}
			}

			return false;
		}
	}
}
