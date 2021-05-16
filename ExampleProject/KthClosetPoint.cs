using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{

    public class XYPLanePoint : IComparable //IComparer<XYPLanePoint>
    {
        public int x_axis;
        public int y_axis;
        public XYPLanePoint(int x , int y)
        {
            this.x_axis = x;
            this.y_axis = y;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            XYPLanePoint other = obj as XYPLanePoint;
            if (other != null)
            {
                double thisDistanceFromOrigin = Math.Sqrt(Math.Pow(this.x_axis, 2) + Math.Pow(this.y_axis, 2));
                double otherDistanceFromOrigin = Math.Sqrt(Math.Pow(other.x_axis, 2) + Math.Pow(other.y_axis, 2));
                return thisDistanceFromOrigin.CompareTo(otherDistanceFromOrigin);
            }
            else
                throw new ArgumentException("Object is not a XYPLanePoint");
        }

        /*        public int Compare(XYPLanePoint x, XYPLanePoint y)
                {
                    Comparer<double> comparer = Comparer<double>.Default;
                    return comparer.Compare(xDistanceFromOrigin, yDistanceFromOrigin);
                }
        */
        //distance = sqrt of [ (x1-x2) ^2 +  (y1 - y2) ^ 2]

        public static int[][] KClosestPointsUsingQuickSort(int[][] arr, int kthIndex)
        {
            XYPLanePoint[] xyPoints = new XYPLanePoint[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                xyPoints[i] = new XYPLanePoint(arr[i][0], arr[i][1]);

            }
            QuickSortRecursiveHelper(xyPoints, 0, arr.Length - 1, kthIndex -1);

            int[][] results = new int[kthIndex][];

            for (int i = 0; i < kthIndex; i++)
            {
                results[i] = new int[2];
                results[i][0] = xyPoints[i].x_axis;
                results[i][1] = xyPoints[i].y_axis;

                Console.WriteLine($"{results[i][0]}, {results[i][1]}\n");
            }

            return results;

        }
        public static void QuickSortRecursiveHelper(XYPLanePoint[] arr, int start, int end, int kthArrayIndex)
        {
            if (start >= end) return;
            int pivotIndex = RandomPivotIndex(start, end + 1);
            XYPLanePoint pivotValue = arr[pivotIndex];
            SwapTwoArrayElements(arr, start, pivotIndex);
            int smaller = start;
            int bigger = start + 1;

            while (bigger <= end)
            {
                if (arr[bigger].CompareTo(pivotValue) < 0)
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
                QuickSortRecursiveHelper(arr, start, smaller - 1, kthArrayIndex);
            else
                QuickSortRecursiveHelper(arr, smaller + 1, bigger - 1, kthArrayIndex);
        }

        static int RandomPivotIndex(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);//does not include max
        }
        public static XYPLanePoint[] KClosestPointsUsingMaxHeapOfLowestKelemnts(int[][] arr, int k)
        {
            XYPLanePoint[] maxHeapOfLowestKelemnts = new XYPLanePoint[k + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < k)
                {
                    maxHeapOfLowestKelemnts[i + 1] = new XYPLanePoint(arr[i][0], arr[i][1]);
                }
                else
                {
                    if(i == k)
                        MaxHeapify(maxHeapOfLowestKelemnts, 1, maxHeapOfLowestKelemnts.Length - 1);

                    XYPLanePoint xyPoint = new XYPLanePoint(arr[i][0], arr[i][1]);
                    if (maxHeapOfLowestKelemnts[1].CompareTo(xyPoint) > 0)
                    {
                        maxHeapOfLowestKelemnts[1] = xyPoint;
                        MaxHeapify(maxHeapOfLowestKelemnts, 1, maxHeapOfLowestKelemnts.Length - 1);
                    }
                }
            }
            return maxHeapOfLowestKelemnts;
        }


        public static void MaxHeapify(XYPLanePoint[] arr, int nodeIndex, int arrLastIndex)
        {
            int leftChild = nodeIndex * 2;
            int rightChild = nodeIndex * 2 + 1;

            if (leftChild > arrLastIndex && rightChild > arrLastIndex) return;//leaf nodes

            MaxHeapify(arr, leftChild, arrLastIndex);
            MaxHeapify(arr, rightChild, arrLastIndex);

            if (leftChild <= arrLastIndex && rightChild <= arrLastIndex &&
                arr[nodeIndex].CompareTo(arr[leftChild]) < 0 && arr[nodeIndex].CompareTo(arr[rightChild]) < 0)
            {
                XYPLanePoint max = arr[leftChild];
                int maxIndex = leftChild;

                if (arr[rightChild].CompareTo(max) > 0)
                {
                    maxIndex = rightChild;
                }

                SwapTwoArrayElements(arr, nodeIndex, maxIndex);
            }
            else if (leftChild <= arrLastIndex && arr[nodeIndex].CompareTo(arr[leftChild]) < 0)
            {
                SwapTwoArrayElements(arr, nodeIndex, leftChild);
            }
            else if (rightChild <= arrLastIndex && arr[nodeIndex].CompareTo(arr[rightChild]) < 0)
            {
                SwapTwoArrayElements(arr, nodeIndex, rightChild);
            }

            return;
        }
        static void SwapTwoArrayElements(XYPLanePoint[] arr, int start, int pivot)
        {
            XYPLanePoint value = arr[start];
            arr[start] = arr[pivot];
            arr[pivot] = value;
        }

        

      
    }
}

