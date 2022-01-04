using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleProject
{
    class SortingProblems
    {
        //You have an array of n numbers and a number target. Find out whether the array contains two elements whose sum is target.
        public static void DoesArrayContainTarget(int[] arr, int target)
        {
            InsertionSort.InsertionSortAscendingIterative(arr);

            int i = 0;
            int j = arr.Length - 1;

            while (i < j)
            {
                if (arr[j] == target - arr[i])
                {
                    Console.WriteLine($"Target = {target} , ArrElements = {arr[i]} + {arr[j]}");
                    i++;
                    j--;
                }
                else if (arr[j] > target - arr[i])
                    j--;
                else if (arr[j] < target - arr[i])
                    i++;
            }
        }

        //O(N2) you have an array of n numbers and a number target. Return indices of two elements whose sum is target.
        public static void ReturnIndicesOfElementsSumToTargetN2(int[] arr, int target)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                int i = index;
                int j = arr.Length - 1;
                while (i < j)
                {
                    if (arr[j] == target - arr[i])
                    {
                        Console.WriteLine($"Target = {target} , ArrElements = {arr[i]} index [{i}] + {arr[j]} index [{j}]");
                        i++;
                        j--;
                    }
                    else if (arr[j] > target - arr[i])
                        j--;
                    else if (arr[j] < target - arr[i])
                        i++;
                }
            }
        }

        //2n = O(n) you have an array of n numbers and a number target. Return indices of two elements whose sum is target.
        public static void ReturnIndicesOfElementsSumToTargetOofN(int[] arr, int target)
        {
            Dictionary<int, List<int>> numberHash = BuildArrayHash(arr);

            foreach (int num1 in numberHash.Keys)
            {
                int num2 = target - num1;
                if (numberHash.ContainsKey(num2))
                {
                    numberHash.TryGetValue(num1, out List<int> num1Indices);
                    numberHash.TryGetValue(num2, out List<int> num2Indices);

                    while (num1Indices.Count > 0 && num2Indices.Count > 0)
                    {
                        Console.WriteLine($"{num1Indices[0]} + {num2Indices[0]}\n");
                        num1Indices.RemoveAt(0);
                        num2Indices.RemoveAt(0);
                    }
                }
            }
        }

        public static List<List<int>> ReturnUniqueTripletsSumToTarget3Sum(int[] arr, int target)
        {
            Dictionary<int, List<int>> numberHash = BuildArrayHash(arr);
            List<List<int>> result = new List<List<int>>();

            foreach (int num1 in numberHash.Keys)
            {
                if (numberHash[num1].Count == 0) continue;

                foreach (int num2 in numberHash.Keys)
                {
                    if (numberHash[num1].Count == 0)
                        break;

                    if ((num2 == num1 && numberHash[num1].Count <= 1) || (numberHash[num2].Count == 0))
                        continue;

                    int num3 = target - num1 - num2;
                    if (numberHash.ContainsKey(num3))
                    {
                        if (numberHash[num3].Count == 0 || (num1 == num2 && num2 == num3 && numberHash[num3].Count < 3) || ((num1 == num3 || num2 == num3) && numberHash[num3].Count < 2))
                            continue;

                        numberHash.TryGetValue(num1, out List<int> num1Indices);
                        numberHash.TryGetValue(num2, out List<int> num2Indices);
                        numberHash.TryGetValue(num3, out List<int> num3Indices);

                        List<int> triplet = new List<int>();
                        triplet.Add(num1);
                        triplet.Add(num2);
                        triplet.Add(num3);
                        triplet.Sort();

                        if (!Contains(result, triplet))
                        {
                            result.Add(triplet);
                        }
                    }
                }
            }

            return result;
        }

        public static List<List<int>> ThreeSumUsingTwoSum(int[] nums)
        {
            Array.Sort(nums);
            List<List<int>> res = new List<List<int>>();
            for (int i = 0; i < nums.Length && nums[i] <= 0; ++i)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    TwoSumII(nums, i, res);
                }
            }
            return res;
        }

        public static void TwoSumII(int[] nums, int i, List<List<int>> res)
        {
            int lo = i + 1, hi = nums.Length - 1;
            while (lo < hi)
            {
                int sum = nums[i] + nums[lo] + nums[hi];
                if (sum < 0)
                {
                    ++lo;
                }
                else if (sum > 0)
                {
                    --hi;
                }
                else
                {
                    res.Add(new List<int>() { nums[i], nums[lo++], nums[hi--] });
                    while (lo < hi && nums[lo] == nums[lo - 1])
                        ++lo;
                }
            }
        }

        public static List<int> InterSectionOf3Arrays3PointerPass(int[] arr1, int[] arr2, int[] arr3)
        {
            int i = 0, j = 0, k = 0;
            List<int> result = new List<int>();

            while (i < arr1.Length && j < arr2.Length && k < arr3.Length)
            {
                if (arr1[i] == arr2[j] && arr2[j] == arr3[k])
                {
                    result.Add(arr1[i]);
                    i++; j++; k++;
                }
                else if (arr1[i] <= arr2[j] && arr1[i] <= arr3[k])
                    i++;
                else if (arr2[j] <= arr3[k] && arr2[j] <= arr1[i])
                    j++;
                else
                    k++;
            }
            return result;
        }

        public static List<int> InterSectionOf3ArraysHashTableCount(int[] arr1, int[] arr2, int[] arr3)
        {
            int i = 0;
            SortedList countHashTable = new SortedList();
            List<int> result = new List<int>();

            while (i < arr1.Length)
            {
                if (countHashTable.ContainsKey(arr1[i]))
                {
                    countHashTable[arr1[i]] = (int)countHashTable[arr1[i]] + 1;
                }
                else
                    countHashTable.Add(arr1[i], 1);

                i++;
            }

            i = 0;

            while (i < arr2.Length)
            {
                if (countHashTable.ContainsKey(arr2[i]))
                {
                    countHashTable[arr2[i]] = (int)countHashTable[arr2[i]] + 1;
                }
                else
                    countHashTable.Add(arr2[i], 1);

                i++;
            }

            i = 0;

            while (i < arr3.Length)
            {
                if (countHashTable.ContainsKey(arr3[i]))
                {
                    countHashTable[arr3[i]] = (int)countHashTable[arr3[i]] + 1;
                }
                else
                    countHashTable.Add(arr3[i], 1);

                i++;
            }

            foreach (DictionaryEntry e in countHashTable)
            {
                if ((int)e.Value == 3)
                    result.Add((int)e.Key);
            }
            return result;
        }
        private static bool Contains(List<List<int>> result, List<int> triplet)
        {
            foreach (List<int> e in result)
            {
                bool contains = true;
                foreach (int trip in triplet)
                {
                    if (!e.Contains(trip))
                        contains = false;
                }

                if (contains)
                    return true;
            }

            return false;
        }

        public static int[] MergeTwoAscendingSortedArrays(int[] arr1, int arr1M, int[] arr2, int arr2N)
        {
            //assume arr1 has enough size to hold all elements
            int i = arr1M - 1, j = arr2N - 1;
            int currIndex = arr1M + arr2N - 1;
            while (i >= 0 && j >= 0)
            {
                if (arr1[i] < arr2[j])
                {
                    arr1[currIndex--] = arr2[j--];
                }
                else
                {
                    arr1[currIndex--] = arr1[i--];
                }
            }

            while (i >= 0)
            {
                arr1[currIndex--] = arr1[i--];
            }

            while (j >= 0)
            {
                arr1[currIndex--] = arr2[j--];
            }

            return arr1;
        }


        /*
         * Complete the merger_first_into_second function below.
         */
        static void Merger_first_into_second(int[] arr1, int[] arr2)
        {

            if (arr1 != null && arr2 != null && arr2.Length == arr1.Length * 2)
            {
                int ind1 = arr1.Length - 1;
                int ind2 = arr1.Length - 1;
                int i = arr2.Length - 1;
                while (i >= 0)
                {
                    if (ind1 >= 0 && ind2 >= 0 && arr1[ind1] > arr2[ind2])
                    {
                        arr2[i--] = arr1[ind1--];
                    }
                    else if (ind1 >= 0 && ind2 >= 0 && arr2[ind2] >= arr1[ind1])
                    {
                        arr2[i--] = arr2[ind2--];
                    }
                    else if (ind1 >= 0 && ind2 < 0)
                    {
                        arr2[i--] = arr1[ind1--];
                    }
                    else if (ind2 >= 0 && ind1 < 0)
                    {
                        arr2[i--] = arr2[ind2--];
                    }
                }

            }

        }

        public static Dictionary<int, List<int>> BuildArrayHash(int[] arr)
        {
            Dictionary<int, List<int>> numberHash = new Dictionary<int, List<int>>();
            for (int index = 0; index < arr.Length; index++)
            {
                if (!numberHash.ContainsKey(arr[index]))
                {
                    List<int> indices = new List<int>();
                    indices.Add(index + 1);
                    numberHash.Add(arr[index], indices);
                }
                else
                {
                    numberHash.TryGetValue(arr[index], out List<int> value);
                    value.Add(index + 1);
                    numberHash[arr[index]] = value;
                }
            }
            return numberHash;
        }

        // considering that every iteration we are reducing problem size by 5% this gives O(n) complexity
        //     S = n + 0.95n + 0.95^2 n + 0.95^3 n + 0.95^4 n + ...
        //0.95 S = 0.95n + 0.95^2 n + 0.95^3 n + 0.95^4 n + ...
        //S - 0.95 S = n
        // S = n/0.05  = 20 n
        public static int KthLArgestUsingQuickSortRecursive(int[] arr, int kthIndex)
        {
            QuickSortRecursiveHelperKthLargest(arr, 0, arr.Length - 1, arr.Length - kthIndex);
            return arr[arr.Length - kthIndex];
        }

        public static int KthLArgestUsingMinHeapOfTopKelemnts(int[] arr, int kthIndex)
        {
            return 0;
        }


        public static int[] TopKFrequentElementsUsingQuickSortRecursive(int[] arr, int kthIndex)
        {
            Dictionary<int, int> frequencyList = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!frequencyList.ContainsKey(arr[i]))
                    frequencyList.Add(arr[i], 1);
                else
                    frequencyList[arr[i]] = (int)frequencyList[arr[i]] + 1;
            }

            List<FrquencyKeyValue> list = ConvertDictToFrquencyKeyValue(frequencyList);
            QuickSortRecursiveHelperTopK(list, 0, list.Count - 1, list.Count - kthIndex);

            List<int> results = new List<int>();
            for (int i = list.Count - 1; i >= list.Count - kthIndex; i--)
            {
                results.Add(list[i].key);
                Console.WriteLine($"{list[i].key}, ");
            }


            return results.ToArray();
        }

        public static List<FrquencyKeyValue> ConvertDictToFrquencyKeyValue(Dictionary<int, int> frequencyList)
        {
            List<FrquencyKeyValue> list = new List<FrquencyKeyValue>();

            foreach (KeyValuePair<int, int> kv in frequencyList)
            {
                list.Add(new FrquencyKeyValue(kv.Key, kv.Value));
            }

            return list;

        }
        public static void QuickSortRecursiveHelperKthLargest(int[] arr, int start, int end, int kthArrayIndex)
        {
            if (start >= end) return;
            int pivotIndex = RandomPivotIndex(start, end + 1);
            int pivotValue = arr[pivotIndex];
            SwapTwoArrayElements(arr, start, pivotIndex);
            int smaller = start;
            int bigger = start + 1;

            while (bigger <= end)
            {
                if (arr[bigger] < pivotValue)
                {
                    smaller++;
                    SwapTwoArrayElements(arr, smaller, bigger);
                }
                bigger++;
            }

            SwapTwoArrayElements(arr, smaller, start);

            if (smaller == kthArrayIndex)
                return;
            if (kthArrayIndex < smaller)
                QuickSortRecursiveHelperKthLargest(arr, start, smaller - 1, kthArrayIndex);
            else
                QuickSortRecursiveHelperKthLargest(arr, smaller + 1, bigger - 1, kthArrayIndex);
        }

        public static void QuickSortRecursiveHelperTopK(List<FrquencyKeyValue> arr, int start, int end, int kthArrayIndex)
        {
            if (start >= end) return;
            int pivotIndex = RandomPivotIndex(start, end + 1);
            FrquencyKeyValue pivotValue = arr[pivotIndex];
            SwapTwoDictElements(arr, start, pivotIndex);
            int smaller = start;
            int bigger = start + 1;

            while (bigger <= end)
            {
                if (arr[bigger].CompareTo(pivotValue) < 0)
                {
                    smaller++;
                    SwapTwoDictElements(arr, smaller, bigger);
                }
                bigger++;
            }

            SwapTwoDictElements(arr, smaller, start);

            if (smaller == kthArrayIndex)
                return;
            if (kthArrayIndex < smaller)
                QuickSortRecursiveHelperTopK(arr, start, smaller - 1, kthArrayIndex);
            else
                QuickSortRecursiveHelperTopK(arr, smaller + 1, bigger - 1, kthArrayIndex);
        }

        public static void LeftEvenRightOddArrangement(int[] arr)
        {
            int evenIndex = 0, currIndex = 0;

            while (currIndex < arr.Length)
            {
                if (arr[currIndex] % 2 == 1)
                    currIndex++;
                else
                {
                    SwapTwoArrayElements(arr, currIndex, evenIndex);
                    currIndex++;
                    evenIndex++;
                }
            }
        }


       public static int[] LeftEvenRightOddArrangementPractise1(int[] arr)
        {

            int i = 0, j = arr.Length - 1;

            while (i < j)
            {
                if (arr[i] % 2 == 1)
                {
                    Swap(arr, i, j);
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return arr;
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }



        public static void DuthNationFlagR0G1B2_3WayPAtitioningClean(int[] arr)
        {
            if (arr != null && arr.Length > 0)
            {
                int red = 0; int blue = arr.Length - 1;
                int i = 0;

                while (i <= blue) //as blue is at a non blue place always we need to consider that as well but beyond blueIndex all are sorted blues
                {
                    if (arr[i] < 1)
                    {
                        SwapTwoArrayElements(arr, i, red);
                        i++;
                        red++;
                    }
                    else if (arr[i] > 1)
                    {
                        SwapTwoArrayElements(arr, i, blue);
                        blue--;
                    }
                    else if (arr[i] == 1)
                    {
                        i++;
                    }
                }
            }
        }

        public static void DuthNationFlagR0G1B2_3WayPAtitioningOptimizedforITerations(int[] arr)
        {
            if (arr != null && arr.Length > 0)
            {
                int red = 0; int blue = arr.Length - 1;
                int i = 0;

                while(arr[blue] == 2)//we need blue to be at non blue place
                {
                    blue--;
                }

                while(i <= blue) //as blue is at a non blue place always we need to consider that as well but beyond blueIndex all are sorted blues
                {
                    if(arr[i] < 1)
                    {
                        SwapTwoArrayElements(arr, i, red);
                        i++;
                        red++;
                    }
                    else if(arr[i] > 1)
                    {
                        SwapTwoArrayElements(arr, i, blue);
                        while (arr[blue] == 2)//we need blue to be at non blue place, this is for optimization but not required
                        {
                            blue--;
                        }
                    }
                    else if(arr[i] == 1)
                    {
                        i++;
                    }
                }
            }
        }
        public static void DuthNationalFlagR0G1B2Arrangement(int[] arr) //robertSedgwick algorithm 3 way partitionning
        {
            int redIndex = 0, blueIndex = arr.Length -1, i =0;

            while(arr[i] == 0)
            {
                i++;
            }
            redIndex = i;

            while (arr[blueIndex] == 2)
            {
                blueIndex--;
            }

            while (i <= blueIndex) //as soon as i crosses blueIndex we know we have sorted the array
            {
                if (arr[i] == 1)//if green go on
                    i++;
                else if(arr[i] == 2) // check if blue
                {
                    if(arr[blueIndex] != 2) SwapTwoArrayElements(arr, i, blueIndex); //swap only if the blueindex is not already on a blue
                    blueIndex--;
                }
                else if (arr[i] == 0) // check if red
                {
                    if (arr[redIndex] != 0)  SwapTwoArrayElements(arr, i, redIndex);
                    redIndex++;
                    i++;
                }
            }
        }


        static void SwapTwoDictElements(List<FrquencyKeyValue> arr, int start, int pivot)
        {
            FrquencyKeyValue value = arr[start];
            arr[start] = arr[pivot];
            arr[pivot] = value;
        }

        static void SwapTwoArrayElements(int[] arr, int start, int pivot)
        {
            int value = arr[start];
            arr[start] = arr[pivot];
            arr[pivot] = value;
        }
        static int RandomPivotIndex(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);//does not include max
        }


        public static bool IsAttendingAllMeetingsPossible()
        {
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/jagged-arrays 
            int[][] data = new int[][] {
                                 new int[] {0,30},
                                 new int[] {40,50},
                                 new int[] {50,55}
                                };
            Sort<int>(data, 0);

            for(int i = 0; i < data.Length - 1; i++)
            {
                if (data[i][1] > data[i + 1][0])
                    return false;
            }

            return true;
        }
        
        private static void Sort<T>(T[][] data, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        }
    }

    public class FrquencyKeyValue : IComparable
    {
        public int key;
        public int value;

        public FrquencyKeyValue(int k, int v)
        {
            this.key = k;
            this.value = v;
        }
        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;
            else
            {
                FrquencyKeyValue other = obj as FrquencyKeyValue;
                return (this.value - other.value); //
            }
        }
    }


}
