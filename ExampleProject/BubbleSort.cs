using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class BubbleSort
    {
        public static int[] BubbleSortAscendingIterative(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int value = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = value;
                    }
                }
            }
            return arr;
        }

        public static int[] BubbleSortAscendingIterativePractise1(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
            return arr;
        }
    }
}
