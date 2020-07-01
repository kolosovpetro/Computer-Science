using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Interfaces;

namespace EulerianPath
{
    public class EulerianPathBuilder
    {
        private readonly IGraph _graph;

        public EulerianPathBuilder(IGraph graph)
        {
            _graph = graph;
        }

        // make sure graph has either 0 or 2 odd vertices
        public int OddVerticesNumber()
        {
            return _graph.Vertices.Count(x => x.Degree % 2 == 1);
        }

        public bool GraphIsValid()
        {
            return OddVerticesNumber() == 0 || OddVerticesNumber() == 2;
        }

        public bool IsBridge(IEdge edge)
        {
            var last = edge.Last;
            return _graph.Edges.All(x => !x.First.Equals(last));
        }

        public IEdge GetStartEdge()
        {
            if (OddVerticesNumber() == 0)
            {
                return _graph.Edges.FirstOrDefault();
            }

            if (OddVerticesNumber() == 2)
            {
                return _graph.Edges
                    .FirstOrDefault(x => x.First.Degree % 2 == 1);
            }

            throw new Exception("Graph must have 0 or 2 odd vertices");
        }

        public IEnumerable<IEdge> NeighborEdges(INode node)
        {
            return _graph.Edges
                .Where(x => x.First.Equals(node));
        }

        public bool HasEulerianPath()
        {
            // check if graph meets conditions
            if (!GraphIsValid())
            {
                return false;
            }

            // get first edge
            var currentEdge = GetStartEdge();

            // go over graph
            while (true)
            {
                // get start neighboring edges
                var neighbors = NeighborEdges(currentEdge?.First).ToList();

                // check
                if (!neighbors.Any() && _graph.Edges.Count(x => !x.Visited) > 0)
                {
                    return false;
                }

                // mark current as visited
                if (currentEdge != null)
                {
                    currentEdge.Visited = true;

                    // choose next current edge from neighbors
                    // avoid bridges
                    switch (neighbors.All(IsBridge))
                    {
                        case true:
                            currentEdge = neighbors.FirstOrDefault();
                            break;
                        default:
                            currentEdge = neighbors.FirstOrDefault(x => !IsBridge(x));
                            break;
                    }
                }

                if (_graph.Edges.Any(x => !x.Visited))
                {
                    break;
                }
            }

            return true;
        }
    }
}