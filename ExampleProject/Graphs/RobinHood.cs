using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Graphs
{
    class RobinHood
    {

        /* Overview
 You are building an application that consists of many different services that can depend on each other.One of these services is the entrypoint which receives user requests and then makes requests to each of its dependencies, which will in turn call each of their dependencies and so on before returning.

 Given a directed acyclic graph that contains these dependencies, you are tasked with determining the "load factor" for each of these services to handle this load.The load factor of a service is defined as the number of units of load it will receive if the entrypoint receives a 1 unit of load.Note that we are interested in the worst case capacity.For a given downstream service, its load factor is the number of units of load it is required to handle if all upstream services made simultaneous requests. For example, in the following dependency graph where A is the entrypoint:

 Each query to A will generate one query to B which will pass it on to C and from there to D. A will also generate a query to C which will pass it on to D, so the worst case (maximum) load factors for each service is A:1, B:1, C:2, D:2.
 (Important: make sure you've fully understood the above example before proceeding!)

 Problem Details

 service_list: An array of strings of format service_name= dependency1, dependency2.Dependencies can be blank (e.g.dashboard=) and non-existent dependency references should be ignored(e.g.prices= users, foobar and foobar is not a service defined in the graph). Each service is defined only once in the graph.
 entrypoint: An arbitrary service that is guaranteed to exist within the graph
 Output: A list of all services depended by (and including) entrypoint as an array of strings with the format service_name*load_factor sorted by service name.
 Example


 # Input:
 service_list = ["logging=",
  "user=logging",
  "orders=user,foobar",
  "recommendations=user,orders",
  "dashboard=user,orders,recommendations"]
 entrypoint = "dashboard"

 # Output (note sorted by service name)
 ["dashboard*1",
  "logging*4",
  "orders*2",
  "recommendations*1",
  "user*4"]
 [execution time limit] 3 seconds (cs)

 [input] array.string service_list

 [input] string entrypoint

 [output] array.string

 */

        Dictionary<string, List<string>> AdjList = new Dictionary<string, List<string>>();
        Dictionary<string, int> CountMap = new Dictionary<string, int>();

        string[] solution(string[] service_list, string entrypoint)
        {

            BuildAdjList(service_list);
            DFSTraversal(entrypoint);
            return CreateResult(CountMap);
        }



        void DFSTraversal(string node)
        {
            if (!AdjList.ContainsKey(node)) return;

            if (CountMap.ContainsKey(node)) CountMap[node] += 1;
            else
            {
                CountMap.Add(node, 1);
            }

            List<string> neighs = AdjList[node];
            foreach (string nb in neighs)
            {
                DFSTraversal(nb);
            }
        }

        string[] CreateResult(Dictionary<string, int> map)
        {
            List<string> result = new List<string>();

            foreach (var s in map.Keys)
            {
                string res = s + "*" + map[s];
                result.Add(res);
            }
            result.Sort();

            return result.ToArray();
        }

        void BuildAdjList(string[] service_list)
        {
            if (service_list != null && service_list.Length > 0)
            {
                foreach (string s in service_list)
                {
                    string[] firstSplit = s.Split('=');

                    if (firstSplit.Length == 2)
                    {
                        string vertex = firstSplit[0];
                        string[] neigh = firstSplit[1].Split(',');
                        if (AdjList.ContainsKey(vertex))
                        {
                            foreach (string n in neigh)
                            {
                                AdjList[vertex].Add(n);
                            }
                        }
                        else
                        {
                            AdjList.Add(vertex, new List<string>());
                            foreach (string n in neigh)
                            {
                                AdjList[vertex].Add(n);
                            }
                        }
                    }
                }

            }
        }

    }
    

    }
