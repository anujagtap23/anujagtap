using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Recursion
{
    public class MainRecursionClass
    {
        public static void ExecuteRecursionProblems()
        {
            Console.WriteLine("============GetUpperLowerCasePermutation- High Space============\n");
            List<string> result = LetterCasePermutation.GetUpperLowerCasePermutation("t1D2");
            foreach (string s in result)
                Console.WriteLine(s);

            Console.WriteLine("============GetUpperLowerCasePermutation- Constant Space============\n");
            List<string> resultEfficient = LetterCasePermutation.GetUpperLowerCasePermutationEfficient("t1D2");
            foreach (string s in resultEfficient)
                Console.WriteLine(s);

            Console.WriteLine("============GeneratePowerSet- Constant Space============\n");
            List<string> powerSet = Powerset_AllSubSets.GeneratePowerSet(new int[] { 1, 2, 3, 4 });
            foreach (string s in powerSet)
            Console.WriteLine($"{s},");

            Console.WriteLine("============GeneratePermutations- Constant Space============\n");
            List<string> permutations = GeneratePermutation.GeneratePermutationForGivenArr(new int[] { 1, 2, 3, 4 });
            foreach (string s in permutations)
                Console.WriteLine($"{s},");

            Console.WriteLine("============GeneratePermutations for duplicate elements- Constant Space============\n");
            List<string> dupPermutations = GeneratePermutation.GeneratePermutationWithDuplicateElements(new int[] { 1, 2, 3, 4,1,2 });
            foreach (string s in dupPermutations)
                Console.WriteLine($"{s},");

            Console.WriteLine("============Generate Roll Dice Desired sum - Constant Space============\n");
            List<string> rollDiceDesiredSum = RollingDice.GetDesiredSumFromNRolledDice(2, 7);
            foreach (string s in rollDiceDesiredSum)
                Console.WriteLine($"{s},");

            Console.WriteLine("============Generate well formed parenthesis combinations - Constant Space============\n");
            List<string> parenthesis = WellFormedParenthesis.WellFormedParenthesisGenerator(3);
            foreach (string s in parenthesis)
                Console.WriteLine($"{s},");

            Console.WriteLine("============ NQueens arrangement============");
            NQueens.NQueensArrangement(4);
        }
    }
}
