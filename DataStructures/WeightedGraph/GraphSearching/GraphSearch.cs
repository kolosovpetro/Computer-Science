using WeightedGraphNodes.Interfaces;

namespace WeightedGraphNodes.GraphSearching
{
    internal class GraphSearch<T>
    {
        public IGraph<T> Graph { get; }

        public GraphSearch(IGraph<T> graph)
        {
            Graph = graph;
        }

        public bool Search(T searchData)
        {
            foreach (var node in Graph.Nodes)
            {

                foreach (var next in node.Next)
                {
                    if (next.Data.Equals(searchData))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
