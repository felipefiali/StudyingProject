using StudyingProject3.Extensions;
using System.Collections.Generic;

namespace StudyingProject3.DynamicProgramming
{
    public static class DynamicProgramming
    {
        public static int FibonacciTopDown(int n)
        {
            var results = new int[n + 1];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = -1;
            }

            return FibonacciTopDown(n, results);
        }

        public static int FibonacciBottomUp(int n)
        {
            var results = new int[n + 1];

            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            results[0] = 0;
            results[1] = 1;

            for (int i = 2; i < results.Length; i++)
            {
                results[i] = results[i - 1] + results[i - 2];
            }

            return results[n];
        }

        public static int CutRodMemoized(int[] prices, int n)
        {
            if (n == 0)
            {
                return 0;
            }

            var results = new int[n + 1];

            return CutRodMemoized(prices, n, results);
        }

        public static int CutRodBottomUp(int[] prices, int n)
        {
            var results = new int[n + 1];

            results[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                var maxValue = 0;

                for (int j = 0; j < i; j++)
                {
                    maxValue = IntExtensions.Max(maxValue, prices[j] + results[i - j - 1]);
                }

                results[i] = maxValue;
            }

            return results[n];
        }

        private static int CutRodMemoized(int[] prices, int n, int[] results)
        {
            if (n == 0)
            {
                return 0;
            }

            if (results[n] > 0)
            {
                return results[n];
            }

            int maxValue = 0;

            for (int i = 0; i < n; i++)
            {
                maxValue = IntExtensions.Max(maxValue, prices[i] + CutRodMemoized(prices, n - i - 1, results));
            }

            results[n] = maxValue;

            return maxValue;
        }

        private static int FibonacciTopDown(int n, int[] results)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }
            
            if (results[n] != -1)
            {
                return results[n];
            }   
                    
            results[n] = FibonacciTopDown(n - 1, results) + FibonacciTopDown(n - 2, results);

            return results[n];
        }
    }
}