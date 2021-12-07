using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    class PancackeSort
    {
        public static int PancackeFlip(int[] arr)
        {
            int result = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if(arr[i] != i+1)
                {
                    int j = i - 1;
                    while (arr[j] != i + 1)
                        j--;

                    if(j >= 0)//j is a valid index
                    {
                        //Array.Reverse(arr, StartIndex, length)  if element is at top we dont need to do 1st flip
                        if (j != 0)
                        {
                            Array.Reverse(arr, 0, j + 1);
                            result += 1;
                        }
                        Array.Reverse(arr, 0, i + 1);
                        result += 1;
                    }
                }
            }

            return result;
        }
    }
}
