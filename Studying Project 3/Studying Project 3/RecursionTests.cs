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
    }
}