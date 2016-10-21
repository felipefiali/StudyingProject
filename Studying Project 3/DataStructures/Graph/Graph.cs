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

        public static Dictionary<Node, int> Dijkstra(Node start)
        {
            var initializationQueue = new Queue<Node>();
            var unvisitedList = new List<Node>();
            var distances = new Dictionary<Node, int>();

            initializationQueue.Enqueue(start);
            unvisitedList.Add(start);

            while (initializationQueue.Count > 0)
            {
                var current = initializationQueue.Dequeue();

                foreach (var edge in current.Edges)
                {
                    if (edge.Node.Visited)
                    {
                        continue;
                    }

                    distances.Add(edge.Node, Int32.MaxValue);
                    unvisitedList.Add(edge.Node);
                    
                    initializationQueue.Enqueue(edge.Node);

                    edge.Node.Visit();
                }
            }

            distances[start] = 0;

            while (unvisitedList.Count > 0)
            {
                var minDistance = distances.Where(pair => unvisitedList.Contains(pair.Key))
                                           .OrderBy(pair => pair.Value).First().Key;

                // var minDistance = unvisitedList.OrderBy(node => distances[node]).First();

                unvisitedList.Remove(minDistance);

                foreach (var edge in minDistance.Edges)
                {
                    var curDistance = distances[minDistance] + edge.Weight;

                    if (curDistance < distances[edge.Node])
                    {
                        distances[edge.Node] = curDistance;                        
                    }
                }
            }

            return distances;
        }

    }
}
