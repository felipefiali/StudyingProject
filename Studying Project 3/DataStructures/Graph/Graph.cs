using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProject3.Graph
{
    public static class Graph
    {
        public static bool IsTherePathBetweenNodes(Node source, Node destination)
        {
            if (source == null || destination == null)
            {
                return false;
            }

            if (source == destination)
            {
                return true;
            }

            var queue = new Queue<Node>();

            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var adjacent in current.Adjacents)
                {
                    if (destination.Value == adjacent.Value)
                    {
                        return true;
                    }

                    adjacent.Visit();

                    queue.Enqueue(adjacent);
                }
            }

            return false;
        }
    }
}
