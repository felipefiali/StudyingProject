using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyingProject3.Graph;

namespace Data
{
    public static class GraphSamples
    {
        public static Node DirectedGraph()
        {
            var root = new Node()
            {
                Value = 1,
                Adjacents = new List<Node>()
                {
                    new Node()
                    {
                        Value = 2,
                        Adjacents = new List<Node>()
                        {
                            new Node() 
                            {
                                Value = 11
                            }
                        }
                    },
                    new Node()
                    {
                        Value = 4,
                        Adjacents = new List<Node>()
                        {
                            new Node()
                            {
                                Value = 5
                            },
                            new Node()
                            {
                                Value = 6
                            }
                        }
                    }
                }
            };

            return root;
        }

        public static Node DirectedWeightedGraph()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);

            node1.Edges.Add(new Edge(10, node2));
            node1.Edges.Add(new Edge(3, node3));

            node2.Edges.Add(new Edge(1, node3));
            node2.Edges.Add(new Edge(2, node4));

            node3.Edges.Add(new Edge(4, node2));
            node3.Edges.Add(new Edge(8, node4));
            node3.Edges.Add(new Edge(2, node5));
            
            node4.Edges.Add(new Edge(7, node5));

            node5.Edges.Add(new Edge(9, node4));

            return node1;            
        }
    }
}