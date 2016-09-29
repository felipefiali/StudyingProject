using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProject3.BinaryTree
{
    public class Node
    {
        public Node()
        {

        }

        public Node(int value)
        {
            Value = value;
        }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Value { get; set; }

        public void Visit()
        {
            Console.WriteLine(string.Format("Visited node {0}", Value));
        }

        public List<int> ToIntegerList()
        {
            return ToList(new List<int>(), this);
        }

        private List<int> ToList(List<int> list, Node node)
        {
            if (node.Left != null)
            {
                ToList(list, node.Left);
            }

            list.Add(node.Value);

            if (node.Right != null)
            {
                ToList(list, node.Right);
            }

            return list;
        }
    }
}
