using System.Collections.Generic;
using System.Linq;
using DijkstraAlgorithm.Interfaces;
using DijkstraAlgorithm.Models;

namespace DijkstraAlgorithm.Dijkstra
{
    public class DijkstraMethod
    {
        private readonly IGraph _graph;

        public List<INode> VisitedNodes { get; private set; }
        public List<INode> UnvisitedNodes { get; private set; }
        public List<TableModel> DistancesList { get; private set; }

        public DijkstraMethod(IGraph graph)
        {
            _graph = graph;
        }

        public void UpdateUnvisitedNodes()
        {
            UnvisitedNodes = new List<INode>();

            foreach (var edge in _graph.Edges)
            {
                if (!edge.StartVertex.IsVisited && !UnvisitedNodes.Contains(edge.StartVertex))
                {
                    UnvisitedNodes.Add(edge.StartVertex);
                }

                if (!edge.EndVertex.IsVisited && !UnvisitedNodes.Contains(edge.EndVertex))
                {
                    UnvisitedNodes.Add(edge.EndVertex);
                }
            }
        }

        public void UpdateVisitedNodes()
        {
            VisitedNodes = new List<INode>();

            foreach (var edge in _graph.Edges)
            {
                if (edge.StartVertex.IsVisited && !VisitedNodes.Contains(edge.StartVertex))
                {
                    VisitedNodes.Add(edge.StartVertex);
                }

                if (edge.EndVertex.IsVisited && !VisitedNodes.Contains(edge.EndVertex))
                {
                    VisitedNodes.Add(edge.EndVertex);
                }
            }
        }

        /// <summary>
        /// Returns enumerable of all edges that starts from current node and unvisited
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<IEdge> NeighborEdges(INode node)
        {
            var neighbors = _graph.Edges
                .Where(x => x.StartVertex.Equals(node) && !x.EndVertex.IsVisited);

            return neighbors;
        }
        
        /// <summary>
        /// Implementation of Dijkstra algorithm. Builds shortest path to each of the nodes from start node.
        /// </summary>
        /// <param name="startNode">INode, start node</param>
        public void BuildShortPathTable(INode startNode)
        {
            // define start node
            var currentNode = startNode;

            // reset table of shortest patches
            DistancesList = new List<TableModel>();

            // reset visited nodes
            UpdateVisitedNodes();

            // reset unvisited nodes
            UpdateUnvisitedNodes();

            // current length
            var length = 0;

            while (UnvisitedNodes.Any())
            {
                // mark current node as visited
                currentNode?.Visit();

                // get neighbor edges of current node
                var neighborEdges = NeighborEdges(currentNode).ToList();

                if (!neighborEdges.Any())
                {
                    break;
                }

                // update distanceList
                foreach (var edge in neighborEdges)
                {
                    // if not present any T such that T.current == edge.Last - ADD
                    var model = DistancesList
                        .FirstOrDefault(x => x.CurrentNode.Equals(edge.EndVertex));

                    if (model == null)
                    {
                        DistancesList.Add(new TableModel
                        {
                            CurrentNode = edge.EndVertex,
                            Distance = length + edge.Weight,
                            PreviousNode = currentNode
                        });

                        continue;
                    }

                    // if present BUT T.Distance > length + edge.Distance - UPDATE
                    if (model.Distance > length + edge.Weight)
                    {
                        var index = DistancesList.IndexOf(model);
                        DistancesList[index].Distance = length + edge.Weight;
                        DistancesList[index].PreviousNode = currentNode;
                    }
                }

                // get min weight edge in neighbors
                var min = neighborEdges.Min(x => x.Weight);
                var minEdge = neighborEdges.FirstOrDefault(x => x.Weight == min);

                // assign new current node
                currentNode = minEdge?.EndVertex;

                // update length
                if (minEdge != null)
                    length += minEdge.Weight;

                // update visited nodes
                UpdateVisitedNodes();

                // update unvisited nodes
                UpdateUnvisitedNodes();
            }
        }
    }
}