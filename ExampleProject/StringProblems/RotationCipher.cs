using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.StringProblems
{
 

    // We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
    public static class RotationalCipher
    {
     
         public static string RotationalCipherFunc(String input, int rotationFactor)
        {
            // Write your code here
            if (string.IsNullOrWhiteSpace(input)) return "";

            StringBuilder sb = new StringBuilder();

            foreach (char c in input)
            {
                sb.Append(GetCipher(c, rotationFactor));
            }

            return sb.ToString();
        }

        private static char GetCipher(char c, int rotationFactor)
        {
            if (char.IsLetterOrDigit(c))
            {
                if (char.IsDigit(c))
                {
                    int rotated = (c - '0' + rotationFactor) % 10;
                    return (char)(rotated + '0');
                }
                else if(c >= 'A' && c <= 'Z')
                {
                    int rotated = (c - 'A' + rotationFactor) % 26;
                    return (char)(rotated + 'A');
                }
                else if (c >= 'a' && c <= 'z')
                {
                    int rotated = (c - 'a' + rotationFactor) % 26;
                    return (char)(rotated + 'a');
                }
            }
            return c;
        }
    }
}
