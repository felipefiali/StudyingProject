using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProject3.Graph
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;

            Adjacents = new List<Node>();
        }

        public Node()
        {
            Adjacents = new List<Node>();
        }
       
        public int Value { get; set; }

        public List<Node> Adjacents{ get; set; }

        public bool Visited { get; set; }

        public void Visit()
        {
            Visited = true;

            Console.WriteLine(string.Format("Visited graph node {0}", Value));
        }
    }
}
