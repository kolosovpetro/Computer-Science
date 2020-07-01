using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DijkstraAlgorithm.Interfaces;
using NUnit.Framework;

namespace DijkstraAlgorithm.Implementations
{
    public class Graph : IGraph
    {
        public IEnumerable<IEdge> Edges { get; }

        public Graph(params IEdge[] edges)
        {
            Edges = edges;
        }

        public void Traversal()
        {
            var iterator = 0;

            while (iterator < Edges.Count())
            {
                // get current edge
                var currentEdge = Edges.ElementAt(iterator);

                // mark first node as visited
                currentEdge.First.Visit();

                // mark last node as visited
                currentEdge.Last.Visit();

                // increment iterator
                iterator++;
            }
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
    }
}