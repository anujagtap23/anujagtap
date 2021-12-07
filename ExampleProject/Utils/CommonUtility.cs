using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Utils
{
    public class CommonUtility
    {
        public static void SwapTwoIntArrayElements(int[] arr, int start, int pivot)
        {
            int value = arr[start];
            arr[start] = arr[pivot];
            arr[pivot] = value;
        }
    }
}
