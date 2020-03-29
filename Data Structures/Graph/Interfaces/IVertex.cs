using System.Collections.Generic;

namespace Graph.Interfaces
{
    internal interface IVertex<in T>
    {
        void AddConnection(int vertexIndex);
        void RemoveConnection(int vertexIndex);
        void SetVertexData(T data);
        void SetVertexWeight(double newWeight);
        List<bool> GetVertexConnections();
        void IncrementEdges();
    }
}
