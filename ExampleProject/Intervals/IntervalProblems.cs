using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Diagnostics;
namespace ExampleProject.Intervals
{
    public class Interval : IComparable
    {
        public int start; public int end;
        public Interval() { }
        public Interval(int _start, int _end)
        {
            start = _start;
            end = _end;
        }
        //2D arr - Array.Sort(arr, (i, j) => Comparer.Default.Compare(i[0], j[0]));

        //list.Sort(delegate (int x, int y)
        //{
        //    return y.CompareTo(x);
        //});

        //var descendingComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
        //var Dict = new SortedDictionary<int, string>(descendingComparer);    USE as priority Queue  (insertion/remove  logN,  access O(1))
        //int minKey = Dict.Keys.First(); Dict.Remove(minKey);

        //SortedList sortedList = new SortedList(descendingComparer);//only supports key,value pair in sortedlist
        //Array.Sort(currTasks);
        //Array.BinarySearch(currTasks, newTask) == 0 ? false : true;

        //interval if start time is same then order by descending end time else ascending starttime
        //var descendingComparer1 = Comparer<int[]>.Create((x, y) => x[0] == y[0] ? y[1] - x[1] : x[0] - y[0]); 
        //SortedSet<Player> players = players.OrderBy(c => c.PlayerName);
        //Dict.OrderByDescending(w => w.Value);
        public int CompareTo(Object o)
        {
            Interval i = o as Interval;
            if (this.start <= i.start && this.end <= i.start) return -1;
            if (this.start >= i.end && this.end >= i.end) return 1;
            return 0;
        }
    }
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

        public static bool CanTaskBeScheduled(int[][] currTasks, int[] newTask)
        {
            Array.Sort(currTasks, (i,j) => Comparer.Default.Compare(i[0], j[0]));

            var intervalComparer = Comparer<int[]>.Create((x, y) => (  //comparer for task can be scheudled
            y[0] >= x[0] && y[0] <= x[1]) || (y[1] >= x[0] && y[1] <= x[1]) || (y[0] < x[0] && y[1] > x[1]) ? 0 : x[0] - y[0]); // if overlapping found else return based on startTime

            
            bool result = Array.BinarySearch<int[]>(currTasks, newTask, intervalComparer) > 0 ? false : true;  //if overlap found then it would return the index at which the overlap is found else it will return -ve num
            return result;
        }

    }


}
