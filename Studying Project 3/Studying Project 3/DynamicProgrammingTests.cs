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
    }
}
