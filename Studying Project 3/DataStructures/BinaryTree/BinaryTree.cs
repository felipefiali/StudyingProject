using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProject3.BinaryTree
{
    public class BinaryTree
    {
        public static bool IsTreeBalanced(Node root)
        {
            if (CheckHeight(root) == -1)
            {
                return false;
            }

            return true;
        }

        public static int GetLargestSmallerKey(Node root, int key)
        {
            if (root == null)
            {
                return 0;
            }

            var currentLargest = 0;

            var queue = new Queue<Node>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Value < key)
                {
                    if (node.Value > currentLargest)
                    {
                        currentLargest = node.Value;
                    }
                }

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            return currentLargest;
        }

        public static int GetLargestSmallerKeyBST(Node root, int key)
        {
            var result = 0;

            while (root != null)
            {
                if (root.Value < key)
                {
                    result = root.Value;
                    root = root.Right;
                }
                else
                {
                    root = root.Left;
                }
            }

            return result;
        }

        public static Node GetBinaryTreeFromArray(int[] array)
        {
            if (array == null)
            {
                return null;
            }

            return  GetBinaryTreeFromArray(array, 0, array.Length - 1);
        }

        public static List<List<Node>> GetListForEachDepth(Node root)
        {
            if (root == null)
            {
                return new List<List<Node>>();
            }

            var rootList = new List<Node> { root };

            var list = new List<List<Node>>();
            list.Add(rootList);

            var queue = new Queue<List<Node>>();

            queue.Enqueue(rootList);

            while (queue.Count > 0)
            {
                var nodeList = queue.Dequeue();

                var newList = new List<Node>();

                foreach (var node in nodeList)
                {
                    if (node.Left != null)
                    {
                        newList.Add(node.Left);
                    }

                    if (node.Right != null)
                    {
                        newList.Add(node.Right);
                    }
                }

                if (newList.Count > 0)
                {
                    queue.Enqueue(newList);

                    list.Add(newList);

                }
            }

            return list;
        }

        public static bool IsBinarySearchTree(Node root)
        {
            if (root == null)
            {
                return false;
            }
            
            return IsBinarySearchTree(root, -1, 9999);
        }

        public static Node GetInOrderSucessor(Node root, int nodeValue)
        {
            if (root == null)
            {
                return null;
            }

            Node result = null;

            var current = root;

            while (current != null)
            {
                if (current.Value > nodeValue)
                {
                    result = current;
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return result;
        }

        public static Node FindFirstCommonAncestor(Node root, int node1, int node2)
        {
            Node result = null;

            if (root.Left != null)
            {
                result = FindFirstCommonAncestor(root.Left, node1, node2);
            }

            if (result == null && root.Right != null)
            {
                result = FindFirstCommonAncestor(root.Right, node1, node2);
            }

            if (result == null && IsNodeInTree(root, node1) && IsNodeInTree(root, node2))
            {
                result = root;
            }

            return result;
        }

        public static bool IsSubTreeOfTree(Node parent, Node subTree)
        {
            if (subTree == null)
            {
                return true;
            }

            return IsSubTree(parent, subTree);
        }

        private static bool IsSubTree(Node parent, Node subTree)
        {
            if (parent == null)
            {
                return false;
            }

            if (parent.Value == subTree.Value)
            {
                if (MatchTree(parent, subTree))
                {
                    return true;
                }
            }

            return IsSubTree(parent.Left, subTree) || IsSubTree(parent.Right, subTree);
        }

        private static bool MatchTree(Node parent, Node subTree)
        {
            if (parent == null && subTree == null)
            {
                return true;
            }

            if (parent == null)
            {
                return false;
            }

            if (subTree == null)
            {
                return true;
            }

            if (parent.Value == subTree.Value)
            {
                return MatchTree(parent.Left, subTree.Left) && MatchTree(parent.Right, subTree.Right);
            }
            else
            {
                return false;
            }
        }

        private static bool IsNodeInTree(Node root, int node)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Value == node)
            {
                return true;
            }

            return IsNodeInTree(root.Left, node) || IsNodeInTree(root.Right, node);
        }

        private static bool IsBinarySearchTree(Node root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }

            if (root.Value < min || root.Value > max)
            {
                return false;
            }

            return IsBinarySearchTree(root.Left, min, root.Value) && IsBinarySearchTree(root.Right, root.Value, max);
            
        }

        private static Node GetBinaryTreeFromArray(int[] array, int start, int end)
        {
            if (start == end)
            {
                return new Node(array[start]);
            }

            var middle = (start + end) / 2;

            var root = new Node(array[middle]);

            root.Left = GetBinaryTreeFromArray(array, start, middle - 1);
            root.Right = GetBinaryTreeFromArray(array, middle + 1, end);

            return root;
        }

        private static int CheckHeight(Node root)
        {
            int leftTreeHeight = 0, rightTreeHeight = 0;

            if (root == null)
            {
                return 0;
            }

            if (root.Left != null)
            {
                leftTreeHeight = CheckHeight(root.Left);

                if (leftTreeHeight == -1)
                {
                    return -1;
                }
            }

            if (root.Right != null)
            {
                rightTreeHeight = CheckHeight(root.Right);

                if (rightTreeHeight == -1)
                {
                    return -1;
                }
            }

            if (Math.Abs(rightTreeHeight - leftTreeHeight) > 1)
            {
                return -1;
            }

            return Math.Max(rightTreeHeight, leftTreeHeight) + 1; 
        }
    }
}