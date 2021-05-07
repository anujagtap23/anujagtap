using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class HeapSort
    {

        //to heapigy start with right most arr position that has children : index is n/2
        //for given element at index n, parent is at n/2 ,  children are at 2n, 2n+1

        public static int[] MaxHeapSortUsingArrayDescending(int[] arr)
        {
            List<int> righShiftedArr = RighShiftArrayByOne(arr);
            MaxHeapify(righShiftedArr, 1, righShiftedArr.Count - 1);

            List<int> result = new List<int>();
            
            for(int i = 0; i < arr.Length; i++)
            {
                result.Add(PopMaxFromHeap(righShiftedArr));
            }
            return result.ToArray();
        }

        public static int[] MinHeapSortUsingArrayDescending(int[] arr)
        {
            List<int> righShiftedArr = RighShiftArrayByOne(arr);
            MinHeapify(righShiftedArr, 1, righShiftedArr.Count - 1);

            List<int> result = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                result.Add(PopMinFromHeap(righShiftedArr));
            }
            return result.ToArray();
        }

        public static List<int> RighShiftArrayByOne(int[] arr)
        {
            List<int> righShiftedArr = new List<int>();
            righShiftedArr.Add(int.MinValue);

            for (int i = 0; i < arr.Length; i++)
            {
                righShiftedArr.Add(arr[i]);
            }
            return righShiftedArr;
        }
        public static void MaxHeapify(List<int> arr, int nodeIndex, int arrLastIndex)
        {
            int leftChild = nodeIndex * 2;
            int rightChild = nodeIndex * 2 + 1;
            
            if (leftChild > arrLastIndex && rightChild > arrLastIndex) return;//leaf nodes

            MaxHeapify(arr, leftChild, arrLastIndex);
            MaxHeapify(arr, rightChild, arrLastIndex);

            if (leftChild <= arrLastIndex && rightChild <= arrLastIndex &&
                arr[nodeIndex] < arr[leftChild] && arr[nodeIndex] < arr[rightChild])
            {
                int max = arr[leftChild];
                int maxIndex = leftChild;

                if (arr[rightChild] > max)
                {
                    maxIndex = rightChild;
                }

                SwapTwoArrayElements(arr, nodeIndex, maxIndex);
            }
            else if (leftChild <= arrLastIndex && arr[nodeIndex] < arr[leftChild])
            {
                SwapTwoArrayElements(arr, nodeIndex, leftChild);
            }
            else if (rightChild <= arrLastIndex && arr[nodeIndex] < arr[rightChild])
            {
                SwapTwoArrayElements(arr, nodeIndex, rightChild);
            }

            return;
        }


        public static void MinHeapify(List<int> arr, int nodeIndex, int arrLastIndex)
        {
            int leftChild = nodeIndex * 2;
            int rightChild = nodeIndex * 2 + 1;

            if (leftChild > arrLastIndex && rightChild > arrLastIndex) return;//leaf nodes

            MinHeapify(arr, leftChild, arrLastIndex);
            MinHeapify(arr, rightChild, arrLastIndex);

            if (leftChild <= arrLastIndex && rightChild <= arrLastIndex &&
                arr[nodeIndex] > arr[leftChild] && arr[nodeIndex] > arr[rightChild])
            {
                int min = arr[leftChild];
                int minIndex = leftChild;

                if (arr[rightChild] < min)
                {
                    minIndex = rightChild;
                }

                SwapTwoArrayElements(arr, nodeIndex, minIndex);
            }
            else if (leftChild <= arrLastIndex && arr[nodeIndex] > arr[leftChild])
            {
                SwapTwoArrayElements(arr, nodeIndex, leftChild);
            }
            else if (rightChild <= arrLastIndex && arr[nodeIndex] > arr[rightChild])
            {
                SwapTwoArrayElements(arr, nodeIndex, rightChild);
            }

            return;
        }

        static void SwapTwoArrayElements(List<int> arr, int start, int pivot)
        {
            int value = arr[start];
            arr[start] = arr[pivot];
            arr[pivot] = value;
        }

        public static int PopMaxFromHeap(List<int> arr)
        {
            int value = arr[1]; //max element is always at 1 index
            SwapTwoArrayElements(arr, 1, arr.Count - 1);
            arr.RemoveAt(arr.Count - 1);
            MaxHeapify(arr, 1, arr.Count - 1);
            return value;
        }
        public static int PopMinFromHeap(List<int> arr)
        {
            int value = arr[1]; //min element is always at 1 index
            SwapTwoArrayElements(arr, 1, arr.Count - 1);
            arr.RemoveAt(arr.Count - 1);
            MinHeapify(arr, 1, arr.Count - 1);
            return value;
        }
    }
}
