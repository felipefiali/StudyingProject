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
    }
}
