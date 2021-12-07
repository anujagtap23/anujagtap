using System;
using System.Collections.Generic;
using System.Text;
using ExampleProject.Utils;

namespace ExampleProject.Recursion
{
    public class GeneratePermutation
    {
        public static List<string> GeneratePermutationWithDuplicateElements(int[] arr)
        {
            List<string> result = new List<string>();
            GeneratePermutationWithDuplicateElementsHelper(arr, 0, new StringBuilder(), result);
            return result;
        }

        public static void GeneratePermutationWithDuplicateElementsHelper(int[] arr, int index, StringBuilder soFar, List<string> result)
        {
            if (index == arr.Length)
                result.Add(soFar.ToString());
            else
            {
                HashSet<int> cache = new HashSet<int>();
                for (int i = index; i < arr.Length; i++)
                {
                    if (cache.Contains(arr[i])) continue;

                    cache.Add(arr[i]);//add to cache

                    if (i != index)
                        CommonUtility.SwapTwoIntArrayElements(arr, index, i); //swap elements
                    soFar.Append(arr[index]); // make a choice
                    GeneratePermutationForGivenArrHelper(arr, index + 1, soFar, result);//recurse
                    soFar.Remove(soFar.Length - 1, 1);//remove a choice

                    if (i != index)
                        CommonUtility.SwapTwoIntArrayElements(arr, index, i); //undo swap elements
                }

            }

        }
        public static List<string> GeneratePermutationForGivenArr(int[] arr)
        {
            List<string> result = new List<string>();
            GeneratePermutationForGivenArrHelper(arr, 0, new StringBuilder(), result);
            return result;
        }

        public static void GeneratePermutationForGivenArrHelper(int[] arr, int index, StringBuilder soFar, List<string> result)
        {
            if (index == arr.Length)
                result.Add(soFar.ToString());
            else
            {
                for(int i = index; i < arr.Length; i++)
                {
                    if (i != index)
                        CommonUtility.SwapTwoIntArrayElements(arr, index, i); //swap elements
                    soFar.Append(arr[index]); // make a choice
                    GeneratePermutationForGivenArrHelper(arr, index + 1, soFar, result);//recurse
                    soFar.Remove(soFar.Length - 1, 1);//remove a choice

                    if (i != index)
                        CommonUtility.SwapTwoIntArrayElements(arr, index, i); //undo swap elements
                }

            }

        }
    }
}
