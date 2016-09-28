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