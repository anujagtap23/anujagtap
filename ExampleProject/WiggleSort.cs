using ExampleProject.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    class WiggleSort
    {
        public static int[] WiggleSortIterative(int[] arr)
        {
            //If we visualize it ,we can see is < is at odd and > is at even
            //T(n)   S(1)
            if (arr == null || arr.Length <= 1) return arr;

            for(int i = 1; i < arr.Length; i++)
            {
                if (((i % 2) == 1 && arr[i - 1] > arr[i]) || ((i % 2) == 0 && arr[i - 1] < arr[i]))
                    CommonUtility.SwapTwoIntArrayElements(arr, i - 1, i);
            }

            return arr;
        }
    }
}
