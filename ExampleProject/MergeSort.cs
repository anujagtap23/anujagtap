using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class MergeSort
    {
        public static int[] MergeSortAscendingRecursive(int[] arr)
        {
            MergeSortAscendingRecursiveHelper(arr, 0, arr.Length -1);
            return arr;
        }

        public static void MergeSortAscendingRecursiveHelper(int[] arr, int start, int end)
        {
            if (start >= end) return;
            int mid = (start + end) / 2;
            MergeSortAscendingRecursiveHelper(arr, start, mid);
            MergeSortAscendingRecursiveHelper(arr, mid + 1, end);
            int i = start;
            int j = mid + 1;
            List<int> aux = new List<int>();

            while(i <= mid && j <= end)
            {
                if(arr[i] <= arr[j])
                {
                    aux.Add(arr[i]);
                    i++;
                }
                else
                {
                    aux.Add(arr[j]);
                    j++;
                }
            }

            while (i <= mid)
            {
                aux.Add(arr[i]);
                i++;
            }

            while (j <= end)
            {
                aux.Add(arr[j]);
                j++;
            }

            CopyAuxToArr(arr, aux, start, end);
        }

        private static void CopyAuxToArr(int[] arr, List<int> aux, int start, int end)
        {
            int j = 0;
            for(int i = start; i <= end; i++)
            {
                arr[i] = aux[j];
                j++;
            }
        }
    }
}
