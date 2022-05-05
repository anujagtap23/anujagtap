using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleProject.ArrProb
{
    public class LogRecordComparer : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            string first = x as string;
            string second = y as string;

            string[] firstArr = first.Split(' ', 2);
            string[] secondArr = second.Split(' ', 2);

            bool isDigit1 = char.IsDigit(firstArr[1][0]);
            bool isDigit2 = char.IsDigit(secondArr[1][0]);

            if (!isDigit1 && !isDigit2)//both are string records sort
            {
                int cmp = firstArr[1].CompareTo(secondArr[1]);
                if (cmp == 0) //sort by is at 0th
                {
                    return firstArr[0].CompareTo(secondArr[0]);
                }
                else return cmp;
            }
            else if (!isDigit1 && isDigit2) //// the letter-log 1 comes before digit-logs
                return -1;
            else if (isDigit1 && !isDigit2) //// the letter-log 2 comes before digit-logs
                return 1;
            else
                // case 3). both logs are digit-log maintain them as is
                return 0;
        }
    }
    public static class ArrayProblems
    {
        //https://leetcode.com/problems/reorder-data-in-log-files/solution/
        public static string[] ReorderLogFiles(string[] logs)
        {
            List<int> children = new int[26].ToList();
            Array.Sort(logs, new LogRecordComparer());
            return logs;
        }

        //O(log (m+n))
        public static double MedianOf2SortedArrays(int[] arr1, int[] arr2)
        {
            double median = 0;
            int total = arr1.Length + arr2.Length;
            int half = total / 2;

            if(arr1.Length > arr2 .Length)//choose small one to be arr1
            {
                int[] temp = arr2;
                arr2 = arr1;
                arr1 = temp;
            }

            int left = 0, right = arr1.Length - 1;

            //everytime we create L/R partition we need to make sure that
            //that the left values are less than the right parition values across 2 arrays
            //hence check aleft <= bright && bleft<=aright  which tells us we got correct partition
            int i = 0, j = 0;
            while (true)
            {
                if (left >= 0 && right >= 0)
                {
                    i = (left + right) / 2;
                    j = half - i - 2; //acount for 0 based index
                }
                else
                {
                    i = -1;
                    j++;
                }
                int aLeft = (i >= 0 ? arr1[i] : int.MinValue);
                int aRight = (i + 1) < arr1.Length ? arr1[i + 1] : int.MaxValue;
                int bLeft = j >= 0 ? arr2[j] : int.MinValue;
                int bRight = (j + 1) < arr2.Length ? arr2[j + 1] : int.MaxValue;

                if (aLeft <= bRight && bLeft <= aRight)
                {//we found right partition
                    //if total is odd
                    if (total % 2 > 0)
                        median = Math.Min(aRight, bRight);
                    else //even
                        median = (Math.Max(aLeft, bLeft) + Math.Min(aRight, bRight)) / 2;
                    break;
                }
                else if (aLeft > bRight)//gone too much ahead need to reduce right
                {
                    right = i - 1;
                }
                else //bleft > aright  //too short need to advance left
                     left = i + 1;
            }

            return median;

        }
        //https://leetcode.com/problems/maximum-length-of-repeated-subarray/
        public static int FindLength(int[] nums1, int[] nums2)
        {
            int[,] result = new int[nums1.Length + 1, nums2.Length + 1];
            int ans = 0;
            for (int i = nums1.Length - 1; i >= 0; i--)
            {
                for (int j = nums2.Length - 1; j >= 0; j--)
                {
                    if (nums1[i] == nums2[j])
                    {
                        result[i, j] = result[i + 1, j + 1] + 1;
                        ans = Math.Max(ans, result[i, j]);
                    }
                }
            }

            return ans;
        }

        //FB practise
        public static int numberOfWays(int[] arr, int k)
        {
            // Write your code here
            Dictionary<int, int> hmap = new Dictionary<int, int>();
            int result = 0;
            foreach (int num in arr)
            {
                if (hmap.ContainsKey(k - num))
                    result += hmap[k - num];

                if (hmap.ContainsKey(num)) hmap[num] += 1;
                else hmap.Add(num, 1);
            }

            return result;
        }
        public static int[] CountSubarraysWithMaxStartingEndingAtIBrute(int[] arr)
        {//O(n^2)  https://leetcode.com/discuss/interview-question/579606/count-contiguous-subarrays
            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = 1;
                int left = i - 1;
                int right = i + 1;

                while (left >= 0)
                    if (arr[left--] < arr[i]) result[i]++;
                    else break;

                while (right < arr.Length)
                    if (arr[right++] < arr[i]) result[i]++;
                    else break;
            }
            // Write your code here
            return result;
        }

        static Stack<int> stack = new Stack<int>();
        public static int[] CountSubarraysWithMaxStartingEndingAtIoOfn(int[] arr)
        {
            //T: O(n)  S : O(n)
            int[] left = BuildLeft(arr);
            stack.Clear();
            int[] right = BuildRight(arr);
            int[] result = new int[arr.Length];

            for (int i = 0; i < arr.Length; ++i)
            {
                result[i] = left[i] + right[i] + 1; //max left + max right + current element
            }

            return result;
        }

        public static int[] BuildLeft(int[] arr)
        {
            int[] left = new int[arr.Length];
            for (int i = 0; i < arr.Length; ++i)
            {
                while (stack.Count > 0 && arr[stack.Peek()] < arr[i])
                {
                    //Size of largest subarray to the left of popped element + the popped element itself
                    left[i] += left[stack.Pop()] + 1;
                }
                stack.Push(i);
            }
            return left;
        }

        public static int[] BuildRight(int[] arr)
        {
            int[] right = new int[arr.Length];
            for (int i = arr.Length - 1; i >= 0; --i)
            {
                while (stack.Count > 0 && arr[stack.Peek()] < arr[i])
                {
                    //Size of largest subarray to the right of popped element + the popped element itself
                    right[i] += right[stack.Pop()] + 1;
                }
                stack.Push(i);
            }
            return right;
        }
        //similar to LC 718 max repeated sub arr or longest common subarray
        static List<string> FindContiguousHistory(string[] arr1, string[] arr2)
        {

            Dictionary<string, int> hmap = new Dictionary<string, int>();

            for (int i = 0; i < arr2.Length; i++)
            {
                hmap.Add(arr2[i], i);
            }

            int arr1Index = 0;
            int globalStartMax = -1;
            int globalEndMax = -1;
            int globalMax = 0;

            for (int ptr = 0; ptr < arr1.Length; ptr++)
            {
                arr1Index = ptr;

                if (hmap.ContainsKey(arr1[arr1Index]))
                {
                    int start = arr1Index;
                    int currAns = 0;
                    int arr2Index = hmap[arr1[arr1Index]];
                    while (arr1Index < arr1.Length && arr2Index < arr2.Length && arr1[arr1Index].Equals(arr2[arr2Index]))
                    {
                        arr1Index++; arr2Index++;
                    }

                    currAns = arr1Index - start; /*  1 2  3 4*/

                    if (currAns > globalMax)
                    {
                        globalMax = currAns;
                        globalStartMax = start;
                        globalEndMax = arr1Index - 1;
                    }
                }
            }

            List<string> result = new List<string>();

            if (globalStartMax > -1 && globalEndMax > -1)
            {
                for (int i = globalStartMax; i <= globalEndMax; i++)
                {
                    result.Add(arr1[i]);
                }
            }
            return result;
        }
        public static void MoveZeroes(int[] nums)
        {
            int zero = 0, nonZero = 0;
            if (nums.Length > 1)
            {
                while (zero < nums.Length && nums[zero] != 0)
                {
                    zero++; nonZero++;
                }


                while (nonZero < nums.Length)
                {
                    if (nums[nonZero] != 0)
                    {
                        Swap(nums, zero++, nonZero++);
                    }
                    else
                    {
                        nonZero++;
                    }

                }
            }
        }

        //418. Sentence Screen Fitting
        public static int ScreenSentenceTyping(string[] sentence, int rows, int cols)
        {
            int count = 0, currRow = 0, currCol = -1;
            bool isWordAdded = false;

            if (sentence.Any(s => s.Length > cols)) return 0;

            while (currRow < rows)
            {
                for (int i = 0; i < sentence.Length; i++)
                {
                    isWordAdded = false;

                    if (currCol >= cols - 1)
                    {
                        currCol = -1; currRow++;
                    }

                    if (currRow < rows)
                    {
                        int newWordLength = sentence[i].Length;

                        currCol += newWordLength; //curr col should be at the last char

                        if (currCol == cols - 1) //word added just update cols/row
                        {
                            currCol = -1;//for next turn
                            currRow++;
                            isWordAdded = true;
                        }
                        else if (currCol >= cols)//word falling outside of boundary update col/row and again add the word
                        {
                            currCol = -1; currRow++;
                            if (currRow < rows)
                            {
                                currCol += newWordLength;

                                if (currCol < cols)
                                {
                                    currCol++; //add space                            
                                    isWordAdded = true;
                                }
                                else break;
                            }
                            else
                                break;
                        }
                        else//word added and within col boundary
                        {
                            currCol++;
                            isWordAdded = true;
                        }
                    }
                    else
                    {
                        break;
                    }

                    if (i == sentence.Length - 1 && isWordAdded)
                        count++;
                }

            }

            return count;
        }

        public static void Swap(int[] nums, int zero, int nonZero)
        {
            int temp = nums[zero];
            nums[zero] = nums[nonZero];
            nums[nonZero] = temp;
        }

        /*
-- Rocks in 5 colors (Red, Blue, Black, While and Green) and 2 sizes (S and L) arriving in batches
-- Batches arriving at fixed intervals 
-- Batch size is fixed
-- Each rock to be put into named bucket based in its size. so 10 buckets total mounted on a turntable style machinery
-- Switching between buckets is an time-expensive operation.

// Goal:
For each batch, sort the rocks into their corresponding buckets with the lowest number of turns to change buckets.
Determine the order in which the buckets on the turntable are to be arranged to minimize the costs.
        */
        static int CalculateMinNumOfTunrs(int[] stoneBatch) // numbers 0-9 for 5color and 2 sizes
        {
            if (stoneBatch != null && stoneBatch.Length > 0)
            {
                Console.WriteLine("Calling sort");
                int numOfUnique = SortBatch(stoneBatch);
                return (numOfUnique - 1);
            }

            return 0;
        }

        static int SortBatch(int[] stoneBatch)
        {
            int[] bucket = new int[10];
            int numOfUnique = 0;
            for (int i = 0; i < stoneBatch.Length; i++)
            {
                Console.WriteLine("Iteration:" + i);
                if (bucket[stoneBatch[i]] == 0)
                {
                    numOfUnique++;
                }

                bucket[stoneBatch[i]] += 1;
            }

            return numOfUnique;

        }
    }
}
