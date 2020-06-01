using System.Collections.Generic;

namespace WeightedGraphNodes.Interfaces
{
    internal interface IGraph<T>
    {
        List<INode<T>> Nodes { get; }
        List<IEdge<T>> Edges { get; }
        int Count { get; }
        bool IsEmpty();
        void AddNode(T newNodeData);
        bool ContainsNode(T nodeData);
        bool ContainsNode(T nodeData, out int nodeIndex);
        bool ContainsEdge(T parentNodeData, T childNodeData);
        void RemoveNode(T nodeData);
        void AddEdge(T parentNodeData, T childNodeData, double weight);
        bool AreConnected(T parentNodeData, T childNodeData);
        bool AreConnected(T parentNodeData, T childNodeData, out int edgeIndex);

    }
}
