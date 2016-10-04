using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyingProject3.DynamicProgramming;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class DynamicProgrammingTests
    {
        [TestMethod]
        public void FibonacciTopDown()
        {
            Assert.AreEqual(0, DynamicProgramming.FibonacciTopDown(0));
            Assert.AreEqual(1, DynamicProgramming.FibonacciTopDown(1));
            Assert.AreEqual(55, DynamicProgramming.FibonacciTopDown(10));
        }

        [TestMethod]
        public void FibonacciBottomUp()
        {
            Assert.AreEqual(0, DynamicProgramming.FibonacciBottomUp(0));
            Assert.AreEqual(1, DynamicProgramming.FibonacciBottomUp(1));
            Assert.AreEqual(55, DynamicProgramming.FibonacciBottomUp(10));
        }

        [TestMethod]
        public void CutRodMemoized()
        {
            var prices = new int[] { 1, 5, 8, 8, 10, 17, 17, 20, 24, 30 };

            Assert.AreEqual(10, DynamicProgramming.CutRodMemoized(prices, 4));
        }

        [TestMethod]
        public void CutRodBottomUp()
        {
            var prices = new int[] { 1, 5, 8, 8, 10, 17, 17, 20, 24, 30 };

            Assert.AreEqual(10, DynamicProgramming.CutRodBottomUp(prices, 4));
        }

        [TestMethod]
        public void IsSubsetSum()
        {
            var values = new int[] { 1, 3, 9, 2 };
            var target = 5;

            Assert.IsTrue(DynamicProgramming.CanSubsetSum(values, target));
        }

        [TestMethod]
        public void LongestCommonSubsequence()
        {
            var a = "dakota";
            var b = "aquota";

            Assert.AreEqual(4, DynamicProgramming.LongestCommonSubsequence(a, b));
        }

        [TestMethod]
        public void Knapsack()
        {
            var values = new int[] { 5, 10, 2, 8, 1 };
            var weights = new int[] { 3, 6, 2, 4, 1 };
            var max = 7;

            Assert.AreEqual(13, DynamicProgramming.Knapsack(values, weights, max));
        }

        [TestMethod]
        public void GetKnapsackItems()
        {
            var values = new int[] { 5, 10, 2, 8, 1 };
            var weights = new int[] { 3, 6, 2, 4, 1 };
            var max = 7;

            var expected = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(8, 4),
                new Tuple<int, int>(5, 3)
            };

            var actual = DynamicProgramming.GetKnapSackItems(values, weights, max);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[0].Item1, actual[0].Item1);
                Assert.AreEqual(expected[0].Item2, actual[0].Item2);
            }
        }
    }
}