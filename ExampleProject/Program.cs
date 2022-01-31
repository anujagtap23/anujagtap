using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExampleProject.Recursion;
using ExampleProject.Trees;
using ExampleProject.Graphs;
using ExampleProject.SlidingWindow;
using ExampleProject.ArrProb;
using ExampleProject.StringProblems;
using ExampleProject.Intervals;

namespace ExampleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IntervalProblems.CanTaskBeScheduled(new Interval[]
            {new Interval(5,10), new Interval(20,30), new Interval(12,16)}, new Interval(8, 12));
            //FB start
            ArrayProblems.numberOfWays(new int[] { 1, 2, 3, 4, 3}, 6);
            ArrayProblems.numberOfWays(new int[] { 1, 5, 3, 3, 3 }, 6);
            ArrayProblems.CountSubarraysWithMaxStartingEndingAtIBrute(new int[] { 3, 4, 1, 6, 2 });
            Console.WriteLine(RotationalCipher.RotationalCipherFunc("Zebra-493", 3));
            
            
            //FB end
            ArrayProblems.ReorderLogFiles(new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" });

            //crosses right boundary
            Console.WriteLine(ArrayProblems.MedianOf2SortedArrays(new int[] { 0, 1 }, new int[] { 2, 3, 4, 5, 6, 7, 8, 9 }));
            //crosses left boundary
            Console.WriteLine(ArrayProblems.MedianOf2SortedArrays(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 7, 8, 9, 10 }));
            Console.WriteLine(ArrayProblems.MedianOf2SortedArrays(new int[] { 1,2,3,4,5,7,8,8}, new int[] { 3, 10, 12, 12}));

            StringBuilder sb = new StringBuilder();
            new string(sb.ToString().Reverse().ToArray());

            char[] charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine(new string(charArray));

            Intervals.IntervalProblems interval = new Intervals.IntervalProblems();
            interval.EmployeeFreeTime();
            interval.SortIntervalArray();
            Dictionary<int, int> d = new Dictionary<int, int>();
            d[1] = 1;
            int[,] resultz = new int[1,1];
            int iz = 0, jz = 0;
            resultz[iz, jz] = 8;

            iz = resultz.Length; //jz = resultz.
            var ans = new List<int>(new int[10]);
        
            StrProblems.FullJustify(new string[] { "a" }, 2);
            StrProblems.FullJustify(new string[] { "ask","not","what","your","country","can","do","for","you","ask","what","you","can","do","for","your","country"}, 16);
            StrProblems.FullJustify(new string[] { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" }, 20);
            StrProblems.FullJustify(new string[] { "This", "is", "an", "example", "of", "text", "justification." }, 16);

            BitWise.BitwiseProblems.BitwiseMain(null);
            //strstr
            StrProblems.StrStr("mississippi","pi");
            //ReverseString
            StrProblems.Reverse(123);
            //LC 418. Sentence Screen Fitting
            ArrayProblems.ScreenSentenceTyping(new string[] { "f", "p", "a" }, 8,7);

            //https://leetcode.com/problems/move-zeroes/solution/            
            ArrayProblems.MoveZeroes(new int[] { 0, 1, 0, 3, 12 });

            //LC 567. Permutation in String
            SlidingWindow.SlidingWindow.CheckInclusion("adc", "dcda");

            //LC max sliding window
            int[] slidingArr = new int[] {1, 3, -1, -3, 5, 3, 6, 7};
            SlidingWindow.SlidingWindow.MaxSlidingWindow(slidingArr, 3);

            //LCS path src -> dest
            PAthFromSrcToDestLCA obj = new PAthFromSrcToDestLCA();
            obj.GetDir();
            //calculate num of rectangles

            CalculateRectangleArea.NumOfRectanlges();


            //Sorting Algorithms
            int[] arr = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -1, -10, 0 };
            Console.WriteLine("Section Sort Iterative: NOT Stable, in place, best/avg/worst case O (n^2)");
            PrintArray(SelectionSort.SelectionSortAscendingIterative(arr)); //O(n^2)
            int[] arrPRac = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -1, -10, 0 };
            PrintArray(SelectionSort.SelectionSortAscendingIterativePractise1(arrPRac));//O(n^2)

            int[] arr1 = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -1, -10, 0 };
            Console.WriteLine("Bubble Sort Iterative: Stable if implemented properly, in place, best/avg/worst case O (n^2)");
            PrintArray(BubbleSort.BubbleSortAscendingIterative(arr1));//O(n^2)
            int[] arr1P = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -1, -10, 0 };
            PrintArray(BubbleSort.BubbleSortAscendingIterativePractise1(arr1P));//O(n^2)


            int[] arr2 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 , -1, -10, 0 };
            Console.WriteLine("Insertion Sort Iterative: Stable if implemented properly, in place, avg/worst case O (n^2), Best Case O(n)");
            PrintArray(InsertionSort.InsertionSortAscendingIterative(arr2));
            int[] arr2P = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -1, -10, 0 };
            PrintArray(InsertionSort.InsertionSortAscendingIterativePractise1(arr2P));

            int[] arr3 = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -1, -10, 0 };
            Console.WriteLine("Insertion Sort Recursive: Stable if implemented properly, in place, avg/worst case O (n^2), Best Case O(n)");
            PrintArray(InsertionSort.InsertionSortAscendingRecursive(arr3));
            int[] arr3P = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -1, -10, 0 };
            PrintArray(InsertionSort.InsertionSortAscendingRecursivePractise1(arr3P));

            int[] arr4 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 , -10, -1 , 0};
            Console.WriteLine("Merge Sort Recursive: Stable if implemented properly, in place, best/avg/worst case O (n Log n)\n" +
                "For merge sort doesn't matter if the individuaa sub problems are sorted or not, we still go through the (hieght h of the tree)\n" +
                "Merge sort need auxillary space.\n" +
                "Java uses TimSort for Objects.\n" +
                "Python uses Timsort since 2.3\n" +
                "c++ uses Merge sort for stable_Sort()");
            PrintArray(MergeSort.MergeSortAscendingRecursive(arr4));
            int[] arr4P = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -10, -1, 0 };
            PrintArray(MergeSort.MergeSortAscendingRecursivePractise1(arr4P));

            int[] arr5 = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -10, -1, 0 };
            Console.WriteLine("Quick Sort (Lumoto's partitioning): NOT Stable, in place, best/avg case O(n log n) worst case O (n^2)\n" +
                "Java uses QuickSort for premitives.\n" +
                "c++ uses quicksort for sort()\n" +
                "Quick sort is better for empirical analysis (larger arrays)");
            PrintArray(QuickSort.QuickSortAscendingRecursive(arr5));
            int[] arr5P = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -10, -1, 0 };
            PrintArray(QuickSort.QuickSortAscendingRecursiveLumotosPractise1(arr5P));
            int[] arr5P1 = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -10, -1, 0 };
            PrintArray(QuickSort.QuickSortAscendingRecursiveHaoresPractise1(arr5P1));

            int[] arr6 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Max Heap Sort: NOT Stable, in place, best/avg/worst case O(n log n)\n" +
                "Insert/delete element : O(log n)\n" +
                "Increase/decrease Priority: O(log n)\n" +
                "Build heap(in place with array):  O(n)");
            PrintArray(HeapSort.MaxHeapSortUsingArrayDescending(arr6));

            int[] arr66 = { 3, 7, 4, 5, 2, 0, 3, 0, 9, -1, -10};
            PrintArray(HeapSort.MaxHeapSortUsingArrayDescendingPractise1(arr66));

            int[] arr7 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Min Heap Sort: NOT Stable, in place, best/avg/worst case O(n log n)\n" +
                "Insert/delete element : O(log n)\n" +
                "Increase/decrease Priority: O(log n)\n" +
                "Build heap(in place with array):  O(n)");
            PrintArray(HeapSort.MinHeapSortUsingArrayDescending(arr7));

            int[] arr77 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            PrintArray(HeapSort.MinHeapSortUsingArrayAscendingPractise1(arr77));

            int[] arr8 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Counting Sort: Stable is implemented correctly, in place, best/avg/worst case O(n)\n");
            PrintArray(CountingSort.CountingSortUsingList(arr8));

            int[] arr88 = { 4, 3, 2, 1,0,6,7,5 };
            Console.WriteLine("Cycle Sort (non stable)=================="); 
            PrintArray(CycleSort.CycleSortAscending(arr88));
            
            int[] arr888 = { 4, 3, 2, 1, 0, 6, 7, 5 , 9};
            Console.WriteLine("\n Missing number is - " + CycleSort.FindMissingNumberFromDistinctConsecutiveNums0Ton(arr888, 9));

            int[] arr8888 = { 4, 3, 2, 4};
            Console.WriteLine("\n Missing number is - ");
            PrintList(CycleSort.FindAllNumsDisappearedInAnArray(arr8888));

            int[] arrCouples = { 3, 2, 0, 1 };
            Console.WriteLine("\n Couple swap required - " + CycleSort.CoupleSwapsRequired(arrCouples));
            PrintArray(arrCouples);

            int[] arrCouples2 = { 3, 2, 0, 1,5,8,4,7,6,9 };
            Console.WriteLine("\n Couple swap required - " + CycleSort.CoupleSwapsRequired(arrCouples2));
            PrintArray(arrCouples2);

            int[] arr999 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Wiggle Sort ==============");
            PrintArray(WiggleSort.WiggleSortIterative(arr999));

            int[] arr1000 = { 4,3,2,1 };
            Console.WriteLine("Pancake Sort ==============");
            Console.WriteLine("Number of flips required are : " + PancackeSort.PancackeFlip(arr1000));
            PrintArray(arr1000);

            Console.WriteLine("Radix sort: fastest way to sort million numbers then radix sort would be good\n" +
               "sorting digits right to left keeps it stable (sorting from left to right is not stable)  ");

            //Sorting problems

            //You have an array of n numbers and a number target. Find out whether the array contains two elements whose sum is target.
            int[] arr9 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            int target = 6;
            SortingProblems.DoesArrayContainTarget(arr9, target);

            int[] arr10 = { 3, 7, 4, 5, 2, 0, 3, 0, 9, 7 };
            int targetDice = 7;
            SortingProblems.ReturnIndicesOfElementsSumToTargetN2(arr10, targetDice);
            Console.WriteLine("=========================================");
            SortingProblems.ReturnIndicesOfElementsSumToTargetOofN(arr10, targetDice);
            Console.WriteLine("=========================================");
            Console.WriteLine($"Is meeting possible : {SortingProblems.IsAttendingAllMeetingsPossible()}");
            Console.WriteLine("=========================================");

            int[] arr11 = { -1, 0, 1, 2, -1, 0, 1, -4 };
            //int[] arr11 = { -2, 0, 0, 2, 2 };
            List<List<int>> result = SortingProblems.ReturnUniqueTripletsSumToTarget3Sum(arr11, 0);
            Console.WriteLine("=========================================");
            Console.WriteLine($"3 sum :");
            foreach (List<int> triplet in result)
            {
                Console.WriteLine($"{triplet[0]}, {triplet[1]}, {triplet[2]} \n");
            }

            result = SortingProblems.ThreeSumUsingTwoSum(arr11);
            Console.WriteLine("=========================================");
            Console.WriteLine($"3 sum using 2 Sum ");
            foreach (List<int> triplet in result)
            {
                Console.WriteLine($"{triplet[0]}, {triplet[1]}, {triplet[2]} \n");
            }

            List<int> intersection = SortingProblems.InterSectionOf3Arrays3PointerPass(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 5, 7, 8, 9 }, new int[] { 0, 3, 4, 5, 6, 8, 9 });
            Console.WriteLine("=============Intersetion of 3 arrays============================");
            PrintList(intersection);

            intersection = SortingProblems.InterSectionOf3ArraysHashTableCount(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 5, 7, 8, 9 }, new int[] { 0, 3, 4, 5, 6, 8, 9 });
            Console.WriteLine("=============Intersetion of 3 arrays============================");
            PrintList(intersection);


            int[] mergedArr = SortingProblems.MergeTwoAscendingSortedArrays(new int[] { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0 }, 5, new int[] { 3, 5, 7, 8, 9 }, 5);
            Console.WriteLine("=============Merge 2 sorted arrays============================");
            PrintArray(mergedArr);


            int KthLargest = SortingProblems.KthLArgestUsingQuickSortRecursive(new int[] { 1, 2, 13, 4, 5, 11, 0, 12, 14, 80, 9, 10, 100 }, 5);
            Console.WriteLine($"=============Kth Largest element : ============================");
            Console.WriteLine(KthLargest);

            int closestK = 3;
            int[][] results = new int[closestK][];
            Console.WriteLine($"=============Kth Closest points using max heap: ============================");
            int[][] arrKthcloset = new int[][] { new int[] { 3, 3 }, new int[] { -2, 4 }, new int[] { 5, -1 }, new int[] { 6, -4 }, new int[] { 1, -1 }, new int[] { 4, -5 } };
            XYPLanePoint[] resultArrKthcloset = XYPLanePoint.KClosestPointsUsingMaxHeapOfLowestKelemnts(arrKthcloset, closestK);

            for (int i = 1; i < resultArrKthcloset.Length; i++)
            {
                results[i - 1] = new int[2];
                results[i - 1][0] = resultArrKthcloset[i].x_axis;
                results[i - 1][1] = resultArrKthcloset[i].y_axis;

                Console.WriteLine($"{results[i - 1][0]}, {results[i - 1][1]}\n");
            }

            Console.WriteLine($"=============Kth Closest points using quicksort: ============================");
            XYPLanePoint.KClosestPointsUsingQuickSort(arrKthcloset, closestK);

            Console.WriteLine($"=============top K most frequent using quicksort: ============================");
            int[] topkFrequent = new int[] { 1, 1, 1, 2, 2, 3 };
            SortingProblems.TopKFrequentElementsUsingQuickSortRecursive(topkFrequent, 2);


            Console.WriteLine($"=============Find median using heap: ============================");
            int[] median = new int[] { 1, 2 };
            MedianFinder finder = new MedianFinder();
            for (int i = 0; i < median.Length; i++)
            {
                finder.AddNum(median[i]);
            }
            Console.WriteLine($"Median of 1,2 : {finder.FindMedian()}");
            finder.AddNum(3);
            Console.WriteLine($"Median of 1,2,3 : {finder.FindMedian()}");

            Console.WriteLine($"=============Kth Largest integers from the stream==================");
            int[] stream = new int[] { 4, 5, 8, 2 };
            KthLargest<int> kthLargest = new KthLargest<int>(3, stream);
            int[] stream2 = new int[] { 3, 5, 10, 9, 4 };
            for (int i = 0; i < stream2.Length; i++)
            {
                Console.WriteLine($"{kthLargest.Add(stream2[i])},");
            }

            Console.WriteLine($"=============Kth Largest strings from the stream==================");
            StringLength[] stringStream = new StringLength[] { new StringLength("abcfdre"),
                new StringLength("ab"), new StringLength("abc"), new StringLength("abcd"),
                new StringLength("abcdef"), new StringLength("a") };
            KthLargest<StringLength> kthLargestStrings = new KthLargest<StringLength>(3, stringStream);
            StringLength[] kthLargestStringsStream2 = new StringLength[] { new StringLength("asdfghjkl"),
                new StringLength("sdf"), new StringLength("asdfghjklasdfghjkl")};
            for (int i = 0; i < kthLargestStringsStream2.Length; i++)
            {
                Console.WriteLine($"{kthLargestStrings.Add(kthLargestStringsStream2[i]).Value},");
            }

            Console.WriteLine($"============= Reaarange left = even, right = odd");
            int[] evenOdd = new int[] { 3, 5, 10, 9, 4 };
            SortingProblems.LeftEvenRightOddArrangement(evenOdd);
            for (int i = 0; i < evenOdd.Length; i++)
            {
                Console.WriteLine($"{evenOdd[i]},");
            }
            int[] evenOdd1 = new int[] { 3, 5, 10, 9, 4 };
            PrintArray(SortingProblems.LeftEvenRightOddArrangementPractise1(evenOdd1));
            

            Console.WriteLine($"============= DutchNationalFlag arrange R0 - G1- B2");
            int[] dutchNationalFlag = new int[] { 0,2,1,1,1,2,0,0,2,1,2 };
            SortingProblems.DuthNationalFlagR0G1B2Arrangement(dutchNationalFlag);
            for (int i = 0; i < dutchNationalFlag.Length; i++)
            {
                Console.WriteLine($"{dutchNationalFlag[i]},");
            }

            Console.WriteLine("============KwayMerge=============");
            ListNode[] lists = new ListNode[3];
            lists[0] = new ListNode(1, new ListNode(4, new ListNode(5, null)));
            lists[1] = new ListNode(1, new ListNode(3, new ListNode(4, null)));
            lists[2] = new ListNode(2, new ListNode(3, null));
            KwayMerge kway = new KwayMerge();
            ListNode resultKway = kway.MergeKLists(lists);
            ListNode currNode = resultKway;
            while(currNode != null)
            {
                Console.WriteLine($"{currNode.Value},");
                currNode = currNode.Next;
            }

            Console.WriteLine("============KwayMerge===2 nulls==========");
            ListNode[] listsNull = new ListNode[3];
            lists[0] = null;
            lists[1] = null;
            KwayMerge kwayNull = new KwayMerge();
            ListNode resultKwayNull = kway.MergeKLists(listsNull);

            MainRecursionClass.ExecuteRecursionProblems();

            //Graphs
            MainGraphClass.RunGraphProblems();
            //trees
            MainTreesClass.RunTreeProblems();
        }

        private static void PrintArray(int[] arr)
        {
            string arrElements = String.Empty;
            foreach(int i in arr)
            {
                arrElements += i + " ,";
            }
            Console.WriteLine($"\n  {arrElements}");
            Console.WriteLine("--------------------------------");
        }

        private static void PrintList(List<int> arr)
        {
            string arrElements = String.Empty;
            foreach (int i in arr)
            {
                arrElements += i + " ,";
            }
            Console.WriteLine($"\n  {arrElements}");
            Console.WriteLine("--------------------------------");
        }
    }
}
