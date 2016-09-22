using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyingProject3.Extensions;

namespace StudyingProject3.Recursion
{
    public static class Recursion
    {
        public static int CutRod(int[] prices, int n)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            if (n == 0)
            {
                return 0;
            }

            int maxValue = 0;

            for (int i = 0; i < n; i++)
            {
                maxValue = IntExtensions.Max(maxValue, prices[i] + CutRod(prices, n - i - 1));
            }

            return maxValue;
        }

        public static int SubsetSum(int[] values, int target)
        {
            var solution = new bool[values.Length];

            var indicesInSolution = new HashSet<int>();

            SubsetSum(values, target, 0, 0, solution, indicesInSolution);

            return indicesInSolution.Count;
        }

        private static void SubsetSum(int[] values, int target, int currentSum, int currentIndex, bool[] solution, HashSet<int> indicesInSolution)
        {
            if (currentSum == target)
            {
                for (int i = 0; i < solution.Length; i++)
                {
                    if (solution[i] == true)
                    {
                        indicesInSolution.Add(i);
                    }
                }
                return;
            }

            if (currentIndex == values.Length)
            {
                return;
            }

            solution[currentIndex] = true;
            currentSum += values[currentIndex];
            SubsetSum(values, target, currentSum, currentIndex + 1, solution, indicesInSolution);

            solution[currentIndex] = false;
            currentSum -= values[currentIndex];
            SubsetSum(values, target, currentSum, currentIndex + 1, solution, indicesInSolution);
        }
    }
}