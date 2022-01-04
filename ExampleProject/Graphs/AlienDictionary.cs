using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Graphs
{
    public class AlienDictionary
    {
        public Dictionary<char, List<char>> adjList;
        public int vertices;
        public List<char> topArr = new List<char>();

        public Dictionary<char, bool> visited = new Dictionary<char, bool>();
        public Dictionary<char, bool> departure = new Dictionary<char, bool>();

        public string AlienOrder(string[] words)
        {

            if (words.Length == 1) return words[0];

            adjList = new Dictionary<char, List<char>>();

            return BuildGraph(words);

        }

        public string BuildGraph(string[] words)
        {
            for (int i = 0; i < words.Length - 1; i++)
            {
                FindFirstDiff(words[i].ToCharArray(), words[i + 1].ToCharArray());
            }

            foreach (string word in words)
            {
                foreach (char c in word.ToCharArray())
                {
                    if (!adjList.ContainsKey(c))
                    {
                        adjList.Add(c, new List<char>());
                    }
                }
            }

            foreach(char c in adjList.Keys)
            {
                visited.Add(c, false);
                departure.Add(c, false);
            }

            foreach(char c in adjList.Keys)
            {
                if (!visited[c])
                {
                    if (!dfs(c)) return "";
                }
            }

            topArr.Reverse();

            return new string(topArr.ToArray());

        }

        public bool dfs(char c)
        {
            visited[c] = true;

            foreach (char neigh in adjList[c])
            {
                if (!visited[neigh])
                {
                    if (!dfs(neigh)) return false; //cycle found
                }
                else if (!departure[neigh])
                {
                    return false; //cycle
                }
            }

            departure[c] = true;
            topArr.Add(c);

            return true;
        }

        public void FindFirstDiff(char[] first, char[] second)
        {
            int i = 0;

            while (i < first.Length && i < second.Length)
            {
                if (first[i] != second[i])
                {
                    if (adjList.ContainsKey(first[i]))
                        adjList[first[i]].Add(second[i]);
                    else
                        adjList.Add(first[i], new List<char>() { second[i]});

                    break;
                }
                i++;
            }

            
        }
    }
}
