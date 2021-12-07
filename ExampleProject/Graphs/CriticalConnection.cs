using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Graphs
{
    public class CriticalConnection
    {
        int[] indegree;
        IList<int>[] AdjacencyListUsingArray;
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {

            IList<IList<int>> result = new List<IList<int>>();
            AddEdges(n, connections, true);
            for (int i = 0; i < n; i++)
           {
                if (indegree[i] == 1)
                    result.Add(new List<int>(){ i, AdjacencyListUsingArray[i][0] });
            }

            return result;
        }

        public void AddEdges(int n, IList<IList<int>> connections, bool biDir = true)
        {
            AdjacencyListUsingArray = new IList<int>[n];
            indegree = new int[n];
            for (int i = 0; i < n; i++)
            {
                AdjacencyListUsingArray[i] = new List<int>();
            }
            for (int i = 0; i < connections.Count; i++)
            {
                AdjacencyListUsingArray[connections[i][0]].Add(connections[i][1]);
                indegree[connections[i][0]]++;
                if (biDir)
                {
                    AdjacencyListUsingArray[connections[i][1]].Add(connections[i][0]);
                    indegree[connections[i][1]]++;
                }
            }
        }
    }
}
