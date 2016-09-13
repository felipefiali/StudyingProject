using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyingProject3.LinkedList;

namespace Data
{
    public static class LinkedListSamples
    {
        public static LinkedList WithMultiplesOfFour()
        {
            var linkedList = new LinkedList
            {
                Head = new Node
                {
                    Value = 4,
                    Next = new Node
                    {
                        Value = 4,
                        Next = new Node
                        {
                            Value = 7,
                            Next = new Node
                            {
                                Value = 1,
                                Next = new Node
                                {
                                    Value = 12,
                                    Next = new Node
                                    {
                                        Value = 100,
                                        Next = new Node
                                        {
                                            Value = 999,
                                            Next = null
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return linkedList;
        }
    }
}