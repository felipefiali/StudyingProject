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
                Value = 300,
                Left = new Node()
                {
                    Value = 80,
                    Left = new Node()
                    {
                        Value = 10
                    },
                    Right = new Node()
                    {
                        Value = 15,
                        Left = new Node()
                        {
                            Value = 101
                        },
                        Right = new Node()
                        {
                            Value = 100
                        }
                    }
                },
                Right = new Node()
                {
                    Value = 40,
                    Left = new Node()
                    {
                        Value = 55
                    },
                    Right = new Node()
                    {
                        Value = 66,
                        Left = new Node()
                        {
                            Value = 57
                        },
                        Right = new Node()
                        {
                            Value = 70
                        }
                    }
                }
            };

            return root;
        }


        public static Node BalancedBST()
        {
            var root = new Node()
            {
                Value = 25,
                Left = new Node()
                {
                    Value = 20,
                    Left = new Node()
                    {
                        Value = 15
                    },
                    Right = new Node()
                    {
                        Value = 22
                    }
                },
                Right = new Node()
                {
                    Value = 30,
                    Left = new Node()
                    {
                        Value = 26
                    },
                    Right = new Node()
                    {
                        Value = 35
                    }
                }
            };

            return root;
        }
    }
}