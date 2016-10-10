using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyingProject3.Arrays;

namespace Tests
{

    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void JoinTwoOrderedArrays()
        {
            var array1 = new int[] { 1, 2, 3, 4, 5, 6 };
            var array2 = new int[] { 1, 2, 3, 4, 5, 6 };

            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 }, Arrays.JoinOrderedArrays(array1, array2));

            array1 = new int[] { 1, 2, 99 };
            array2 = new int[] { -1, -3 };

            CollectionAssert.AreEqual(new int[] { -1, -3, 1, 2, 99 }, Arrays.JoinOrderedArrays(array1, array2));
        }

        [TestMethod]
        public void RemoveDuplicatesAndGetResult()
        {
            var array = new int[] { 1, 1, 1, 2, 2, 2, 3, 4, 5, 6, 6, 7 };

            Assert.AreEqual(7, Arrays.RemoveDuplicatesFromArray(array));

            Arrays.RemoveDuplicatesFromArray(array);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0 }, array);
        }

        [TestMethod]
        public void LookAndSay()
        {
            var array = new int[] { 1, 2, 1, 1 };

            CollectionAssert.AreEqual(array, Arrays.LookAndSaySequence(3));
        }

        [TestMethod]
        public void CompactArray()
        {
            var array = new int[] { 1, 1, 1, 1, 2, 3, 3, 3, 4, 4 };

            CollectionAssert.AreEqual(new int[] { 4, 1, 1, 2, 3, 3, 2, 4, 0, 0 }, Arrays.CompactArray(array));
        }

        [TestMethod]
        public void MakeRowAndColZero()
        {
            var matrix = new int[,]
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 0, 1 },
                { 0, 1, 1, 1 }
            };

            var expected = new int[,]
            {
                { 0, 1, 0, 1 },
                { 0, 1, 0, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };

            Arrays.MakeRowAndColumnZero(matrix, 4);

            CollectionAssert.AreEqual(expected, matrix);
        }
    }
}