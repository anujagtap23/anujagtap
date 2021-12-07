using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Recursion
{
    public class LetterCasePermutation
    {
        public static List<string> GetUpperLowerCasePermutation(string str)
        {
            List<string> result = new List<string>();
            GetUpperLowerCasePermutationHelper(str.ToCharArray(), 0, string.Empty, result);
            return result;
        }

        //here the stringSofar is a immutable obj resulting in creating new strings everytime, resukting in higher space complexity
        public static void GetUpperLowerCasePermutationHelper(char[] str, int index, string stringSoFar, List<string> result)
        {
            if (index == str.Length)
                result.Add(stringSoFar);
            else
            {
                char currChar = str[index];
                if(char.IsDigit(currChar))
                {
                    GetUpperLowerCasePermutationHelper(str, index + 1, stringSoFar + currChar , result);
                }
                else
                {
                    GetUpperLowerCasePermutationHelper(str, index + 1, stringSoFar + char.ToLower(currChar), result);
                    GetUpperLowerCasePermutationHelper(str, index + 1, stringSoFar + char.ToUpper(currChar), result);
                }
            }
        }


        public static List<string> GetUpperLowerCasePermutationEfficient(string str)
        {
            List<string> result = new List<string>();
            StringBuilder mutableStr = new StringBuilder();
            GetUpperLowerCasePermutationEfficientHelper(str.ToCharArray(), 0, mutableStr, result);
            return result;
        }

        //here the stringSofar is a immutable obj resulting in creating new strings everytime, resukting in higher space complexity
        public static void GetUpperLowerCasePermutationEfficientHelper(char[] str, int index, StringBuilder stringSoFar, List<string> result)
        {
            if (index == str.Length)
                result.Add(stringSoFar.ToString());
            else
            {
                char currChar = str[index];
                if (char.IsDigit(currChar))
                {
                    stringSoFar.Append(currChar); // make a choice 
                    GetUpperLowerCasePermutationEfficientHelper(str, index + 1, stringSoFar, result);//recurse
                    stringSoFar.Remove(stringSoFar.Length - 1, 1);//remove choice
                }
                else
                {
                    stringSoFar.Append(char.ToLower(currChar));// make a choice 
                    GetUpperLowerCasePermutationEfficientHelper(str, index + 1, stringSoFar, result);// recurse
                    stringSoFar.Remove(stringSoFar.Length - 1, 1);//remove choice

                    stringSoFar.Append(char.ToUpper(currChar));// make a choice 
                    GetUpperLowerCasePermutationEfficientHelper(str, index + 1, stringSoFar, result);//recurse
                    stringSoFar.Remove(stringSoFar.Length - 1, 1);//remove choice
                }
            }
        }
    }
}
