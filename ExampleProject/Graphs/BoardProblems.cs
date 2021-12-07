using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Graphs
{
    public static class BoardProblems
    {
        //LC 909 snakes and ladders
        //In directed graph BFS should be used only for finding shortest path.
        static int N, maxSquare;
        static int[] visited;
        public static int SnakesAndLadders(int[][] board)
        {

            N = board.Length;
            maxSquare = N * N;
            visited = new int[maxSquare + 1];

            for (int i = 0; i < visited.Length; i++)
                visited[i] = -1;

            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            visited[1] = 0; //roll dice starts from square 1

            while (q.Count > 0)
            {
                int curr = q.Dequeue();

                for (int i = 1; i <= 6; i++)
                {
                    int next = curr + i;

                    if (next <= maxSquare)
                    {
                        SquareNode node = GetRowColumn(next);
                        if (board[node.Row][node.Col] != -1)
                        {
                            next = board[node.Row][node.Col];
                        }

                        if (visited[next] == -1) // this will make sure 1 has 0 distance and then cover scenario where snake takes back to 1
                        {
                            visited[next] = visited[curr] + 1;
                            q.Enqueue(next);//enqueue need to be done only if not visited earlier. if it is outisde of this if condiiton then it can go in infinite loop
                        }

                        if (next == maxSquare) return visited[next];
                    }
                }
            }

            return visited[maxSquare];


        }

        public static SquareNode GetRowColumn(int vertexId)
        {
            int row = (maxSquare - vertexId) / N;

            int mod = ((vertexId - 1) % (2 * N));

            int col; //below calculation is required cause the col is zigzag
            if (mod < N)
                col = mod;
            else
            {
                col = (2 * N - 1) % mod;
            }

            return new SquareNode(row, col);
        }

        //1197. Minimum Knight Moves
        public static int MinKnightMoves(int x, int y)
        {
            return find_minimum_number_of_moves(300, 300, 0, 0, x, y);
            
        }

        //row col 0 indexed
        public static int find_minimum_number_of_moves(int rows, int cols, int start_row, int start_col, int end_row, int end_col)
        {
            int moves = -1;
            //create chess board
            int[][] board = new int[rows][];
            for(int i = 0; i < rows; i++)
            {
                board[i] = new int[cols];
            }

            SquareNode end = new SquareNode(end_row, end_col);
            //BFS
            Queue <SquareNode> q = new Queue<SquareNode>();
            q.Enqueue(new SquareNode(start_row, start_col, 0)); //add to the q and set distance to 0
            board[start_row][start_col] = 1;                    //mark the node visited by settingdistnace to 1

            while(q.Count > 0)
            {
                //int currLevelSize = q.Count;

                //for (int i = 0; i < currLevelSize; i++)  //not required as we rely on parent's distance to calculate child's distance
                //{
                    SquareNode node = q.Dequeue();
                    List<SquareNode> neighbours = GetNeighbours(node, rows, cols);
                    foreach (SquareNode n in neighbours)
                    {
                        if (board[n.Row][n.Col] == 0) //not visited
                        {
                            board[n.Row][n.Col] = 1;
                            n.Distance = node.Distance + 1;
                            q.Enqueue(n);
                            if (n.CompareTo(end) == 0)
                                return n.Distance;
                        }
                    }
                //}
            }
            return moves;
        }

        public static List<SquareNode> GetNeighbours(SquareNode node, int rows, int cols)
        {
            List<SquareNode> neighbours = new List<SquareNode>();
            int[][] moves = new int[][] { new int[] { 2, 1}, new int[] { 2, -1 }, new int[] { -2, -1 }, new int[] {-2, 1 }, new int[] { 1, 2 }, new int[] { -1, 2 }, new int[] { 1, -2 }, new int[] { -1, -2 } };

            for(int i = 0; i < 8; i++)
            {
                int newRow = node.Row + moves[i][0];
                int newCol = node.Col + moves[i][1];

                if (newRow < rows && newRow  >= 0 && newCol < cols && newCol >= 0)
                    neighbours.Add(new SquareNode(newRow, newCol));//by default distance will be -1
            }
            return neighbours;
        }

    }

    public class SquareNode : IComparable
    {
        public int Row;
        public int Col;
        public int Distance = -1;


        public SquareNode(int r, int c)
        {
            Row = r;
            Col = c;
        }

        public SquareNode(int r, int c, int dist)
        {
            Row = r;
            Col = c;
            Distance = dist;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            SquareNode other = obj as SquareNode;

            if (this.Row == other.Row && this.Col == other.Col)
                return 0;
            else
                return -1;
        }
    }

}
