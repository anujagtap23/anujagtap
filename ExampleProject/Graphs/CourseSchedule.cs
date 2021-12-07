using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Graphs
{
    public static class CourseSchedule
    {
        public static int[] visited;//these can be defined as BitArray visited for compact storage
        public static int[] arrival;
        public static int[] departure;
        public static List<int> toplogicalSortArr = new List<int>();
        public static int TimeStamp = 0;
        public static List<int>[] AdjacencyListUsingArray;
        public static int[] indegree;
        public static void AddEdges(int numCourses, int[][] prerequisites, bool biDir = true)
        {
            AdjacencyListUsingArray = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                AdjacencyListUsingArray[i] = new List<int>();
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                AdjacencyListUsingArray[prerequisites[i][0]].Add(prerequisites[i][1]);
                indegree[prerequisites[i][0]]++;
                if (biDir)
                {
                    AdjacencyListUsingArray[prerequisites[i][1]].Add(prerequisites[i][0]);
                    indegree[prerequisites[i][1]]++;
                }
            }
        }


        public static void AddEdgesReverse(int numCourses, int[][] prerequisites, bool biDir = true)
        {
            AdjacencyListUsingArray = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                AdjacencyListUsingArray[i] = new List<int>();
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                AdjacencyListUsingArray[prerequisites[i][1]].Add(prerequisites[i][0]);
                indegree[prerequisites[i][1]]++;
                if (biDir)
                {
                    AdjacencyListUsingArray[prerequisites[i][0]].Add(prerequisites[i][1]);
                    indegree[prerequisites[i][0]]++;
                }
            }
        }
        //LC 207 course schedule graph
        public static bool CanFinishCourses(int numCourses, int[][] prerequisites)
        {

            visited = new int[numCourses];
            arrival = new int[numCourses];
            departure = new int[numCourses];
            indegree = new int[numCourses];
            AddEdges(numCourses, prerequisites, false);

            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == 0)
                {
                    if (DFSDirectedRecursive(i)) return false;
                }
            }
            return true;
        }

        //LC 210 Course schedule 2 : return the ordering of course schedule
        //please note LC gives the relation in reverse order as compared to LC 207
        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            visited = new int[numCourses];
            arrival = new int[numCourses];
            departure = new int[numCourses];
            AddEdgesReverse(numCourses, prerequisites, false);

            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == 0)
                {
                    if (DFSDirectedRecursive(i)) return new int[0];
                }
            }
            toplogicalSortArr.Reverse();
            return toplogicalSortArr.ToArray();
        }

        //LC 210 Course schedule 2 : return the ordering of course schedule
        //please note LC gives the relation in reverse order as compared to LC 207
        public static int[] FindOrderIterative(int numCourses, int[][] prerequisites)
        {
            indegree = new int[numCourses];
            int start;
            Queue<int> q = new Queue<int>();
            //Set in degrees for all courses
            for (int i = 0; i < prerequisites.Length; i++)
            {
                
            }
            AddEdgesReverse(numCourses, prerequisites, false);

            //Find verte with 0 indegree
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    q.Enqueue(i); //Add all indegree = 0 courses in the q
                }
            }

            while(q.Count > 0)
            {
                int i = q.Dequeue();
                toplogicalSortArr.Add(i);

                foreach(int node in AdjacencyListUsingArray[i])
                {
                    indegree[node]--;
                    if (indegree[node] == 0) q.Enqueue(node);
                }
            }

            if (toplogicalSortArr.Count < numCourses)//cycle found
                return new int[0];

            return toplogicalSortArr.ToArray();
        }

        public static bool DFSDirectedRecursive(int node)
        {
            visited[node] = 1;
            arrival[node] = TimeStamp++;
            foreach (int neighbor in AdjacencyListUsingArray[node])
            {
                if (visited[neighbor] == 0)
                {
                    if (DFSDirectedRecursive(neighbor)) return true; // cycle found
                }
                else
                {
                    if (departure[neighbor] == 0)//back edge
                        return true;
                }

            }
            departure[node] = TimeStamp++;
            toplogicalSortArr.Add(node);//for LC 210 only
            return false;
        }
    }
}
