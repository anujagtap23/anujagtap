using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public static class RecursionProblems
    {

        public static int FactorialRecursive(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            return n * FactorialRecursive(n - 1);
        }

        public static int FactorialIterative(int n)
        {
            if(n == 0) return 1;

            int result = 1;
            for (int i = n; i <= 1; i--)
            {
                result *= i;
            }

            return result;
        }

        public static int RaiseNToPowerKRecursive(int n , int k)
        {
            return RaiseNToPowerKRecursiveHelper(n, k);

        }

        //O(k)
        public static int RaiseNToPowerKRecursiveHelper(int n, int k)
        {
            if (k == 0)
                return 1;

            return n * (RaiseNToPowerKRecursiveHelper(n, k - 1));
        }

        public static int RaiseNToPowerKIterative(int n, int k)
        {
            if (k == 0)
                return 1;

            int result = 1;
            for (int i = 1; i <= k; i++)
            {
                result *= n;
            }

            return result;
        }

    

        //O(log K)
        public static int RaiseNToPowerKRecursiveEfficient(int n, int k)
        {
            if (k == 0)
                return 1;

            if (k % 2 == 1)
            {
                int result = RaiseNToPowerKRecursiveEfficient(n, (k - 1) / 2);
                return n * result * result;
            }
            else 
            {
                int result = RaiseNToPowerKRecursiveEfficient(n, k / 2);
                return result * result;
            }
        }

        public static int FibRecursiveInEfficient(int n)
        {
            if (n == 0 || n == 1)
                return n;

            return FibRecursiveInEfficient(n - 1) + FibRecursiveInEfficient(n - 2);
        }

        public static int FibIterativeEfficient(int n)
        {
            return 0;
        }
        public static void TowerOfHanoiRecursive(int n, int[] src, int[] dst, int[] aux)
        {
            if (n == 1)
            {
                dst[n] = src[n];
                src[n] = 0;
                return;
            }

            TowerOfHanoiRecursive(n - 1, src, aux, dst);
            dst[n] = src[n]; src[n] = 0;
            TowerOfHanoiRecursive(n - 1, aux, dst, src);
        }

        public static List<string> GenerateBinaryStringsOfLengthNRecursive(int n)
        {
            if(n == 1)
            {
                List<string> basecase = new List<string>();
                basecase.Add("0");
                basecase.Add("1");
                return basecase;
            }

            List<string> prev = GenerateBinaryStringsOfLengthNRecursive(n - 1);
            List<string> result = new List<string>();

            foreach (string s in prev)
            {
                result.Add(s + "1");
                result.Add(s + "0");
            }

            return result;

        }

        //DFS recursive, space and time O(n)
        public static void GenerateBinaryStringsOfLengthNRecursiveEfficient(int n)
        {
            GenerateBinaryStringsOfLengthNRecursiveEfficientHelper(n, "");
        }

        public static void GenerateBinaryStringsOfLengthNRecursiveEfficientHelper(int n, string prefix)
        {
            if (n == 0)
            {
                Console.WriteLine(prefix);
            }

            GenerateBinaryStringsOfLengthNRecursiveEfficientHelper(n - 1, prefix + "0");
            GenerateBinaryStringsOfLengthNRecursiveEfficientHelper(n - 1, prefix + "1");
        }

        public static List<string> GenerateBinaryStringsOfLengthNIterative(int n)
        {
            List<string> prev = new List<string>();
            prev.Add("0"); prev.Add("1");

            for(int i =2; i<= n; i++)
            {
                List<string> result = new List<string>();
                foreach(string s in prev)
                {
                    result.Add("0" + s);
                    result.Add("1" + s);
                }

                prev = result;
            }

            return prev;
        }

        public static void GenerateDecimalStringsOfLengthNRecursiveEfficient(int n)
        {
            GenerateDecimalStringsOfLengthNRecursiveEfficientHelper(n, "");
        }

        public static void GenerateDecimalStringsOfLengthNRecursiveEfficientHelper(int n, string prefix)
        {
            if (n == 0)
            {
                Console.WriteLine(prefix);
            }

            for (int i = 0; i <= 9; i++)
            {
                GenerateDecimalStringsOfLengthNRecursiveEfficientHelper(n - 1, prefix + i);
            }
        }

        public static void PermutationWithoutRepititionHelper(char[] arr, int index, string prefix)
        {
            if (index == 0)
            {
                //print
                return;
            }

            for(int i = index; i <= arr.Length - 1; i++)
            {
                //PermutationWithoutRepititionHelper(arr, arr without including i, prefix + arr[i]);
            }


        }

        //no mulitplacation, no loops, no factorial, only recursive calls
        public static int NchooseKCalculation(int n, int k)
        {
            if (n <= 1 || k == 0 || k == n)
                return 1;
            else
            {
                return NchooseKCalculation(n - 1, k - 1) + NchooseKCalculation(n - 1, k);//include k + exclude k
            }
        }

        public static int GetAdditiveSequence(int n)
        {
            return AdditiveSequence(n, 0, 1);
        }
        public static int AdditiveSequence(int n, int b1 = 0, int b2 = 1)
        {
            if (n == 0) return b1;
            else return AdditiveSequence(n - 1, b2, b1 + b2);
        }

        //permutation with repitition
        public static List<string> BinaryStringRecursiveNotEfficient(int n)
        {
            if(n == 1)
            {
                return new List<string>() { "0", "1" };
            }
            List<string> prevResult = BinaryStringRecursiveNotEfficient(n - 1);//high space complexity
            List<string> result = new List<string>();
            foreach (string s in prevResult)
            {
                result.Add(s + "0");
                result.Add(s + "1");
            }
            return result;
        }

        //permutation with repitition
        public static List<string> BinaryStringIterative(int n)
        {
            List<string> result = new List<string>() { "0", "1" };
            for (int i = 2; i <= n; i++)
            {
                List<string> temp = new List<string>();
                foreach(string s in result)
                {
                    temp.Add(s + "0");
                    temp.Add(s + "1");
                }
                result = temp;
            }
            return result;
        }

        public static void PrintArray(char[] arr)
        {
            foreach(char c in arr)
                Console.WriteLine(c);
        }

        public static void PrintArray(int[] arr)
        {
            foreach (int c in arr)
                Console.WriteLine(c);
        }

        //permutation with repitition
        public static void BinaryStringRecursiveSpaceEfficient(int n)//mutable string
        {
            BinaryStringRecursiveSpaceEfficientHelper(n, new StringBuilder());
        }
        public static void BinaryStringRecursiveSpaceEfficientHelper(int n, StringBuilder arr)//mutable string
        {
            if (n == 0)
            {
                Console.WriteLine(arr.ToString());
                return;
            }
            else
            {
                arr.Append("0");
                BinaryStringRecursiveSpaceEfficientHelper(n - 1, arr);
                arr.Remove(arr.Length - 1, 1);
                arr.Append("1");
                BinaryStringRecursiveSpaceEfficientHelper(n - 1, arr);
                arr.Remove(arr.Length - 1, 1);
            }
            return;
        }

        //permutation with repitition.. use 0-9 nums and create numbers of length n
        public static void DecimalStringRecursiveSpaceEfficient(int n)//mutable string
        {
            DecimalStringRecursiveSpaceEfficientHelper(n, new StringBuilder());
        }
        public static void DecimalStringRecursiveSpaceEfficientHelper(int n, StringBuilder arr)//mutable string
        {
            if (n == 0)
            {
                Console.WriteLine(arr.ToString());
                return;
            }
            else
            {
                for (int i = 0; i <= 9; i++)
                {
                    arr.Append(i);
                    DecimalStringRecursiveSpaceEfficientHelper(n - 1, arr);
                    arr.Remove(arr.Length - 1, 1);
                }
            }
            return;
        }

        public static IList<string> LetterCasePermutation(string s)
        {
            List<string> result = new List<string>();
            StringBuilder soFar = new StringBuilder();
            LetterCasePermutationHelper(s.ToCharArray(), 0, soFar, result);
            return result;

        }

        public static void LetterCasePermutationHelper(char[] s, int ind, StringBuilder soFar, List<string> result)
        {
            if (ind == s.Length)
            {
                result.Add(soFar.ToString());
            }
            else
            {
                if (char.IsDigit(s[ind]))
                {
                    soFar.Append(s[ind]);
                    LetterCasePermutationHelper(s, ind + 1, soFar, result);
                    soFar.Remove(soFar.Length - 1, 1);
                }
                else
                {
                    soFar.Append(char.ToUpper(s[ind]));
                    LetterCasePermutationHelper(s, ind + 1, soFar, result);
                    soFar.Remove(soFar.Length - 1, 1);

                    soFar.Append(char.ToLower(s[ind]));
                    LetterCasePermutationHelper(s, ind + 1, soFar, result);
                    soFar.Remove(soFar.Length - 1, 1);

                }
            }
        }

        public static IList<IList<int>> Subsets(int[] nums)
        {

            IList<IList<int>> result = new List<IList<int>>();
            SubsetsHelper(nums, 0, new List<int>(), result);
            return result;

        }

        public static void SubsetsHelper(int[] nums, int i, List<int> soFar, IList<IList<int>> result)
        {
            //basecase 
            if (i == nums.Length)
            {
                result.Add(new List<int>(soFar));
            }
            else
            {
                //include
                soFar.Add(nums[i]);
                SubsetsHelper(nums, i + 1, soFar, result);
                soFar.RemoveAt(soFar.Count - 1);
                //exclude
                SubsetsHelper(nums, i + 1, soFar, result);

            }
        }

        public static IList<IList<int>> Permute(int[] nums)
        {

            IList<IList<int>> result = new List<IList<int>>();
            PermuteHelper(nums, 0, new List<int>(), result);
            return result;

        }

        public static void PermuteHelper(int[] nums, int ind, List<int> soFar, IList<IList<int>> result)
        {
            //basecase
            if (ind == nums.Length)
            {
                result.Add(new List<int>(soFar));
            }
            else
            {

                for (int c = ind; c < nums.Length; c++)
                {
                    if (c != ind)
                    {
                        Swap(nums, c, ind);
                        soFar.Add(nums[ind]);
                        PermuteHelper(nums, ind + 1, soFar, result);
                        soFar.RemoveAt(soFar.Count - 1);
                        Swap(nums, c, ind);
                    }
                    else
                    {
                        soFar.Add(nums[ind]);
                        PermuteHelper(nums, ind + 1, soFar, result);
                        soFar.RemoveAt(soFar.Count - 1);

                    }
                }
            }
        }

        public static IList<IList<int>> PermuteUnique(int[] nums)
        {

            IList<IList<int>> result = new List<IList<int>>();
            PermuteUniqueHelper(nums, 0, new List<int>(), result);
            return result;

        }

        public static void PermuteUniqueHelper(int[] nums, int index, List<int> soFar, IList<IList<int>> result)
        {
            //basecase
            if (index == nums.Length)
            {
                result.Add(new List<int>(soFar));
            }
            else
            {
                HashSet<int> hash = new HashSet<int>();

                for (int i = index; i < nums.Length; i++)
                {
                    if (hash.Contains(nums[i]))
                    {
                        continue;

                    }
                    else
                    {
                        hash.Add(nums[i]);
                        if (i != index)
                        {
                            Swap(nums, i, index);
                        }

                        soFar.Add(nums[index]);
                        PermuteUniqueHelper(nums, index + 1, soFar, result);
                        soFar.RemoveAt(soFar.Count - 1);

                        if (i != index)
                        {
                            Swap(nums, i, index);
                        }
                    }

                }

            }
        }

        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {

            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            SubsetsWithDupHelper(nums, 0, new List<int>(), result);
            return result;

        }

        public static void SubsetsWithDupHelper(int[] nums, int index, List<int> soFar, IList<IList<int>> result)
        {
            //basecase
            if (index == nums.Length)
            {
                result.Add(new List<int>(soFar)); //cloned
            }
            //Internal node workers
            else
            {
                //check if dups
                int j = index;
                int count = 0;
                while (nums[j] == nums[index])
                    count++; //count dups of a number

                //include
                for (int i = 0; i < count; i++)
                {
                    soFar.Add(nums[index + i]);
                    SubsetsWithDupHelper(nums, index + count, soFar, result);
                }

                for (int i = 0; i < count; i++)
                    soFar.RemoveAt(soFar.Count - 1); //remove all dups

                //exclude
                SubsetsWithDupHelper(nums, index + count, soFar, result);
            }


        }
        public static void Swap(int[] arr, int i, int x)
        {
            int temp = arr[i];
            arr[i] = arr[x];
            arr[x] = temp;
        }
    }
}
