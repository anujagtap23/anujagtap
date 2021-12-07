using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Recursion
{
    public class NQueens
    {
        public static void NQueensArrangement(int numOfQueens)
        {
            NQueensArrangementHelper(numOfQueens, 0, new List<int>());
        }

        public static void NQueensArrangementHelper(int numOfQueens, int row, List<int> board)
        {
            if (numOfQueens == row)
            {
                StringBuilder str = new StringBuilder();
                foreach (int i in board)
                     str.Append($"{i},");

                Console.WriteLine($"({str.ToString()})");
            }
            else
            {
                for(int col= 0; col < numOfQueens; col++)
                {
                    if (SafeToPlaceQueenAt(board, row, col))
                    {
                        board.Add(col);
                        NQueensArrangementHelper(numOfQueens, row + 1, board);
                        board.RemoveAt(board.Count - 1);
                    }
                }
            }
        }

        public static bool SafeToPlaceQueenAt(List<int> board, int newRow, int newCol)
        {
            foreach (int col in board)
                if (newCol == col) return false;

            for (int row = 0; row < board.Count; row++)
            {
                if (Math.Abs(row - newRow) == Math.Abs(board[row] - newCol))
                    return false;
            }

            return true;

        }
    }
}
