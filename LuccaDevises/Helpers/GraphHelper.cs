using Dijkstra.NET.Graph;

namespace LuccaDevises.Helpers
{
    public static class GraphHelper
    {
        public static void FillGraph(Graph<int, string> graph, int nbNodes)
        {
            for (int i = 0; i < nbNodes; i++)
            {
                graph.AddNode(i + 1);
            }
        }

        public static void AddGraphLink(Graph<int, string> graph, uint nodeIndexFrom, uint nodeIndexTo)
        {
            // connect in both way as the graph is not oriented.
            graph.Connect(nodeIndexFrom, nodeIndexTo, 1, "");
            graph.Connect(nodeIndexTo, nodeIndexFrom, 1, "");
        }
    }
}
