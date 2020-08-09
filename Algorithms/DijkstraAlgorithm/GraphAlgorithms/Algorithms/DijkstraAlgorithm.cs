using System;
using System.Collections.Generic;
using System.Linq;
using GraphAlgorithms.Models;
using GraphLibrary.Interfaces;

namespace GraphAlgorithms.Algorithms
{
    public class DijkstraAlgorithm<T>
    {
        public List<DistanceModel<T>> DijkstraMethod(IGraph<T> graph, IVertex<T> startVertex)
        {
            if (!graph.ContainsVertex(startVertex))
                throw new InvalidOperationException("Vertex does not belong to graph");

            // fill initial line of shortest path table
            var distances = new List<DistanceModel<T>>
            {
                new DistanceModel<T>(startVertex, startVertex, 0)
            };

            // define unvisited vertices
            var unvisitedVertices = graph.Vertices.Select(x => x).ToList();

            // define current vertex
            var currentVertex = startVertex;

            // iterator should be incremented by the value of edge we visit
            var iterator = 0;

            while (unvisitedVertices.Any())
            {
                // visit current vertex
                currentVertex.Visit();

                // update unvisited vertices
                unvisitedVertices = unvisitedVertices.Where(x => !x.IsVisited).ToList();

                // get all edges which start from current vertex
                var currentUnvisitedEdges = graph.EdgesStartWithVertex(currentVertex)
                    .Where(x => !x.EndVertex.IsVisited)
                    .ToList();

                foreach (var edge in currentUnvisitedEdges)
                {
                    // if contains vertex and distance is greater - update
                    if (ContainsAndGreater(distances, edge.EndVertex, iterator + edge.Weight))
                    {
                        // update
                        var distanceModel = distances.First(x => x.Vertex.Equals(edge.EndVertex));
                        distanceModel.Distance = iterator + edge.Weight;
                        distanceModel.PreviousVertex = currentVertex;
                        continue;
                    }

                    // if doesn't contain - add new entry to distances
                    if (!Contains(distances, edge.EndVertex))
                    {
                        distances.Add(new DistanceModel<T>
                        {
                            Vertex = edge.EndVertex,
                            PreviousVertex = currentVertex,
                            Distance = iterator + edge.Weight,
                        });
                    }
                }

                if (!currentUnvisitedEdges.Any()) break;

                var minEdge = currentUnvisitedEdges
                    .First(x => x.Weight == currentUnvisitedEdges.Min(t => t.Weight));
                iterator += minEdge.Weight;
                currentVertex = minEdge.EndVertex;
            }

            return distances;
        }

        private static bool ContainsAndGreater(List<DistanceModel<T>> distances, IVertex<T> vertex, int value)
        {
            return distances.Any(x => x.Vertex.Equals(vertex) && x.Distance > value);
        }

        private static bool Contains(List<DistanceModel<T>> distances, IVertex<T> vertex)
        {
            return distances.Any(x => x.Vertex.Equals(vertex));
        }
    }
}