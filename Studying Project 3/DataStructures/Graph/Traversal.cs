using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProject3.Graph
{
    public class Traversal
    {
        public static void DepthFirstSearch(Node root)
        {
            if (root == null)
            {
                return;
            }

            foreach (var node in root.Adjacents)
            {
                if (!node.Visited)
                {
                    DepthFirstSearch(node);
                }
            }

            root.Visit();
        }

        public static void BreadthFirstSearch(Node root)
        {
            if (root == null)
            {
                return;
            }

            var queue = new Queue<Node>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var node in current.Adjacents)
                {
                    if (!node.Visited)
                    {
                        node.Visit();
                    }

                    queue.Enqueue(node);
                }                
            }
        }
    }
}
