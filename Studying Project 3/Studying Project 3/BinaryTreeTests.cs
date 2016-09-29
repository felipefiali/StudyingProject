using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using StudyingProject3.BinaryTree;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Tests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void IsEveryNodeBalanced()
        {
            Assert.IsFalse(BinaryTree.IsTreeBalanced(BinaryTreeSamples.UnbalancedTree()));

            Assert.IsTrue(BinaryTree.IsTreeBalanced(BinaryTreeSamples.BalancedTree()));
        }

        [TestMethod]
        public void GetLargestSmallerKey()
        {
            var key = 70;

            Assert.AreEqual(66, BinaryTree.GetLargestSmallerKey(BinaryTreeSamples.BalancedTree(), key));
        }

        [TestMethod]
        public void GetLargestSmallerKeyBST()
        {
            var key = 25;

            Assert.AreEqual(22, BinaryTree.GetLargestSmallerKeyBST(BinaryTreeSamples.BalancedBST(), key));
        }

        [TestMethod]
        public void GetBinaryTreeFromArray()
        {
            var array = new int[] { 15, 20, 22, 25, 26, 30, 35 };

            var root = BinaryTree.GetBinaryTreeFromArray(array);

            CollectionAssert.AreEqual(array.ToList(), root.ToIntegerList());
        }

        [TestMethod]
        public void GetListForEachDepth()
        {
            var expected = new List<List<Node>>()
            {
                new List<Node> { new Node(25) },
                new List<Node> { new Node(20), new Node(30) },
                new List<Node> { new Node(15), new Node(22), new Node(26), new Node(35) }                
            };

            var actual = BinaryTree.GetListForEachDepth(BinaryTreeSamples.BalancedBST());

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Count, actual[i].Count);
            }
        }

        [TestMethod]
        public void IsBinarySearchTree()
        {
            Assert.IsTrue(BinaryTree.IsBinarySearchTree(BinaryTreeSamples.BalancedBST()));
            Assert.IsFalse(BinaryTree.IsBinarySearchTree(BinaryTreeSamples.BalancedTree()));
        }
    }
}