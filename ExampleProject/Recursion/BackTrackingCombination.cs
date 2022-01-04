using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Recursion
{
    public class BackTrackingCombination
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (n > 0 && k > 0)
            {
                CombineHelper(n, 1, k, new List<int>(), result);
            }
            return result;
        }

        public void CombineHelper(int n, int curr, int k, IList<int> soFar, IList<IList<int>> result)
        {
            //backtrack 
            if (soFar.Count == k)
            {
                result.Add(new List<int>(soFar));
                return;
            }
            //leaf
            if (curr > n)
                return;

            //internal nodes
            //include
            soFar.Add(curr);
            CombineHelper(n, curr + 1, k, soFar, result);
            soFar.RemoveAt(soFar.Count - 1);

            //exclude
            CombineHelper(n, curr + 1, k, soFar, result);

        }
    }
}
