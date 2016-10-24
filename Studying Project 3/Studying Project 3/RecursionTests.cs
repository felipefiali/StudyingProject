using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using StudyingProject3.Recursion;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

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

        [TestMethod]
        public void GetPermutations()
        {
            var perms = new HashSet<string>() { "ABC", "ACB", "BAC", "BCA", "CAB", "CBA" };

            CollectionAssert.AreEquivalent(perms.ToList(), Recursion.GetPermutations("ABC").ToList());
        }

        [TestMethod]
        public void FlattenDictionaries()
        {
            var nestedDictionaries = new Dictionary<string, object>
            {
                { "Key1", "Value1" },
                { "Key2", "Value2" },
                { "Key3", new Dictionary<string, object> 
                {
                    { "a", "1" },
                    { "b", new Dictionary<string, object> 
                    {
                        { "c1", "c1" },
                        { "c2", "c2" },
                        { "c3", "c3" }
                    }},
                }},
            };

            var expected = new Dictionary<string, string>
            {
                { "Key1", "Value1" },
                { "Key2", "Value2" },
                { "Key3.a", "1" },
                { "Key3.b.c1", "c1" },
                { "Key3.b.c2", "c2" },
                { "Key3.b.c3", "c3" },
            };

            CollectionAssert.AreEqual(expected, Recursion.FlattenDictionaries(nestedDictionaries));
        }

        [TestMethod]
        public void GetWaysToReachNum()
        {
            Assert.AreEqual(4, Recursion.GetWaysToReachNum(3));
        }

        [TestMethod]
        public void GetMagicIndex()
        {
            var array = new int[] { -10, -5, 2, 2, 2, 3, 4, 7, 9, 12, 13 };

            Assert.AreEqual(2, Recursion.GetMagicIndex(array));
        }

        [TestMethod]
        public void GetAllSubsetsOfSet()
        {
            var array = new int[] { 1, 2 };

            var expected = new List<List<int>>()
            {
                new List<int> {  },
                new List<int> { 2 },
                new List<int> { 1 },
                new List<int> { 1, 2 }                
            };

            var actual = Recursion.GetAllSubsetsOfSet(array);

            for (int i = 0; i < expected.Count; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void CanThreeNumbersSumToTarget()
        {
            var array = new int[] { 1, 2, 5, 6, 10, 5, -1 };
            Assert.AreEqual(true, Recursion.CanReachSumWith3Nums(array, 9), "9");
            
            Assert.AreEqual(true, Recursion.CanReachSumWith3Nums(array, -3), "-3");

            Assert.AreEqual(true, Recursion.CanReachSumWith3Nums(array, 5), "5");
            
            Assert.AreEqual(true, Recursion.CanReachSumWith3Nums(array, 21), "21");
            
            Assert.AreEqual(true, Recursion.CanReachSumWith3Nums(array, 30), "30");

            Assert.AreEqual(false, Recursion.CanReachSumWith3Nums(array, 99), "99");

            array = new int[] { 1, 2, 5, 6, 10, -1 };
            Assert.AreEqual(true, Recursion.CanReachSumWith3Nums(array, 20), "20");
        }
    }
}