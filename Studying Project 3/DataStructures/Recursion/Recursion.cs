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
    }
}