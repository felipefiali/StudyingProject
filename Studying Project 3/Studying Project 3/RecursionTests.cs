using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using StudyingProject3.Recursion;

namespace Tests
{
    [TestClass]
    public class RecursionTests
    {
        [TestMethod]
        public void CutRod()
        {
            var prices = new int[] { 1, 5, 8, 8, 10, 17, 17, 20, 24, 30 };

            Assert.AreEqual(10, Recursion.CutRod(prices, 4));
        }

        [TestMethod]
        public void SubsetSum()
        {
            var values = new int[] { 1, 5, 5, 9, 3 };

            Assert.AreEqual(2, Recursion.SubsetSum(values, 12));
        }
    }
}