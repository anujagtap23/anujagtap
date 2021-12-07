using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Graphs
{
    public static class Islands
    {
        public static char[][] MainGrid;
        public static int[][] MainIntGrid;

        // LC 200
        public static int NumIslands(char[][] grid)
        {

            MainGrid = grid;
            int numOfIslands = 0;
            for (int i = 0; i < MainGrid.Length; i++)
            {
                for (int j = 0; j < MainGrid[i].Length; j++)
                {
                    if (MainGrid[i][j] == 1)
                    {
                        numOfIslands++;
                        BFS(i, j);
                    }
                }
            }
            return numOfIslands;
        }

        public static void BFS(int i, int j)
        {
            Queue<int[][]> q = new Queue<int[][]>();
            q.Enqueue(new int[][] { new int[] { i, j } });
            MainGrid[i][j] = '2'; //visited

            while (q.Count > 0)
            {
                int[][] node = q.Dequeue();

                List<List<int>> neighbours = GetNeighbours(node[0][0], node[0][1]);

                for (int n = 0; n < neighbours.Count; n++)
                {
                    if (MainGrid[neighbours[n][0]][neighbours[n][1]] == '1')
                    {
                        MainGrid[neighbours[n][0]][neighbours[n][1]] = '2';
                        q.Enqueue(new int[][] { new int[] { neighbours[n][0], neighbours[n][1] } });
                    }
                }
            }
        }

        public static List<List<int>> GetNeighbours(int i, int j)
        {
            List<List<int>> neighbours = new List<List<int>>();

            if ((i - 1) >= 0 && MainGrid[i-1][j] == '1') neighbours.Add(new List<int>() { i - 1, j });
            if ((i + 1) < MainGrid.Length && MainGrid[i + 1][j] == '1') neighbours.Add(new List<int>() { i + 1, j });
            if ((j + 1) < MainGrid[i].Length && MainGrid[i][j+1] == '1') neighbours.Add(new List<int>() { i, j + 1});
            if ((j - 1) >= 0 && MainGrid[i][j - 1] == '1') neighbours.Add(new List<int>() { i, j - 1 });

            return neighbours;
        }


        //LC 695
        //You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.
        //The area of an island is the number of cells with a value 1 in the island.
        //Return the maximum area of an island in grid.If there is no island, return 0.


        public static int MaxAreaOfIsland(int[][] grid)
        {
            MainIntGrid = grid;
            int maxArea = 0;
            for (int i = 0; i < MainIntGrid.Length; i++)
            {
                for (int j = 0; j < MainIntGrid[i].Length; j++)
                {
                    if (MainIntGrid[i][j] == 1)
                    {
                        int result = BFSIntArea(i, j);
                        if (result > maxArea) maxArea = result;
                    }
                }
            }
            return maxArea;
        }

        public static int BFSIntArea(int i, int j)
        {
            Queue<int[][]> q = new Queue<int[][]>();
            q.Enqueue(new int[][] { new int[] { i, j } });
            MainIntGrid[i][j] = 2; //visited
            int count = 0;

            while (q.Count > 0)
            {
                int[][] node = q.Dequeue();
                count++; //count everytime we pop a node

                List<List<int>> neighbours = GetNeighboursInt(node[0][0], node[0][1]);

                for (int n = 0; n < neighbours.Count; n++)
                {
                    if (MainIntGrid[neighbours[n][0]][neighbours[n][1]] == 1)
                    {
                        MainIntGrid[neighbours[n][0]][neighbours[n][1]] = 2;
                        q.Enqueue(new int[][] { new int[] { neighbours[n][0], neighbours[n][1] } });
                    }
                }
            }

            return count;
        }

        public static List<List<int>> GetNeighboursInt(int i, int j)
        {
            List<List<int>> neighbours = new List<List<int>>();

            if ((i - 1) >= 0 && MainIntGrid[i - 1][j] == 1) neighbours.Add(new List<int>() { i - 1, j });
            if ((i + 1) < MainIntGrid.Length && MainIntGrid[i + 1][j] == 1) neighbours.Add(new List<int>() { i + 1, j });
            if ((j + 1) < MainIntGrid[i].Length && MainIntGrid[i][j + 1] == 1) neighbours.Add(new List<int>() { i, j + 1 });
            if ((j - 1) >= 0 && MainIntGrid[i][j - 1] == 1) neighbours.Add(new List<int>() { i, j - 1 });

            return neighbours;
        }


        //LC 733

        public static int[][] MainImage;
        public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            MainImage = image;

            if (MainImage[sr][sc] == newColor) return MainImage;
            BFSFloddFill(sr, sc, MainImage[sr][sc], newColor);

            return MainImage;
        }

        public static void BFSFloddFill(int i, int j, int oldColor, int newColor)
        {
            Queue<int[][]> q = new Queue<int[][]>();
            q.Enqueue(new int[][] { new int[] { i, j } });
            MainImage[i][j] = newColor; //visited

            while (q.Count > 0)
            {
                int[][] node = q.Dequeue();
                List<List<int>> neighbours = GetNeighboursFloodFill(node[0][0], node[0][1], oldColor);

                for (int n = 0; n < neighbours.Count; n++)
                {
                    if (MainImage[neighbours[n][0]][neighbours[n][1]] == oldColor)
                    {
                        MainImage[neighbours[n][0]][neighbours[n][1]] = newColor;
                        q.Enqueue(new int[][] { new int[] { neighbours[n][0], neighbours[n][1] } });
                    }
                }
            }
        }

        public static List<List<int>> GetNeighboursFloodFill(int i, int j, int oldColor)
        {
            List<List<int>> neighbours = new List<List<int>>();

            if ((i - 1) >= 0 && MainImage[i - 1][j] == oldColor) neighbours.Add(new List<int>() { i - 1, j });
            if ((i + 1) < MainImage.Length && MainImage[i + 1][j] == oldColor) neighbours.Add(new List<int>() { i + 1, j });
            if ((j + 1) < MainImage[i].Length && MainImage[i][j + 1] == oldColor) neighbours.Add(new List<int>() { i, j + 1 });
            if ((j - 1) >= 0 && MainImage[i][j - 1] == oldColor) neighbours.Add(new List<int>() { i, j - 1 });

            return neighbours;
        }

    }
}
