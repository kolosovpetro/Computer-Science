using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Interfaces;

namespace GraphLibrary.Implementations
{
    public class Graph : IGraph
    {
        public IEnumerable<IEdge> Edges { get; }
        public IEnumerable<INode> Vertices { get; private set; }

        public Graph(params IEdge[] edges)
        {
            Edges = edges;
            SetVertices();
        }

        public bool IsTraversed()
        {
            return Edges.All(edge => edge.First.IsVisited && edge.Last.IsVisited);
        }

        public void Reset()
        {
            foreach (var edge in Edges)
            {
                edge.First.Reset();
                edge.Last.Reset();
            }
        }

        public void SetVertices()
        {
            var vertices = new List<INode>();

            foreach (var edge in Edges)
            {
                if (!vertices.Contains(edge.First))
                {
                    vertices.Add(edge.First);
                }

                if (!vertices.Contains(edge.Last))
                {
                    vertices.Add(edge.Last);
                }
            }

            Vertices = vertices;
        }
    }
}