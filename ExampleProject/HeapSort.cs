using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class HeapSort
    {

        //to heapigy start with right most arr position that has children : index is n/2
        // So to solve right most parent first use tail recurssion and go till the right most parent and then solve
        //for given element at index n, parent is at n/2 ,  children are at 2n, 2n+1
        //heap arr starts from index 1
        //Max/Min Heap Sort: NOT Stable, in place, best/avg/worst case O(n log n)\n" +
        //        "Insert/delete element : O(log n)\n" +
        //        "Increase/decrease Priority: O(log n)\n" +
        //        "Build heap(in place with array):  O(n)
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

        public static int[] MaxHeapSortUsingArrayDescendingPractise1(int[] arr)
        {
            List<int> rightArr = RighShiftArrayByOne(arr);
            MaxHeapifyPractise1(rightArr, 1, rightArr.Count - 1);

            List<int> result = new List<int>();

            while(rightArr.Count > 1)
            {
                result.Add(PopMaxFromHeap(rightArr));
            }

            return result.ToArray();
        }

        public static void MaxHeapifyPractise1(List<int> arr, int valIndex, int lastIndex)
        {
            int left = valIndex * 2;
            int right = valIndex * 2 + 1;

            if (left > lastIndex && right > lastIndex) return; // leaf node

            MaxHeapifyPractise1(arr, left, lastIndex);
            MaxHeapifyPractise1(arr, right, lastIndex);

            //both children are present 
            if (left <= lastIndex && right <= lastIndex 
                && arr[valIndex] < arr[left] && arr[valIndex] < arr[right])
            {
                int max = arr[left];
                int maxIndex = left;
                if(arr[right] > max)
                {
                    max = arr[right];
                    maxIndex = right;
                }
                SwapTwoArrayElements(arr, maxIndex, valIndex);
            }//only left is avlbl
            else if (left <= lastIndex && arr[valIndex] < arr[left])
            {
                SwapTwoArrayElements(arr, left, valIndex);
            }//only right is avlbl
            else if (right <= lastIndex && arr[valIndex] < arr[right])
            {
                SwapTwoArrayElements(arr, right, valIndex);
            }
            return;
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

        public static int[] MinHeapSortUsingArrayAscendingPractise1(int[] arr)
        {
            List<int> rightArr = RighShiftArrayByOne(arr);

            MinHeapifyPractise1(rightArr, 1, rightArr.Count - 1);

            List<int> result = new List<int>();
            while(rightArr.Count > 1)
            {
                result.Add(PopMinFromHeap(rightArr));
            }

            return result.ToArray();
        }

        public static void MinHeapifyPractise1(List<int> arr, int valIndx, int lastIndx)
        {
            int left = valIndx * 2;
            int right = valIndx * 2 + 1;

            if (left > lastIndx && right > lastIndx) return;

            MinHeapifyPractise1(arr, left, lastIndx);
            MinHeapifyPractise1(arr, right, lastIndx);

            if (left <= lastIndx && right <= lastIndx 
                && arr[left] < arr[valIndx] && arr[right] < arr[valIndx])
            {
                int min = arr[left];
                int minInd = left;

                if(arr[right] < min)
                {
                    min = arr[right];
                    minInd = right;
                }

                SwapTwoArrayElements(arr, minInd, valIndx);
            }
            else if (left <= lastIndx && arr[left] < arr[valIndx])
            {
                 SwapTwoArrayElements(arr, left, valIndx);
            }
            else if (right <= lastIndx && arr[right] < arr[valIndx])
            {
                SwapTwoArrayElements(arr, right, valIndx);
            }

            return;
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
