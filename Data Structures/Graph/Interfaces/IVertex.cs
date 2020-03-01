using System.Collections.Generic;

namespace Graph
{
    interface IVertex<T>
    {
        void AddConnection(int VertexIndex);
        void RemoveConnection(int VetexIndex);
        void SetVertexData(T Data);
        void SetVertexWeight(double newWeight);
        List<bool> GetVertexConnections();
        void IncrementEdges();
    }
}
