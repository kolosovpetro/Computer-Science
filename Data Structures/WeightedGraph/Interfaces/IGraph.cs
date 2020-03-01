using System.Collections.Generic;

namespace WeightedGraphNodes.Interfaces
{
    interface IGraph<T>
    {
        List<INode<T>> Nodes { get; }
        List<IEdge<T>> Edges { get; }
        int Count { get; }
        bool IsEmpty();
        void AddNode(T newNodeData);
        bool ContainsNode(T NodeData);
        bool ContainsNode(T NodeData, out int NodeIndex);
        bool ContainsEdge(T FatherNodeData, T ChildNodeData);
        void RemoveNode(T Nodedata);
        void AddEdge(T ParentNodeData, T ChildNodeData, double Weight);
        bool AreConnected(T ParentNodeData, T ChildNodeData);
        bool AreConnected(T ParentNodeData, T ChildNodeData, out int EdgeIndex);

    }
}
