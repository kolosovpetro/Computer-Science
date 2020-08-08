using System.Collections.Generic;

namespace DijkstraAlgorithm.Interfaces
{
    public interface IGraph
    {
        IEnumerable<IEdge> Edges { get; }
    }
}