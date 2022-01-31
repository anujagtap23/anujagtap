using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ExampleProject.Trees
{
    public class MinCycleRequiredForSendingSignal
    {

        public class Node { public List<Node> Children ; }
        int minCycles = 0;
        Dictionary<Node, int> hmap = new Dictionary<Node, int>();

        public int CalculateMinCycles(Node root)
        {
            if (root != null)
            {
                CalculateMinCyclesHelper(root, 0);

                foreach (var key in hmap.Keys)
                {
                    minCycles = Math.Max(minCycles, hmap[key]);
                }
            }

            return minCycles;
        }

        public void CalculateMinCyclesHelper(Node node, int cycles)
        {
            
            if (node.Children == null || node.Children.Count == 0)
            {
                if (hmap.ContainsKey(node))
                {
                    hmap[node] = Math.Min(hmap[node], cycles);
                }
                else
                {
                    hmap.Add(node, cycles);
                }
            }

            //recursion
            if (node.Children != null)
            {
                for (int i = 0; i < node.Children.Count; i++)
                {
                    //adjust the list to bring the ith child first
                    
                    Node temp = node.Children[i];
                    List<Node> childList = node.Children;
                    childList.RemoveAt(i);
                    List<Node> updatedList = new List<Node>();
                    updatedList.Add(temp);
                    updatedList.Concat(childList);

                    for (int childCounter = 1; childCounter <= childList.Count; childCounter++)
                    {
                        CalculateMinCyclesHelper(updatedList[childCounter], cycles + childCounter);
                    }
                }
            }

        }
    }
}
