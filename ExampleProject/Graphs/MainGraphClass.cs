using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Graphs
{
    public static class MainGraphClass
    {
        public static void RunGraphProblems()
        {
            //Graph graph = Graph.BuildGraph();
            int[][] edges = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 3, 4 } };
            Graph graph = new Graph(5);

            for (int i = 0; i < edges.Length; i++)
            {
                graph.AddEdge(edges[i][0], edges[i][1], true);
            }

            int result = graph.GetNumOfComponentsDFS();
            Console.WriteLine(result);

            int num = Islands.NumIslands(new char[][] { new char[] { '1', '1', '1' }, new char[] { '0', '1', '0' }, new char[] { '1', '1', '1' } });
            Console.WriteLine(num);

            //int resultRolls = SnakeAndLadder.SnakesAndLadders(new int[][] { new int[] { -1, -1, -1, -1, -1, -1}, new int[] {-1, -1, -1, -1, -1, -1}, new int[] {-1, -1, -1, -1, -1, -1}, new int[] {-1, 35, -1, -1, 13, -1}, new int[] {-1, -1, -1, -1, -1, -1}, new int[] {-1, 15, -1, -1, -1, -1} });
            //Console.WriteLine(resultRolls);

            int resultRolls1 = BoardProblems.SnakesAndLadders(new int[][] { new int[] { -1, -1}, new int[] { -1, 1} });
            Console.WriteLine(resultRolls1);

            bool canfinish = CourseSchedule.CanFinishCourses(2, new int[][] { new int[] { 1, 0 } });

            int knightMoves = BoardProblems.MinKnightMoves(5, 5);
        }
    }
}
