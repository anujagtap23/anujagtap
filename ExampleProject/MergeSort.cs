﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class MergeSort
    {
        public static int[] MergeSortAscendingRecursive(int[] arr)
        {
            MergeSortAscendingRecursiveHelper(arr, 0, arr.Length - 1);
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

            while (i <= mid && j <= end)
            {
                if (arr[i] <= arr[j])
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
            for (int i = start; i <= end; i++)
            {
                arr[i] = aux[j];
                j++;
            }
        }

        public static int[] MergeSortAscendingRecursivePractise1(int[] arr)
        {
            MergeSortAscendingRecursiveHelperPractise1(arr, 0, arr.Length - 1);
            return arr;
        }

        public static void MergeSortAscendingRecursiveHelperPractise1(int[] arr, int start, int end)
        {
            if (start == end)
                return; //single element
            int mid = (start + end) / 2;
            MergeSortAscendingRecursiveHelperPractise1(arr, start, mid);
            MergeSortAscendingRecursiveHelperPractise1(arr, mid + 1, end);

            int j = start, k = mid + 1;
            List<int> aux = new List<int>();

            while (j <= mid && k <= end)
            {
                if (arr[j] <= arr[k])
                {
                    aux.Add(arr[j]);
                    j++;
                }
                else
                {
                    aux.Add(arr[k]);
                    k++;
                }
            }

            while (j <= mid)
            {
                aux.Add(arr[j]);
                j++;
            }

            while (k <= end)
            {
                aux.Add(arr[k]);
                k++;
            }

            CopyAuxToArr(arr, aux, start, end);
        }


        public static List<int> merge_sort(List<int> arr)
        {
            Merge_Sort_Helper(arr, 0, arr.Count - 1);
            return arr;
        }

        public static void Merge_Sort_Helper(List<int> arr, int start, int end)
        {
            if (start >= end) return;

            int mid = (start + end) / 2;
            Merge_Sort_Helper(arr, start, mid);
            Merge_Sort_Helper(arr, mid + 1, end);

            int left = start, right = mid + 1;
            List<int> aux = new List<int>();

            while (left <= mid && right <= end)
            {
                if (arr[left] <= arr[right])
            {
                    aux.Add(arr[left++]);
                }
            else
                {
                    aux.Add(arr[right++]);
                }
            }
            while (left <= mid)
            {
                aux.Add(arr[left++]);
            }

            while (right <= end)
            {
                aux.Add(arr[right++]);
            }

            for (int i = start; i <= end; i++)
            {
                arr[i] = aux[i - start];
            }
        }

    }
}
