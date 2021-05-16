using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class KwayMerge
    {
        MinHeap<ListNode> Heap { get; set; }

        public KwayMerge()
        {
            Heap = new MinHeap<ListNode>();
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode resultStart = null;
            ListNode prevNode = null;

            for (int i = 0; i < lists.Length; i++)
            {
                if(lists[i] != null)
                    Heap.Add(lists[i]);
            }

            if (Heap.GetSize() > 0)
            {
                ListNode currNode = Heap.GetMin();

                while (currNode != null)
                {
                    ListNode minNode = Heap.PopMin();
                    if (resultStart == null)
                    {
                        resultStart = minNode;
                        prevNode = minNode;
                    }
                    else
                    {
                        prevNode.Next = minNode;
                        prevNode = minNode;
                    }

                    if (minNode.Next != null)
                        Heap.Add(minNode.Next);

                    currNode = Heap.GetMin();
                }
            }

            return resultStart;

        }

    }

    public class ListNode : IComparable
    {
        public int Value { get; set; }

        public ListNode Next { get; set; }

        public ListNode(int val, ListNode next = null)
        {
            this.Value = val;
            this.Next = next;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            ListNode other = obj as ListNode;
            return this.Value.CompareTo(other.Value);
        }
    }
}
