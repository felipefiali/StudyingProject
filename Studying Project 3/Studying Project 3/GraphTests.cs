using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using StudyingProject3.Graph;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Tests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void IsTherePathBetweenNodes()
        {
            var graph = GraphSamples.DirectedGraph();

            Assert.IsFalse(Graph.IsTherePathBetweenNodes(graph, new Node(99)));

            Assert.IsTrue(Graph.IsTherePathBetweenNodes(graph, new Node(6)));
        }
    }
}
