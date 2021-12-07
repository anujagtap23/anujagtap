using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Recursion
{
    public class RollingDice
    {
        public static List<string> GetDesiredSumFromNRolledDice(int numOfDice, int desiredSum)
        {
            List<string> result = new List<string>();
            GetDesiredSumFromNRolledDiceHelper(numOfDice, desiredSum, 0, new StringBuilder(), result);
            return result;
        }

        public static void GetDesiredSumFromNRolledDiceHelper(int numOfDice, int targetSum, int runningSum, StringBuilder strSoFar, List<string> result)
        {
            if (runningSum > targetSum) return;
            if (runningSum + (numOfDice * 6) < targetSum) return;  //we can't reach the targetSum with remaining dices and max value
            if (runningSum + (numOfDice * 1) > targetSum) return; // with remaining dices and min value the running sum is higher

            if (numOfDice == 0 )
            {
                if (runningSum == targetSum)
                    result.Add(strSoFar.ToString());
                return;
            }
            else
            {
                for (int diceVal = 1; diceVal <= 6; diceVal++)
                {
                    strSoFar.Append(diceVal);
                    GetDesiredSumFromNRolledDiceHelper(numOfDice - 1, targetSum, runningSum + diceVal, strSoFar, result);
                    strSoFar.Remove(strSoFar.Length - 1, 1);
                }
            }
        }
    }
}
