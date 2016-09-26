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

        public static bool CanSubsetSum(int[] values, int target)
        {
            if (values.Length == 0)
            {
                return false;
            }
            
            var table = new bool[values.Length + 1, target + 1];

            for (int i = 1; i <= target; i++)
			{
                table[0, i] = false;			 
			}

            for (int i = 0; i <= values.Length; i++)
			{
                table[i, 0] = true;			 
			}

            for (int row = 1; row <= values.Length; row++)
            {
                for (int col = 1; col <= target; col++)
                {
                    table[row, col] = table[row - 1, col];

                    if (!table[row, col] && col >= values[row - 1])
                    {
                        table[row, col] = table[row, col] || table[row - 1, col - values[row - 1]];
                    }
                }
            }

            return table[values.Length, target];
        }

        public static int LongestCommonSubsequence(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return 0;
            }

            var table = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++)
            {
                table[i, 0] = 0;
            }

            for (int i = 0; i < b.Length; i++)
            {
                table[0, i] = 0;
            }

            for (int row = 1; row <= a.Length; row++)
            {
                for (int col = 1; col <= b.Length; col++)
                {
                    if (a[row - 1] == b[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        table[row, col] = IntExtensions.Max(table[row, col -1], table[row - 1, col]);
                    }
                }
            }

            return table[a.Length, b.Length];
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