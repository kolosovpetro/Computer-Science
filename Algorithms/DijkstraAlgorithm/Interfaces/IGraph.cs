using System.Collections.Generic;

namespace DijkstraAlgorithm.Interfaces
{
    public interface IGraph
    {
        IEnumerable<IEdge> Edges { get; }

        // suppose to make all Nodes in graph visited
        void Traversal();
        
        // checks if all nodes of graph are visited
        bool IsTraversed();
        
        // reset all nodes - make em' unvisited
        void Reset();
    }
}