using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyingProject3.DynamicProgramming;

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
    }
}