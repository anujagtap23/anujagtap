using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
      public class MedianFinder{

        public MinHeap<int> largerElementMinHeap;
        public MaxHeap<int> smallerElemenMaxHeap;

        public MedianFinder()
        {
            largerElementMinHeap = new MinHeap<int>();
            smallerElemenMaxHeap = new MaxHeap<int>();
        }

        public void AddNum(int num)
        {
            smallerElemenMaxHeap.Add(num);
            largerElementMinHeap.Add(smallerElemenMaxHeap.PopMax());

            if (smallerElemenMaxHeap.GetSize() < largerElementMinHeap.GetSize())
            {
                smallerElemenMaxHeap.Add(largerElementMinHeap.PopMin());
            }
        }

        public double FindMedian()
        {
            return smallerElemenMaxHeap.GetSize() > largerElementMinHeap.GetSize() ?  smallerElemenMaxHeap.GetMax() : 
                (double)(smallerElemenMaxHeap.GetMax() + largerElementMinHeap.GetMin()) / 2;
        }
    }
}
