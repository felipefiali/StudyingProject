using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProject3.BinaryTree
{
    public class Traversal
    {
        public static void InOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.Left);
            root.Visit();
            InOrder(root.Right);
        }

        public static void PreOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            root.Visit();
            PreOrder(root.Left);
            PreOrder(root.Right);
        }

        public static void PostOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            PostOrder(root.Left);
            PostOrder(root.Right);
            root.Visit();
        }

        public static void DepthFirstSearch(Node root)
        {
            InOrder(root);
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
                var node = queue.Dequeue();

                node.Visit();

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }
    }
}