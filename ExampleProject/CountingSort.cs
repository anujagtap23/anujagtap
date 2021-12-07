using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    class CountingSort
    {
        //Counting Sort: Stable is implemented correctly, in place, best/avg/worst case O(n)\n");


        public static int[] CountingSortPractise1(int[] arr)
        {
            if (arr == null || arr.Length <= 1) return arr;

            int min = arr[0];
            int max = arr[1];

            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }

            int[] result = new int[max + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                result[arr[i]] += 1;
            }

            int j = 0;
            for (int i = 0; i < result.Length; i++)
            {
                while(result[i] > 0)
                {
                    arr[j++] = i;
                    result[i] -= 1;
                }
            }

            return arr;
        }
        public static int[] CountingSortUsingList(int[] arr)
        {
            int min = arr[0];
            int max = arr[1];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                else if (arr[i] > max)
                    max = arr[i];
            }

            int[] result = new int[max + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                result[arr[i]] += 1;
            }

            int j = 0;

            for (int i = 0; i < result.Length; i++)
            {
                while(result[i] > 0)
                {
                    arr[j] = i;
                    j++;
                    result[i] -= 1;
                }
            }

                return arr;
        }
    }
}
