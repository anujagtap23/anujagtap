using System;

namespace ExampleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Section Sort Iterative: NOT Stable, in place, best/avg/worst case O (n^2)");
            PrintArray(SelectionSort.SelectionSortAscendingIterative(arr));

            int[] arr1 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Bubble Sort Iterative: Stable if implemented properly, in place, best/avg/worst case O (n^2)");
            PrintArray(BubbleSort.BubbleSortAscendingIterative(arr1));

            int[] arr2 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Insertion Sort Iterative: Stable if implemented properly, in place, avg/worst case O (n^2), Best Case O(n)");
            PrintArray(InsertionSort.InsertionSortAscendingIterative(arr2));

            int[] arr3 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Insertion Sort Recursive: Stable if implemented properly, in place, avg/worst case O (n^2), Best Case O(n)");
            PrintArray(InsertionSort.InsertionSortAscendingRecursive(arr3));

            int[] arr4 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Merge Sort Recursive: Stable if implemented properly, in place, best/avg/worst case O (n Log n)\n" +
                "For merge sort doesn't matter if the individuaa sub problems are sorted or not, we still go through the (hieght h of the tree)\n" +
                "Merge sort need auxillary space.\n" +
                "Java uses TimSort for Objects.\n" +
                "Python uses Timsort since 2.3\n" +
                "c++ uses Merge sort for stable_Sort()");
            PrintArray(MergeSort.MergeSortAscendingRecursive(arr4));

            int[] arr5 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Quick Sort (Lumoto's partitioning): NOT Stable, in place, best/avg case O(n log n) worst case O (n^2)\n" +
                "Java uses QuickSort for premitives.\n" +
                "c++ uses quicksort for sort()\n" +
                "Quick sort is better for empirical analysis (larger arrays)");
            PrintArray(QuickSort.QuickSortAscendingRecursive(arr5));

            int[] arr6 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Max Heap Sort: NOT Stable, in place, best/avg/worst case O(n log n)\n" +
                "Insert/delete element : O(log n)\n" +
                "Increase/decrease Priority: O(log n)\n" +
                "Build heap(in place with array):  O(n)");
            PrintArray(HeapSort.MaxHeapSortUsingArrayDescending(arr6));

            int[] arr7 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Min Heap Sort: NOT Stable, in place, best/avg/worst case O(n log n)\n" +
                "Insert/delete element : O(log n)\n" +
                "Increase/decrease Priority: O(log n)\n" +
                "Build heap(in place with array):  O(n)");
            PrintArray(HeapSort.MinHeapSortUsingArrayDescending(arr7));

            int[] arr8 = { 3, 7, 4, 5, 2, 0, 3, 0, 9 };
            Console.WriteLine("Counting Sort: Stable is implemented correctly, in place, best/avg/worst case O(n)\n");
            PrintArray(CountingSort.CountingSortUsingList(arr8));

            Console.WriteLine("Radix sort: fastest wayto sort million numbers then radix sort would be good
")
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
    }
}
