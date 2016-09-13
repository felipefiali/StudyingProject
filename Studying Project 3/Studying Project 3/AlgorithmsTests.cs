using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyingProject3.Algorithms;

namespace Tests
{
    [TestClass]
    public class AlgorithmsTests
    {
        [TestMethod]
        public void LRU()
        {
            var lruCache = new LRUCache(5);

            // Least Used
            lruCache.Set(1, 1);

            lruCache.Set(2, 2);
            lruCache.Set(3, 3);
            lruCache.Set(4, 4);
            lruCache.Set(5, 5);

            lruCache.Set(5, 10);
            lruCache.Set(4, 8);
            lruCache.Set(3, 6);
            lruCache.Set(2, 4);

            lruCache.Set(99, 99);

            Assert.AreEqual(-1, lruCache.Get(1));
        }
    }
}
