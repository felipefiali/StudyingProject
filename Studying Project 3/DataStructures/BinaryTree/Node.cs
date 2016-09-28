using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProject3.BinaryTree
{
    public class Node
    {
        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Value { get; set; }

        public void Visit()
        {
            Console.WriteLine(string.Format("Visited node {0}", Value));
        }
    }
}
