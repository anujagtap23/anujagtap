using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ExampleProject.Intervals
{
    public class IntervalProblems
    {
        public void SortIntervalArray()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] { 1, 3 };
            arr[1] = new int[] { 4, 6 };
            arr[2] = new int[] { 2, 3 };

            Array.Sort(arr, (i, j) => Comparer.Default.Compare(i[0], j[0]));
            
            //CaseInsensitiveComparer().Compare(i[0], j[0]));

            Console.WriteLine(arr[1][0]);
        }

        public IList<Interval> EmployeeFreeTime()
        {
            IList<IList<Interval>> schedule = new List<IList<Interval>>();

            schedule.Add(new List<Interval>());
            schedule.Add(new List<Interval>());
            schedule.Add(new List<Interval>());
            schedule[0].Add(new Interval(1, 3));
            schedule[1].Add(new Interval(4, 6));
            schedule[2].Add(new Interval(2, 3));

            Array.Sort(schedule.ToArray(), (i, j) => Comparer.Default.Compare(i[0], j[0]));
            //above not working
            return null;
        }

        public static bool CanTaskBeScheduled(Interval[] currTasks, Interval newTask)
        {
            Array.Sort(currTasks);
            bool result = Array.BinarySearch(currTasks, newTask)== 0 ? false : true;
            return result;
        }

    }

    public class Interval : IComparable
    {
        public int start;
        public int end;

        public Interval() { }
        public Interval(int _start, int _end)
        {
            start = _start;
            end = _end;
        }

        public int CompareTo(Object o)
        {
            Interval i = o as Interval;
            if (this.start <= i.start && this.end <= i.start) return -1;
            if (this.start >= i.end && this.end >= i.end) return 1;
            return 0;
        }
    }
}
