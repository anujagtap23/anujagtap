using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class QuickSort
    {
        public static int[] QuickSortAscendingRecursive(int[] arr)
        {
            QuickSortAscendingRecursiveHelper(arr, 0, arr.Length - 1);
            return arr;
        }

        public static void QuickSortAscendingRecursiveHelper(int[] arr, int start, int end)
        {
            if (start >= end) return;
            int pivotIndex = RandomPivotIndex(start, end + 1);
            int pivotValue = arr[pivotIndex];
            SwapTwoArrayElements(arr, start, pivotIndex);
            int smaller = start;
            int bigger = start + 1;

            while(bigger <= end)
            {
                if(arr[bigger] < pivotValue)
                {
                    smaller++;
                    SwapTwoArrayElements(arr, smaller, bigger);
                }
                bigger++;
            }

            SwapTwoArrayElements(arr, smaller, start);
            QuickSortAscendingRecursiveHelper(arr, start, smaller - 1);
            QuickSortAscendingRecursiveHelper(arr, smaller + 1, bigger -1);
        }

        static void SwapTwoArrayElements(int[]arr, int start, int pivot)
        {
            int value = arr[start];
            arr[start] = arr[pivot];
            arr[pivot] = value;
        }
        static int RandomPivotIndex(int min, int max)
        {
            Random random = new Random(); 
            return random.Next(min, max);//does not include max
        }
    }
}
