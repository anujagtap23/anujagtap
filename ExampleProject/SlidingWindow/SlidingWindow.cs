using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleProject.SlidingWindow
{
    public static class SlidingWindow
    {
        public static void SlidingWindowMain(String[] args)
        {
            String str = "aabbbaa";
            int count = findAllPalindromeSubstrings(str);
            Console.WriteLine("Total palindrome substrings: " + count);
        }

        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            List<int> result = new List<int>();
            List<int> q = new List<int>();
            for (int i = 0; i < k; i++)
            {
                while (q.Count > 0 && q[q.Count - 1] < nums[i])
                {
                    q.RemoveAt(q.Count - 1);
                }
                q.Add(nums[i]);
            }

            result.Add(q[0]);
            int ptr = k;

            while (ptr < nums.Length)
            {
                if (q[0] == nums[ptr - k])
                    q.RemoveAt(0);

                while (q.Count > 0 && q[q.Count - 1] < nums[ptr])
                {
                    q.RemoveAt(q.Count - 1);
                }

                q.Add(nums[ptr]);
                result.Add(q[0]);
                ptr++;
            }

            return result.ToArray();
        }


        //LC 567. Permutation in String
        public static bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;
            SortedDictionary<char, int> hmap_s1 = new SortedDictionary<char, int>();
            SortedDictionary<char, int> hmap_s2 = new SortedDictionary<char, int>();

            foreach (char s in s1)
            {
                if (hmap_s1.ContainsKey(s))
                    hmap_s1[s] += 1;
                else
                    hmap_s1.Add(s, 1);
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (hmap_s2.ContainsKey(s2[i]))
                    hmap_s2[s2[i]] += 1;
                else
                    hmap_s2.Add(s2[i], 1);
            }

            if (hmap_s1.SequenceEqual(hmap_s2)) return true;

            for (int i = s1.Length; i < s2.Length; i++)
            {
                hmap_s2[s2[i - s1.Length]] -= 1;

                if (hmap_s2[s2[i - s1.Length]] == 0)
                    hmap_s2.Remove(s2[i - s1.Length]);

                if (hmap_s2.ContainsKey(s2[i]))
                    hmap_s2[s2[i]] += 1;
                else
                    hmap_s2.Add(s2[i], 1);

                if (hmap_s1.SequenceEqual(hmap_s2)) return true;
            }
            return false;
        }

        public static int findPalindromesInSubString(string input, int j, int k)
        {
            int count = 0;
            for (; j >= 0 && k < input.Length; --j, ++k)
            {
                if (input[j] != input[k])
                {
                    break;
                }
                Console.WriteLine(input.Substring(j, k + 1));
                count++;
            }
            return count;
        }

        public static int findAllPalindromeSubstrings(String input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                count += findPalindromesInSubString(input, i - 1, i + 1);
                count += findPalindromesInSubString(input, i, i + 1);
            }

            return count;
        }

        
    }
}
