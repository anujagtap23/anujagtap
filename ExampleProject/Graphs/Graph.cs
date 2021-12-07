using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Graphs
{
    public class Graph
    {
        public int NumberOfVertices;
        public List<int> [] AdjacencyListUsingArray;//vertex ids are ints so can use as indexes of arrays
        public Dictionary<string, List<string>>  AdjacencyListUsingMap; //vertex are strings so need hashmap to return them in O(1). The list is still present foradjaceny
        public Dictionary<Object, Dictionary<Object, Object>> AdjacencyMap; //vertex are objs so need hashmap to return them in O(1). For adjaceny also we need map
        public int[][] AdjacencyMatrix; //Matrix represenation
        public int[] captured; //these can be defined as BitArray captured for compact storage
        public int[] parent;
        public int[] visited;//these can be defined as BitArray visited for compact storage
        public int[] arrival;
        public int[] departure;
        public Graph(int v)
        {
            NumberOfVertices = v;
            //assume all vertices have Ids 1 to v
            AdjacencyListUsingArray = new List<int> [v];

            for (int i = 0; i < v; i++)
                AdjacencyListUsingArray[i] = new List<int>();

            captured = new int[NumberOfVertices];
            parent = new int[NumberOfVertices];
            visited = new int[NumberOfVertices];
            arrival = new int[NumberOfVertices];
            departure = new int[NumberOfVertices];
        }

        public void AddEdge(int start, int end, bool biDir = true)
        {
            if(AdjacencyListUsingArray[start] != null)
                AdjacencyListUsingArray[start].Add(end);

            if (biDir) AdjacencyListUsingArray[end].Add(start);
        }
        public static Graph BuildGraph()
        {
            Graph graph = new Graph(8);
            graph.AdjacencyListUsingArray[0] = new List<int>() { 1 };
            graph.AdjacencyListUsingArray[1] = new List<int>() { 2, 3 };
            graph.AdjacencyListUsingArray[2] = new List<int>() { 4, 5 };
            graph.AdjacencyListUsingArray[3] = new List<int>() { 6 };
            graph.AdjacencyListUsingArray[4] = new List<int>() { 7 };
            graph.AdjacencyListUsingArray[5] = new List<int>() { 7 };
            graph.AdjacencyListUsingArray[6] = new List<int>() { 7 };
            graph.AdjacencyListUsingArray[7] = new List<int>() { 4, 5, 6 };
            return graph;
        }

        //connected graph has EC iff every vertex has even degree
        public bool HasEulerianCycle(int node)
        {
            bool hasOddDegreeVertex = false;

            foreach(List<int> vetrexList in AdjacencyListUsingArray)
            {
                if(vetrexList.Count % 2 == 1)
                {
                    hasOddDegreeVertex = true;
                    break;
                }
            }

            return (!hasOddDegreeVertex);

        }

        //connected graph has EP iff there is EC  or exact 2 vertices with odd degree
        public bool HasEulerianPath(int node)
        {
            int hasOddDegreeVertex = 0;

            foreach (List<int> vetrexList in AdjacencyListUsingArray)
            {
                if (vetrexList.Count % 2 == 1)
                {
                    hasOddDegreeVertex++;
                }
            }

            return (hasOddDegreeVertex == 0 || hasOddDegreeVertex == 2) ? true : false;

        }

        public void BFS(int start)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = 1;

            while(queue.Count > 0)
            {
                int node = queue.Dequeue();
                captured[node] = 1;//before exploring the neighbors 

                foreach(int neighbor in AdjacencyListUsingArray[node])
                {
                    if (visited[neighbor] == 0)
                    {
                        visited[neighbor] = 1;
                        parent[neighbor] = node;
                        queue.Enqueue(neighbor);
                    }
                }
            }

        }

        public void BFS(int start, int component)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = component;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                captured[node] = 1;//before exploring the neighbors 

                foreach (int neighbor in AdjacencyListUsingArray[node])
                {
                    if (visited[neighbor] == 0)
                    {
                        visited[neighbor] = component;
                        parent[neighbor] = node;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        public void DFSIterative(int start)
        {
            int[] captured = new int[NumberOfVertices];
            int[] parent = new int[NumberOfVertices];
            int[] visited = new int[NumberOfVertices];

            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            visited[start] = 1;

            while (stack.Count > 0)
            {
                int node = stack.Pop();
                captured[node] = 1;//before exploring the neighbors 

                foreach (int neighbor in AdjacencyListUsingArray[node])
                {
                    if (visited[neighbor] == 0)
                    {
                        visited[neighbor] = 1;
                        parent[neighbor] = node;
                        stack.Push(neighbor);
                    }
                }
            }

        }

        //time : O(m + n)  space : O(n) for parent, visited arr and implicit stack
        public void DFSRecursive(int node)
        {
            visited[node] = 1;

            foreach (int neighbor in AdjacencyListUsingArray[node])
            {
                if (visited[neighbor] == 0)
                {
                    parent[neighbor] = node;
                    DFSRecursive(neighbor);
                }
            }
        }

        public bool DetectCycleInDirectedGraph()
        {
            for (int i = 0; i < NumberOfVertices; i++)
            {
                if (visited[i] == 0)
                {
                    if (DFSDirectedRecursive(i)) return true;
                }
            }
            return false;
        }

        public int TimeStamp = 0;
        public bool DFSDirectedRecursive(int node)
        {
            visited[node] = 1;
            arrival[node] = TimeStamp++;
            foreach (int neighbor in AdjacencyListUsingArray[node])
            {
                if (visited[neighbor] == 0)
                {
                    parent[neighbor] = node;
                    if(DFSDirectedRecursive(neighbor)) return true; // cycle found
                }
                else
                {
                    if (departure[neighbor] == 0)//back edge
                        return true;
                }

            }
            departure[node] = TimeStamp++;
            return false;
        }

        //LC 323 find connected components 
        //the visited array will have component numbers
        public int GetNumOfComponentsBFS()
        {
            int components = 0;
            for (int i = 0; i < NumberOfVertices; i++)
            {
                if (visited[i] == 0)
                {
                    components++;
                    BFS(i, components);
                }
            }
            return components;
        }

        //LC 323 find connected components 
        //the visited array will have component numbers
        public int GetNumOfComponentsDFS()
        {
            int components = 0;
            for (int i = 0; i < NumberOfVertices; i++)
            {
                if(visited[i] == 0)
                {
                    components++;
                    DFSRecursive(i, components);
                }
            }
            return components;
        }

        //time : O(m + n)  space : O(n) for parent, visited arr and implicit stack
        public void DFSRecursive(int node, int component)
        {
            visited[node] = component;

            foreach (int neighbor in AdjacencyListUsingArray[node])
            {
                if (visited[neighbor] == 0)
                {
                    parent[neighbor] = node;
                    DFSRecursive(neighbor, component);
                }
            }
        }
        //LeetCode 785
        //Recall that a graph is bipartite if we can split its set of
        //nodes into two independent subsets A and B such that
        //every edge in the graph has one node in A and another node in B.

        //observation : if graph has odd lenght cycle i.e. it has a cross edge at the same level
        //Cross edge across layer : the length of this cycle is even 

        public bool IsBiPartite()
        {
            int level = 0;
            for(int i = 0; i < NumberOfVertices; i++)
            {
                if(visited[i] == 0)
                {
                    level++;
                    if (!BFSforBiPartite(i, level))
                        return false;
                }
            }
            return true;
        }


        public bool BFSforBiPartite(int start, int level)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = level;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                foreach (int neighbor in AdjacencyListUsingArray[node])
                {
                    if (visited[neighbor] == 0)
                    {
                        visited[neighbor] = visited[node] + 1;
                        parent[neighbor] = node;
                        queue.Enqueue(neighbor);
                    }
                    else
                    {
                        if(neighbor != parent[node]) // the neighbor is not it's parent, In BFS there can be cross edge between parent/child or across same level
                        {
                            //IsBelow really required?
                            if(visited[node] == visited[neighbor])// we can check if the level is same then also it is false
                                return false; 
                        }
                    }
                }
            }

            return true;
        }

        //LC 261 : Graph valid tree(trees don't have cycles. they are connected)
        public bool IsGraphTree()
        {
            int component = 0;
            for (int i = 0; i < NumberOfVertices; i++)
            {
                if (visited[i] == 0)
                {
                    component++;
                    if (BFSforIsTree(i) == false)
                        return false;
                }
            }
            if (component > 1) return false;
            return true;
        }

        public bool BFSforIsTree(int start)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = 1;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                foreach (int neighbor in AdjacencyListUsingArray[node])
                {
                    if (visited[neighbor] == 0)
                    {
                        visited[neighbor] = 1;
                        parent[neighbor] = node;
                        queue.Enqueue(neighbor);
                    }
                    else
                    {
                        if (neighbor != parent[node])  return false; //while exploring child we will come across parent as visited. and that's okay
                    }
                }
            }

            return true;
        }

        //LC 886 : two color problem / Possible bipartition. Bot hos them are IsBirPartite() probelm
        //Can the vertices of a graph can be colored using only 2 colors such that adjacent vertices are not same color
        //there is an array of dislikes[i] = [a,b] where a does not like b, given 0 to n-1 people can you build two grps which does not have people who dislike each other

        public bool GroupPeopleDislikes(int n, int[][]dislikes)
        {
            for (int i = 0; i < dislikes.Length; i++)
                AddEdge(dislikes[i][0], dislikes[i][1]);

            return IsBiPartite();
        }

  



    }
}
