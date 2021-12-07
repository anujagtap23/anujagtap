using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    //Section Sort Iterative: NOT Stable, in place, best/avg/worst case O (n^2);
    public class SelectionSort
    {
        public static int[] SelectionSortAscendingIterative(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                int minIndex = i;
                for ( int j = i+1; j < arr.Length; j++)
                {
                    if(arr[j]  < min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }
                arr[minIndex] = arr[i];
                arr[i] = min;
            }
            return arr;
        }

        public static int[] SelectionSortAscendingIterativePractise1(int[] arr)
        {
            for (int i =0; i < arr.Length; i++)
            {
                int minVal = arr[i];
                int minIndex = i;
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j] < minVal)
                    {
                        minIndex = j;
                        minVal = arr[j];
                    }
                }
                arr[minIndex] = arr[i];
                arr[i] = minVal;
            }
            return arr;
        }
    }
}
