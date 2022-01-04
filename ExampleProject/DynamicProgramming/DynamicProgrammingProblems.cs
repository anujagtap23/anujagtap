using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.DynamicProgramming
{
    public static class DynamicProgrammingProblems
    {
        //LC 72 Edit distance : min operations required to go from word1 -> word2
        static int LevenshteinDistance(string strWord1, string strWord2)
        {

            int[][] table = new int[strWord1.Length + 1][];

            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new int[strWord2.Length + 1];
            }

            for (int i = 0; i < table[0].Length; i++)
            {
                table[0][i] = i;
            }

            for (int i = 0; i < table.Length; i++)
            {
                table[i][0] = i;
            }

            for (int i = 1; i < table.Length; i++)
            {
                for (int j = 1; j < table[i].Length; j++)
                {
                    table[i][j] = Math.Min(table[i][j - 1] + 1, Math.Min(table[i - 1][j - 1] + (strWord1[i - 1] == strWord2[j - 1] ? 0 : 1), table[i - 1][j] + 1));
                }

            }

            return table[strWord1.Length][strWord2.Length];

        }


    }
}
