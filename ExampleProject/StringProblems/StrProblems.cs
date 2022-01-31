using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ExampleProject.StringProblems
{    
    
    public static class StrProblems
    {   //LC 68 https://leetcode.com/problems/text-justification/
        public static IList<string> FullJustify(string[] words, int maxWidth)
        {
            IList<string> result = new List<string>();

            if (words != null && words.Length > 0 && maxWidth > 0)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < words.Length; i++)
                {
                    string s = words[i];
                    //1. total length < max so we need to add space at the end
                    if ((sb.Length + s.Length) < maxWidth)
                    {
                        sb.Append(s);
                        if (sb.Length < maxWidth) sb.Append(" ");
                    }
                    //2. total length == max so no space after
                    else if ((sb.Length + s.Length) == maxWidth)
                    {
                        sb.Append(s);
                        result.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                    //3. new length > max so we need to adjust current line and start a new one

                    else if ((sb.Length + s.Length) > maxWidth)
                    {
                        result.Add(AdjustSpaces(sb, false, maxWidth));//we are fixing previous line, the ith wrd is yet to be added in the new string
                        sb = new StringBuilder();
                        sb.Append(s);
                        if (s.Length < maxWidth) sb.Append(" ");
                    }
                }

                //take care of last one
                if (sb.Length > 0 && sb.Length <= maxWidth) result.Add(AdjustSpaces(sb, true, maxWidth));
            }

            return result;
        }


        public static string AdjustSpaces(StringBuilder s, bool isLast, int maxWidth)
        {
            StringBuilder ss = new StringBuilder(s.ToString().Trim());
            int remaining = maxWidth - ss.Length;
            int currSpaces = 0;
            foreach (char c in ss.ToString())
            {
                if (c == ' ') currSpaces++;
            }

            if (isLast || currSpaces == 0)
            {
                while (ss.Length < maxWidth)
                    ss.Append(" ");

                return ss.ToString();
            }
            else
            {
                int addition = remaining / currSpaces;
                int leftAdd = remaining % currSpaces;
                if (addition > 0)
                {
                    string space = " ";
                    while (addition > 0)
                    {
                        space += " ";
                        addition--;
                    }

                    ss.Replace(" ", space);

                }

                if (leftAdd > 0)
                {
                    bool spaceFound = false;
                    for (int i = 0; i < ss.Length; i++)
                    {
                        if (ss[i] == ' ' && !spaceFound && leftAdd > 0)
                        {
                            spaceFound = true;
                            ss.Insert(i, " ");
                            leftAdd--;
                            if (leftAdd == 0) break;
                        }
                        else if (ss[i] != ' ')
                            spaceFound = false;
                    }
                }
                return ss.ToString();
            }
        }

        public static string AdjustSpacesOld(StringBuilder s, bool isLast, int maxWidth)
        {
            StringBuilder ss = new StringBuilder(s.ToString().Trim());
            int remaining = maxWidth - ss.Length;
            int currSpaces = 0;
            foreach (char c in ss.ToString())
            {
                if (c == ' ') currSpaces++;
            }

            if (isLast || currSpaces == 0)
            {
                while (ss.Length < maxWidth)
                    ss.Append(" ");

                return ss.ToString();
            }
            else
            {
                int addition = remaining / currSpaces;
                int leftAdd = remaining % currSpaces;
                if (addition > 0)
                {
                    string space = " ";
                    while (addition > 0)
                    {
                        space += " ";
                        addition--;
                    }

                    ss.Replace(" ", space);

                }

                if (leftAdd > 0)
                {
                    string space = "";
                    while (leftAdd > 0)
                    {
                        space += " ";
                        leftAdd--;
                    }

                    string updatedString = ss.ToString();
                    int index = -1;
                    for (int i = 0; i < updatedString.Length; i++)
                    {
                        if (ss[i] == ' ') { index = i; break; }
                    }
                    ss.Insert(index, space);
                }
                return ss.ToString();
            }
        }

        public static  int Reverse(int x)
        {
            int reversed = 0;
            int multiplier = 1;

            while (x > 0)
            {
                int mod = x % 10;
                x = x / 10;
                reversed = (multiplier * reversed) + mod;
                multiplier = 10;
            }
            return reversed;
        }

        public static int StrStr(string haystack, string needle)
        {

            int firstOccurance = -1;
            if (string.IsNullOrWhiteSpace(needle))
            {
                return 0;
            }

            int h = 0, n = 0;

            while (h < haystack.Length && n < needle.Length)
            {
                if (firstOccurance != -1)
                {
                    h = firstOccurance + 1;
                    firstOccurance = -1;
                    n = 0;
                }

                if (haystack[h] != needle[n])
                {
                    h++;
                    firstOccurance = -1;
                    n = 0;
                }
                else
                {
                    firstOccurance = h;
                    while (h < haystack.Length && n < needle.Length && haystack[h] == needle[n])
                    {
                        h++; n++;
                    }

                    if (n == needle.Length)
                        return firstOccurance;

                }
            }

            return -1;
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            

            if (strs == null || strs.Length == 0) return new List<IList<string>>();

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach (string s in strs)
            {
                int[] count = new int[26];

                foreach (char c in s) count[c - 'a'] += 1;

                StringBuilder sb = new StringBuilder();

                foreach (char c in count) sb.Append("#" + c);

                if (map.ContainsKey(sb.ToString()))
                    map[sb.ToString()].Add(s);
                else
                    map.Add(sb.ToString(), new List<string>() { s });

            }

            List<string>[] array = new List<string>[map.Count];
            map.Values.CopyTo(array, 0);

            return array;


        }

        
        

        public static bool CheckStringFollowsRules(string input, string rules)
        {
            int MaxIndex = 0;
            if (string.IsNullOrWhiteSpace(input)) return true;

            Dictionary<char, int> Hmap = BuildHashMapOfRules(rules);

            for (int i = 0; i < input.Length; i++)
            {
                if (Hmap.ContainsKey(input[i]))
                {
                    if (MaxIndex > Hmap[input[i]]) return false;
                    else MaxIndex = Hmap[input[i]];
                }
            }
            return true;
        }

        public static Dictionary<char, int> BuildHashMapOfRules(string rules)
        {
            Dictionary<char, int> Hmap = new Dictionary<char, int>();
            for (int i = 0; i < rules.Length; i++)
            {
                Hmap.Add(rules[i], i);
            }
            return Hmap;
        }
    }
}

