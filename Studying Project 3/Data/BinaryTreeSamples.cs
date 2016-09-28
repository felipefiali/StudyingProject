using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyingProject3.BinaryTree;

namespace Data
{
    public class BinaryTreeSamples
    {
        public static Node UnbalancedTree()
        {
            var root = new Node()
            {
                Left = new Node()
                {
                    Left = new Node(),
                    Right = new Node()
                    {
                        Left = new Node()
                    }
                },
                Right = new Node()
            };

            return root;
        }

        public static Node BalancedTree()
        {
            var root = new Node()
            {
                Left = new Node()
                {
                    Left = new Node(),
                    Right = new Node()
                    {
                        Left = new Node(),
                        Right = new Node()
                    }
                },
                Right = new Node()
                {
                    Left = new Node(),
                    Right = new Node()
                    {
                        Left = new Node(),
                        Right = new Node()
                    }
                }
            };

            return root;
        }
    }
}
