using StudyingProject3.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

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

            var table = ConstructSubsetSumTable(values, target);

            return table[values.Length, target];
        }

        public static List<int> GetSubsetSum(int[] values, int target)
        {
            var table = ConstructSubsetSumTable(values, target);

            var row = values.Length;
            var col = target;

            var numbersUsed = new List<int>();

            if (!table[row, col])
            {
                return numbersUsed;
            }

            while (row > 0)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    numbersUsed.Add(values[row - 1]);

                    col = col - values[row - 1];
                }

                row--;
            }

            return numbersUsed;
        }
        
        public static int GetLongestCommonSubsequenceSize(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return 0;
            }

            return ConstructLongestCommonSubsequenceTable(a, b)[a.Length, b.Length];
        }

        public static char[] GetLongestCommonSubsequence(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return string.Empty.ToCharArray();
            }

            var charList = new List<char>();

            var table = ConstructLongestCommonSubsequenceTable(a, b);

            int row = a.Length, col = b.Length;

            while (row > 0 && col > 0)
            {
                if (table[row, col] != table[row - 1, col] && table[row, col] != table[row, col - 1])
                {
                    charList.Add(a[row - 1]);

                    row--;
                    col--;
                }
                else if (table[row, col] == table[row - 1, col])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            charList.Reverse();

            return charList.ToArray();
        }

        private static int[,] ConstructLongestCommonSubsequenceTable(string a, string b)
        {
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
                        table[row, col] = IntExtensions.Max(table[row, col - 1], table[row - 1, col]);
                    }
                }
            }

            return table;
        }

        public static int Knapsack(int[] values, int[] weights, int max)
        {
            if (values.Length != weights.Length)
            {
                return 0;
            }

            var table = ConstructKnapsackTable(values, weights, max);

            return table[values.Length, max];
        }

        public static List<Tuple<int, int>> GetKnapSackItems(int[] values, int[] weights, int max)
        {
            if (values.Length != weights.Length)
            {
                return new List<Tuple<int, int>>();
            }

            var itemsUsed = new List<Tuple<int, int>>();

            var table = ConstructKnapsackTable(values, weights, max);

            int row = values.Length;

            int col = max;

            while (table[row, col] != 0)
            {
                if (table[row, col] == table[row - 1, col])
                {
                    row--;
                }
                else
                {
                    itemsUsed.Add(new Tuple<int, int>(values[row - 1], weights[row - 1]));

                    col = col - weights[row - 1];
                    row--;
                }
            }

            return itemsUsed;
        }

        public static int GetWaysToReachNum(int value)
        {
            var map = new int[value + 1];

            for (int i = 0; i <= value; i++)
            {
                map[i] = -1;                
            }

            return GetWaysToReachSumMemoized(value, map);
        }

        private static bool[,] ConstructSubsetSumTable(int[] values, int target)
        {
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

            return table;
        }

        private static int GetWaysToReachSumMemoized(int value, int[] map)
        {
            if (value == 0)
            {
                return 1;
            }

            if (value < 0)
            {
                return 0;
            }

            if (map[value] > -1)
            {
                return map[value];
            }

            map[value] = GetWaysToReachSumMemoized(value - 1, map) +
                         GetWaysToReachSumMemoized(value - 2, map) +
                         GetWaysToReachSumMemoized(value - 3, map);

            return map[value];
        }

        private static int[,] ConstructKnapsackTable(int[] values, int[] weights, int max)
        {
            var table = new int[values.Length + 1, max + 1];

            for (int i = 0; i <= values.Length; i++)
            {
                table[i, 0] = 0;
            }

            for (int i = 0; i <= max; i++)
            {
                table[0, i] = 0;
            }

            for (int row = 1; row <= values.Length; row++)
            {
                for (int col = 1; col <= max; col++)
                {
                    if (weights[row - 1] > col)
                    {
                        table[row, col] = table[row - 1, col];
                    }
                    else
                    {
                        table[row, col] = Math.Max(values[row - 1] + table[row - 1, col - weights[row - 1]], table[row - 1, col]);
                    }
                }
            }

            return table;
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