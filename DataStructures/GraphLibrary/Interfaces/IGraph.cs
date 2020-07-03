using System.Collections.Generic;

namespace GraphLibrary.Interfaces
{
    public interface IGraph
    {
        // list of all edges
        IEnumerable<IEdge> Edges { get; }
        
        // list of all vertices
        IEnumerable<INode> Vertices { get; }

        // checks if all nodes of graph are visited
        bool IsTraversed();
        
        // reset all nodes - make em' unvisited
        void Reset();
        
        // set vertices
        void SetVertices();
    }
}