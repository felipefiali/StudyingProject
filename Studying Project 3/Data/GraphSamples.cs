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
    }
}
