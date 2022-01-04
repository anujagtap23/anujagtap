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

    //from LeetCode
    public class Solution
    {
        public IList<IList<string>> SolveNQueens(int n)
        {

            IList<IList<string>> result = new List<IList<string>>();
            Helper(n, 0, new List<int>(), result);
            return result;

        }

        public IList<string> ConvertResult(List<int> result, int n)
        {
            IList<string> strList = new List<string>();
            foreach (int col in result)
            {
                StringBuilder s = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    if (i != col)
                        s.Append(".");
                    else
                        s.Append("Q");
                }
                strList.Add(s.ToString());
            }

            return strList;
        }

        public void Helper(int totalQueens, int currQueen, List<int> soFar, IList<IList<string>> result)
        {
            //backtrack
            //same row is alreayd taken care of as we ar considering each queen is in separate row                

            for (int row = 0; row < soFar.Count - 1; row++)
            {
                //same col check for the latest added queen col value vs all previous
                if (soFar[row] == soFar[currQueen - 1])
                    return;

                //same diagonal check
                int rowDiff = Math.Abs(row - (currQueen - 1));
                int colDiff = Math.Abs(soFar[row] - soFar[currQueen - 1]);

                if (rowDiff == colDiff)
                    return;
            }


            //basecase
            if (currQueen == totalQueens)
            {
                result.Add(ConvertResult(soFar, totalQueens));
                return;
            }

            //resursive
            for (int col = 0; col < totalQueens; col++)
            {
                soFar.Add(col);
                Helper(totalQueens, currQueen + 1, soFar, result);
                soFar.RemoveAt(soFar.Count - 1);
            }
        }
    }
}
