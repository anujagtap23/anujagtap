using ExampleProject.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    public class CycleSort
    {
        //used for consecutive distinct elements..assuming that elements are in the range 0...n
        //each sorting algo can be made stable by using a pair of element, index (using aux space) and sort using that, first sort using number and thne index if number is same
        //The whole idea of cycle sort is to use when numbers are distinct and consecutive..so stable discussion is for academic purpose
        // (remmeber any comparison sort cannot be better than nLog n…) but because we use Rank based approach the comparison is no longer there in cycle sort
        //        So linear time complexity - O(n)
        //Where is it used : The goal was to reduce num of writes are minimized.so there will be at the minimum num of writes = num of elements in the cycle (cycle size)... in cycle sort cycle of size n would need n-1 swap operation to be fully deflated..
        //compare it with bubble sort where num of write a lot more..

        //duplicates problem or missing element that can be solved by cycle sort
        //LC - 287
        //LC - 645
        //LC - 442
        //LC - 41
        //LC - 765  Cou0ple holding hands

        public static int CoupleSwapsRequired(int[] arr)
        {
            int numOfSwaps = 0;

            Dictionary<int, int> hMap = new Dictionary<int, int>();

            for(int i =0; i<arr.Length; i++)
            {          //person, seat 
                hMap.Add(arr[i], i);
            }

            //consider a sofa is made of 2 indexes
            for(int sofa = 0; sofa < arr.Length/2; sofa++)
            {
                int pLcouple = arr[2 * sofa];
                int pRcouple = arr[2 * sofa + 1];
                int pLIndx = 2 * sofa;
                int pRIndx = 2 * sofa + 1;

                int pRexpected;

                if (pLcouple % 2 == 0) pRexpected = pLcouple + 1;
                else pRexpected = pLcouple - 1;

                if(pRcouple != pRexpected)
                {
                    int pRexpectedIndx = hMap.GetValueOrDefault(pRexpected);
                    CommonUtility.SwapTwoIntArrayElements(arr, pRIndx, pRexpectedIndx);
                    numOfSwaps++;
                    hMap[arr[pRIndx]] = pRIndx;
                    hMap[arr[pRexpectedIndx]] = pRexpectedIndx;
                }
            }

            return numOfSwaps;
        }
        public static int[] CycleSortAscending(int[] arr)
        {
            
            Console.WriteLine("Cycle Sort: Stable is implemented correctly, in place, best/avg/worst case O(n)\n");
            if (arr == null || arr.Length <= 1) return arr;

            for (int i = 0; i < arr.Length; i++)
            {
                while (arr[i] != i)//rank == (i) doesn't match
                {
                    CommonUtility.SwapTwoIntArrayElements(arr, i, arr[i]);
                }
            }
            return arr;
        }

        //nums are in range 0...n
        public static int FindMissingNumberFromDistinctConsecutiveNums0Ton(int[] arr, int lastNum)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                while(arr[i] != i && arr[i] < arr.Length)
                {
                    CommonUtility.SwapTwoIntArrayElements(arr, arr[i], i);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != i)
                    return i;
            }

            return lastNum; //all elemenets were present except last one
        }

        //N is size of arr and 1 <= arr[i] <= N
        public static List<int> FindAllNumsDisappearedInAnArray(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                while(arr[i] != i+1)
                {
                    int dest = arr[i] - 1;

                    if (arr[dest] != arr[i])
                        CommonUtility.SwapTwoIntArrayElements(arr, dest, i);
                    else break;
                }
            }

            List<int> result = new List<int>();
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != i + 1)
                    result.Add(i + 1);
            }

            return result;
        }
    }
}
