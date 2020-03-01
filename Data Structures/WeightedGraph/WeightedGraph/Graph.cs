using System;
using System.Collections.Generic;
using WeightedGraphNodes.Interfaces;

namespace WeightedGraphNodes.WeightedGraph
{
    class Graph<T> : IGraph<T>
    {
        public List<INode<T>> Nodes { get; private set; }

        public List<IEdge<T>> Edges { get; private set; }

        public int Count { get; private set; }

        public Graph()
        {
            Nodes = new List<INode<T>>();
            Edges = new List<IEdge<T>>();
        }

        public void AddEdge(T ParentNodeData, T ChildNodeData, double Weight)
        {
            if (ContainsNode(ParentNodeData, out int ParentIndex) && ContainsNode(ChildNodeData, out int ChildIndex))
            {
                IEdge<T> NewEdge = new Edge<T>(Nodes[ParentIndex], Nodes[ChildIndex], Weight);
                Edges.Add(NewEdge);
                return;
            }

            throw new Exception(); // here to be custom exception
        }

        public void AddNode(T newNodeData)
        {

            INode<T> NewNode = new Node<T>(newNodeData);
            Nodes.Add(NewNode);
            Count++;
        }

        public bool AreConnected(T ParentNodeData, T ChildNodeData)
        {
            if (ContainsNode(ParentNodeData, out int ParentIndex) && ContainsNode(ChildNodeData, out int ChildIndex))
            {
                return Nodes[ParentIndex].Next.Contains(Nodes[ChildIndex]);
            }

            return false;
        }

        public bool AreConnected(T ParentNodeData, T ChildNodeData, out int EdgeIndex)
        {
            EdgeIndex = -1;

            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].Parent.Equals(ParentNodeData) && Edges[i].Child.Equals(ChildNodeData))
                {
                    EdgeIndex = i;
                    return true;
                }
            }

            return false;
        }

        public bool ContainsNode(T NodeData)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Nodes[i].Data.Equals(NodeData))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsNode(T NodeData, out int NodeIndex)
        {
            NodeIndex = -1;

            for (int i = 0; i < Count; i++)
            {
                if (Nodes[i].Data.Equals(NodeData))
                {
                    NodeIndex = i;
                    return true;
                }
            }

            return false;
        }

        public bool IsEmpty()
        {
            if (Count == 0)
                return true;
            return false;
        }

        public void RemoveNode(T NodeData)
        {
            if (ContainsNode(NodeData, out int NodeIndex))
            {
                Nodes.RemoveAt(NodeIndex);
                Count--;

                for (int i = 0; i < Count; i++)   // remove all links from other nodes to the removed one
                {
                    for (int j = 0; i < Nodes[i].Next.Count; i++)
                    {
                        if (Nodes[i].Next[j].Data.Equals(NodeData))
                        {
                            Nodes[i].Next.RemoveAt(j);
                        }
                    }
                }

                for (int i = 0; i < Edges.Count; i++)  // remove all edges that refers to removed one node
                {
                    if (Edges[i].Parent.Equals(NodeData) || Edges[i].Child.Equals(NodeData))
                    {
                        Edges.RemoveAt(i);
                    }
                }
            }

            else throw new Exception(); // here to be custom exception
        }

        public bool ContainsEdge(T FatherNodeData, T ChildNodeData)
        {
            foreach (IEdge<T> Edge in Edges)
            {
                if (Edge.Parent.Data.Equals(FatherNodeData) && Edge.Child.Data.Equals(ChildNodeData))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
