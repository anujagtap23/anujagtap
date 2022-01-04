using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Recursion
{
   public class PhoneNumberCombination
    {
        public IList<string> LetterCombinations(string digits)
        {

            IList<IList<char>> pad = InitializePhonePad();
            IList<string> result = new List<string>();
            if (!string.IsNullOrWhiteSpace(digits))
                LetterCombinationsHelper(digits, 0, new StringBuilder(), result, pad);
            return result;
        }

        public void LetterCombinationsHelper(string digits, int index, StringBuilder soFar, IList<string> result, IList<IList<char>> pad)
        {
            //basecase
            if (index == digits.Length)
                result.Add(soFar.ToString());
            else
            {
                IList<char> charSet = pad[Int16.Parse(digits.Substring(index, 1))];
                foreach (char c in charSet)
                {
                    soFar.Append(c);
                    LetterCombinationsHelper(digits, index + 1, soFar, result, pad);
                    soFar.Remove(soFar.Length - 1, 1);
                }
            }

        }

        public IList<IList<char>> InitializePhonePad()
        {
            IList<IList<char>> pad = new List<IList<char>>();
            pad.Add(new List<char>());
            pad.Add(new List<char>());
            pad.Add(new List<char>() { 'a', 'b', 'c' });
            pad.Add(new List<char>() { 'd', 'e', 'f' });
            pad.Add(new List<char>() { 'g', 'h', 'i' });
            pad.Add(new List<char>() { 'j', 'k', 'l' });
            pad.Add(new List<char>() { 'm', 'n', 'o' });
            pad.Add(new List<char>() { 'p', 'q', 'r', 's' });
            pad.Add(new List<char>() { 't', 'u', 'v' });
            pad.Add(new List<char>() { 'w', 'x', 'y', 'z' });
            return pad;
        }
    }
}
