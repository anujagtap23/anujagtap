using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class KthLargest<T> where T : IComparable
    {
        public MinHeap<T> Heap { get; set; }

        public int KthIndex { get; set; }

        public T[] ObjArray { get; set; }

        public KthLargest()
        {
            Heap = new MinHeap<T>();
        }

        public KthLargest(int k, T[] arr)
        {
            Heap = new MinHeap<T>();

            for(int i = 0; i < arr.Length; i++)
            {
                Heap.Add(arr[i]);
            }
            KthIndex = k;
            ObjArray = arr;
        }

        public T Add(T val)
        {
            if (Heap.GetSize() < KthIndex)  //add val to the heap
            {
                Heap.Add(val);
            }
            else
            {
                while (Heap.GetSize() > KthIndex)
                {
                    Heap.PopMin();
                }
                
                if (Heap.GetMin().CompareTo(val) < 0) //add val to the heap
                {
                    Heap.PopMin();
                    Heap.Add(val);
                }
            }

            if(Heap.GetSize() == KthIndex)
            {
                return Heap.GetMin();
            }
            else
            {
                throw new Exception("Invalid KthIndex");
            }
        }
    }

    public class StringLength : IComparable
    {
        public string Value { get; set; }

        public StringLength(string val)
        {
            Value = val;
        }

        public int CompareTo(object obj)
        {
            StringLength other = obj as StringLength;

            if (obj == null)
                throw new NullReferenceException();

            return this.Value.Length.CompareTo(other.Value.Length);
        }
    }
}
