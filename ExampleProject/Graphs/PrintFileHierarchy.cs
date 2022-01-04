using System;
using System.Collections.Generic;
using System.Linq;

//Time O(v+e)  Space O(v+e)

/* 
  files := []string{
    "webpage/assets/html/a.html",
    "webpage/assets/html/b.html",
    "webpage/assets/js/c.js",
    "webpage/index.html",
  }

-webpage
--assets
----html
------a.hmtl
------b.hmtl
----js
------c.js
--index.html




time and space both : O(E+V)
 */

namespace ExampleProject.Graphs
{
    public class PrintFileHierarchy
    {
        public static Dictionary<string, List<string>> AdjList;
        public static List<string> RootList = new List<string>();
        public static Dictionary<string, bool> visited;
        static void FileMain(string[] args)
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("Hello, World");
            }

            string[] arr = new string[] {"webpage/assets/html/a.html",
        "webpage/assets/html/b.html",
        "webpage/assets/js/c.js",
        "webpage/index.html"};

            PrintFileHierarchy obj = new PrintFileHierarchy();
            obj.PrintHeirarchy(arr);


        }


        public void PrintHeirarchy(string[] arr)
        {
            visited = new Dictionary<string, bool>();

            if (arr != null && arr.Length > 0)
            {
                BuildGraph(arr);

                foreach(string root in RootList)
                    DFSTraversal("-", root);

            }
        }

        public static void BuildGraph(string[] arr)
        {
            AdjList = new Dictionary<string, List<string>>();

            foreach (string str in arr)
            {
                if (!string.IsNullOrWhiteSpace(str))
                {

                    string[] split = str.Split('/');

                    for (int i = 0; i < split.Length - 1; i++)
                    {
                        if (i == 0 && !RootList.Contains(split[0]))
                            RootList.Add(split[0]);

                        if (AdjList.ContainsKey(split[i]))
                        {
                            AdjList[split[i]].Add(split[i + 1]);
                        }
                        else
                        {
                            AdjList.Add(split[i], new List<string>() { split[i + 1] });
                        }
                    }

                }
            }

        }

        public static void DFSTraversal(string tab, string vertex)
        {
            visited.Add(vertex, true);

            Console.WriteLine(tab + vertex);

            if (!AdjList.ContainsKey(vertex)) return;

            if (AdjList.ContainsKey(vertex))
            {
                foreach (string str in AdjList[vertex])
                {
                    if (!visited.ContainsKey(str))
                        DFSTraversal(tab + "-", str);
                }
            }
            else
                return;
        }
    }
}