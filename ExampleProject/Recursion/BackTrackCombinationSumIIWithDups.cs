using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject.Recursion
{
    public class BackTrackCombinationSumIIWithDups
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);//so all dups are together
            CombinationSum2Helper(candidates, 0, new List<int>(), result, target, 0);
            return result;
        }

        public void CombinationSum2Helper(int[] candidates, int index, List<int> soFar, IList<IList<int>> result, int target, int soFarSum)
        {
            //backtrack 
            if (soFarSum == target)
            {
                result.Add(new List<int>(soFar));
                return;
            }

            //basecase
            if (index == candidates.Length)
                return;
            //recursive
            int count = 0;
            for (int i = index; i < candidates.Length; i++)
            {
                if (candidates[i] != candidates[index])
                {
                    break;
                }
                count++;
            }

            //exclude
            CombinationSum2Helper(candidates, index + count, soFar, result, target, soFarSum);

            //include
            for (int i = 0; i < count; i++)
            {
                soFar.Add(candidates[index]);
                soFarSum += candidates[index];
                CombinationSum2Helper(candidates, index + count, soFar, result, target, soFarSum);
            }

            for (int i = 0; i < count; i++)
            {
                soFar.RemoveAt(candidates.Length - 1);
                soFarSum -= candidates[index];
            }
        }

        //public int TargetSum(List<int>)
    }
}
