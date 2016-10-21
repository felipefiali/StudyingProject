namespace StudyingProject3.Graph
{
    public class Edge
    {
        public Edge(int weight, Node node)
        {
            Weight = weight;
            Node = node;
        }

        public int Weight { get; set; }

        public Node Node { get; set; }
    }
}