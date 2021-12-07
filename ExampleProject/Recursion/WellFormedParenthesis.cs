using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Recursion
{
    public class WellFormedParenthesis
    {
        public static List<string> WellFormedParenthesisGenerator(int numOfParenthesis)
        {
            List<string> result = new List<string>();
            WellFormedParenthesisGeneratorHelper(numOfParenthesis, numOfParenthesis, new StringBuilder(), result);
            return result;
        }

        public static void WellFormedParenthesisGeneratorHelper(int remainingOpen, int remainingClose, StringBuilder soFar, List<string> result)
        {
            if (remainingOpen > remainingClose) return;

            if(remainingOpen == 0 && remainingClose == 0)
            {
                result.Add(soFar.ToString());
            }
            else
            {
                if(remainingOpen > 0)
                {
                    soFar.Append("(");
                    WellFormedParenthesisGeneratorHelper(remainingOpen - 1, remainingClose, soFar, result);
                    soFar.Remove(soFar.Length - 1, 1);
                }

                if (remainingClose > 0)
                {
                    soFar.Append(")");
                    WellFormedParenthesisGeneratorHelper(remainingOpen, remainingClose - 1, soFar, result);
                    soFar.Remove(soFar.Length - 1, 1);
                }
            }

        }
    }
}
