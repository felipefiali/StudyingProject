using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using StudyingProject3.LinkedList;

namespace Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void RemoveMultipleOfFourFromList()
        {
            var sample = LinkedListSamples.WithMultiplesOfFour();

            var newListHead = LinkedLists.RemoveMultipleOfFour(sample);

            var current = newListHead;

            while (current != null)
            {
                Console.Write(current.Value + " > ");

                current = current.Next;
            }
        }
    }
}
