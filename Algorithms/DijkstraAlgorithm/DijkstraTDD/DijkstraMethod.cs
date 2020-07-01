using System.Collections.Generic;
using System.Linq;
using DijkstraAlgorithm.Interfaces;
using DijkstraAlgorithm.Models;

namespace DijkstraAlgorithm.DijkstraTDD
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
                if (!edge.First.IsVisited && !UnvisitedNodes.Contains(edge.First))
                {
                    UnvisitedNodes.Add(edge.First);
                }

                if (!edge.Last.IsVisited && !UnvisitedNodes.Contains(edge.Last))
                {
                    UnvisitedNodes.Add(edge.Last);
                }
            }
        }

        public void UpdateVisitedNodes()
        {
            VisitedNodes = new List<INode>();

            foreach (var edge in _graph.Edges)
            {
                if (edge.First.IsVisited && !VisitedNodes.Contains(edge.First))
                {
                    VisitedNodes.Add(edge.First);
                }

                if (edge.Last.IsVisited && !VisitedNodes.Contains(edge.Last))
                {
                    VisitedNodes.Add(edge.Last);
                }
            }
        }

        public IEnumerable<IEdge> NeighborEdges(INode node)
        {
            // get neighbors of node such that all not visited
            var neighbors = _graph.Edges
                .Where(x => x.First.Equals(node) && !x.Last.IsVisited);

            return neighbors;
        }

        public void BuildShortPathTable()
        {
            // define start node
            var currentNode = _graph.Edges.ElementAt(0).First;

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
                        .FirstOrDefault(x => x.CurrentNode.Equals(edge.Last));

                    if (model == null)
                    {
                        DistancesList.Add(new TableModel()
                        {
                            CurrentNode = edge.Last,
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
                currentNode = minEdge?.Last;

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