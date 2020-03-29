using Graph.Graph;

namespace Graph.Interfaces
{
    internal interface IGraph<T>
    {
        void AddVertex(T vertexData, double vertexWeight);
        void RemoveVertex(T vertexData);
        int VertexIndex(T vertexData);
        void AddEdge(T vertexData1, T vertexData2);
        bool AreConnected(T vertexData1, T vertexData2);
        void RemoveEdge(T vertexData1, T vertexData2);
        bool Contains(T vertexData);
        Vertex<T> VertexAt(int index);
        bool IsEmpty();
    }
}
