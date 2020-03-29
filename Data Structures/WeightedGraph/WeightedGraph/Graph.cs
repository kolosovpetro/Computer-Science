using System.Collections.Generic;
using WeightedGraphNodes.Exceptions;
using WeightedGraphNodes.Interfaces;

namespace WeightedGraphNodes.WeightedGraph
{
    internal class Graph<T> : IGraph<T>
    {
        public List<INode<T>> Nodes { get; }

        public List<IEdge<T>> Edges { get; }

        public int Count { get; private set; }

        public Graph()
        {
            Nodes = new List<INode<T>>();
            Edges = new List<IEdge<T>>();
        }

        public void AddEdge(T parentNodeData, T childNodeData, double weight)
        {
            if (!ContainsNode(parentNodeData, out int parentIndex) || !ContainsNode(childNodeData, out int childIndex))
                throw new NodeNotExistException("There are one or more nodes missing in graph.");

            var newEdge = new Edge<T>(Nodes[parentIndex], Nodes[childIndex], weight);
            Edges.Add(newEdge);
        }

        public void AddNode(T newNodeData)
        {

            INode<T> newNode = new Node<T>(newNodeData);
            Nodes.Add(newNode);
            Count++;
        }

        public bool AreConnected(T parentNodeData, T childNodeData)
        {
            if (ContainsNode(parentNodeData, out int parentIndex) 
                && ContainsNode(childNodeData, out int childIndex))
            {
                return Nodes[parentIndex].Next.Contains(Nodes[childIndex]);
            }

            return false;
        }

        public bool AreConnected(T parentNodeData, T childNodeData, out int edgeIndex)
        {
            edgeIndex = -1;

            for (int i = 0; i < Edges.Count; i++)
            {
                if (!Edges[i].Parent.Equals(parentNodeData) || !Edges[i].Child.Equals(childNodeData)) 
                    continue;

                edgeIndex = i;
                return true;
            }

            return false;
        }

        public bool ContainsNode(T nodeData)
        {
            for (int i = 0; i < Count; i++)
            {
                if (!Nodes[i].Data.Equals(nodeData)) 
                    continue;

                return true;
            }

            return false;
        }

        public bool ContainsNode(T nodeData, out int nodeIndex)
        {
            nodeIndex = -1;

            for (int i = 0; i < Count; i++)
            {
                if (!Nodes[i].Data.Equals(nodeData)) continue;
                nodeIndex = i;
                return true;
            }

            return false;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void RemoveNode(T nodeData)
        {
            if (ContainsNode(nodeData, out int nodeIndex))
            {
                Nodes.RemoveAt(nodeIndex);
                Count--;

                for (int i = 0; i < Count; i++)   // remove all links from other nodes to the removed one
                {
                    for (int j = 0; i < Nodes[i].Next.Count; i++)
                    {
                        if (Nodes[i].Next[j].Data.Equals(nodeData))
                        {
                            Nodes[i].Next.RemoveAt(j);
                        }
                    }
                }

                for (int i = 0; i < Edges.Count; i++)  // remove all edges that refers to removed one node
                {
                    if (Edges[i].Parent.Equals(nodeData) || Edges[i].Child.Equals(nodeData))
                    {
                        Edges.RemoveAt(i);
                    }
                }
            }

            else throw new NodeNotExistException("No such node in a graph.");
        }

        public bool ContainsEdge(T parentNodeData, T childNodeData)
        {
            foreach (var edge in Edges)
            {
                if (edge.Parent.Data.Equals(parentNodeData) 
                    && edge.Child.Data.Equals(childNodeData))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
