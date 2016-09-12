using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProject3.LinkedList
{
    public static class LinkedLists
    {
        public static Node RemoveMultipleOfFour(LinkedList linkedList)
        {
            var current = linkedList.Head;
            var head = current;
            Node previous = null;
            
            while (current != null)
            {
                if (current.Value % 4 == 0)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }
                }
                else
                {
                    previous = current;
                }

                current = current.Next;
            }

            return head;
        }
    }
}
