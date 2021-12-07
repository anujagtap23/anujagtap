using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Recursion
{
    public class Powerset_AllSubSets
    {
        public static List<string> GeneratePowerSet(int[] arr)
        {
            List<string> result = new List<string>();
            GeneratePowerSetHelper(arr, 0, new StringBuilder(), result);
            return result;
        }

        public static void GeneratePowerSetHelper(int[] arr, int index, StringBuilder soFar, List<string> result)
        {
            if (index == arr.Length)
                result.Add(soFar.ToString());
            else //exclude / inlude
            {
                GeneratePowerSetHelper(arr, index + 1, soFar, result); //exclude curr element

                soFar.Append(arr[index]);//include curr element
                GeneratePowerSetHelper(arr, index + 1, soFar, result); 
                soFar.Remove(soFar.Length - 1, 1);
            }
        }
    }
}
