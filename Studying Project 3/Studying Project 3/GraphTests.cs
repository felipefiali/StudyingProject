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

        [TestMethod]
        public void Dijkstra()
        {
            var actual = Graph.Dijkstra(GraphSamples.DirectedWeightedGraph());

            var expected = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 7 },
                { 3, 3 },
                { 4, 9 },
                { 5, 5 },
            };

            foreach (var item in actual)
            {
                Assert.AreEqual(expected[item.Key.Value], item.Value);
            }
        }
    }
}