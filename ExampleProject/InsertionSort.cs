using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class InsertionSort
    {
        public static int[] InsertionSortAscendingIterative(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int currValue = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > currValue)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = currValue;
            }
            return arr;
        }

        public static int[] InsertionSortAscendingIterativePractise1(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                int valToInstert = arr[i];
                while (j >= 0 && arr[j] > valToInstert)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = valToInstert;
            }
            return arr;
        }
        public static int[] InsertionSortAscendingRecursive(int[] arr)
        {
            InsertionSortAscendingRecursiveHelper(arr, arr.Length - 1);
            return arr;
        }

        public static int[] InsertionSortAscendingRecursivePractise1(int[] arr)
        {
            InsertionSortAscendingRecursiveHelperPractise1(arr, arr.Length - 1);
            return arr;
        }

        public static void InsertionSortAscendingRecursiveHelperPractise1(int[] arr, int nth)
        {
            if (nth <= 0)
                return;
            InsertionSortAscendingRecursiveHelperPractise1(arr, nth - 1);
            int j = nth - 1;
            int valToInsert = arr[nth];
            while(j >= 0 && arr[j] > valToInsert)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = valToInsert;
        } 

            public static void InsertionSortAscendingRecursiveHelper(int[] arr, int nth)
        {
            if (nth <= 0)
                return;
            InsertionSortAscendingRecursiveHelper(arr, nth - 1);
            int value = arr[nth];
            int j = nth - 1;
            while(j >= 0 && arr[j] > value)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = value;
            return;
        }
    }
}
