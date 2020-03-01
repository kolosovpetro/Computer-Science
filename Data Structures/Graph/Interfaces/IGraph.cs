namespace Graph
{
    interface IGraph<T>
    {
        void AddVertex(T VertexData, double VertexWeight);
        void RemoveVertex(T VertexData);
        int VertexIndex(T VertexData);
        void AddEdge(T VertexData1, T VertexData2);
        bool AreConnected(T VertexData1, T VertexData2);
        void RemoveEdge(T VertexData1, T VertexData2);
        bool Contains(T VertexData);
        Vertex<T> VertexAt(int Index);
        bool IsEmpty();
    }
}
