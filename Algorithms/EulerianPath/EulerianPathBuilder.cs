using System;
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
        
        
    }
}