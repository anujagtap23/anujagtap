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


        public static int[] QuickSortAscendingRecursiveLumotosPractise1(int[] arr)
        {
            QuickSortAscendingRecursiveLumotosPractise1Helper(arr, 0, arr.Length - 1);
            return arr;
        }

        public static void QuickSortAscendingRecursiveLumotosPractise1Helper(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = RandomPivotIndexPractise1(start, end + 1);
            SwapTwoArrayElements(arr, start, pivot);
            int smaller = start, bigger = start + 1;

            while(bigger <= end)
            {
                if(arr[bigger] < arr[start])
                {
                    smaller++;
                    SwapTwoArrayElements(arr, smaller, bigger);
                }
                bigger++;
            }

            SwapTwoArrayElements(arr, start, smaller);
            QuickSortAscendingRecursiveLumotosPractise1Helper(arr, start, smaller - 1);
            QuickSortAscendingRecursiveLumotosPractise1Helper(arr, smaller + 1, end);
        }

        public static int[] QuickSortAscendingRecursiveHaoresPractise1(int[] arr)
        {
            QuickSortAscendingRecursiveHaoresPractise1Helper(arr, 0, arr.Length - 1);
            return arr;
        }

        public static void QuickSortAscendingRecursiveHaoresPractise1Helper(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = RandomPivotIndexPractise1(start, end + 1);
            SwapTwoArrayElements(arr, start, pivot);
            int smaller = start+1, bigger = end;

            while (smaller <= bigger)
            {
                if (arr[bigger] >= arr[start])
                    bigger--;
                else if (arr[smaller] < arr[start])
                    smaller++;
                else
                {
                    SwapTwoArrayElements(arr, smaller, bigger);
                    bigger--;
                    smaller++;
                }
            }

            SwapTwoArrayElements(arr, start, bigger);
            QuickSortAscendingRecursiveHaoresPractise1Helper(arr, start, bigger - 1);
            QuickSortAscendingRecursiveHaoresPractise1Helper(arr, bigger + 1, end);
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

        static int RandomPivotIndexPractise1(int min, int max)
        {
            Random generator = new Random();
            return generator.Next(min, max);
        }
        static int RandomPivotIndex(int min, int max)
        {
            Random random = new Random(); 
            return random.Next(min, max);//does not include max
        }
    }
}
