using System.Collections.Generic;

namespace Graph
{
    class Vertex<T> : IVertex<T>
    {
        public T Data { get; private set; }
        public double Weight { get; private set; }
        public List<bool> Edges { get; private set; }

        public Vertex(T newData, double newWeight)
        {
            Data = newData;
            Weight = newWeight;
            Edges = new List<bool>();
        }

        public void AddConnection(int VertexIndex)
        {
            if (VertexIndex < Edges.Count && VertexIndex >= 0 && !Edges[VertexIndex])
                Edges[VertexIndex] = true;
            else
                throw new VertexConnectionException("Vertices are not exist or already connected.");
        }

        public void RemoveConnection(int VertexIndex)
        {
            if (VertexIndex < Edges.Count && VertexIndex >= 0 && Edges[VertexIndex])
                Edges[VertexIndex] = false;
            else
                throw new VertexConnectionException("Vertices are not exist or not connected");
        }

        public void SetVertexData(T newData)
        {
            Data = newData;
        }
        public void SetVertexWeight(double newWeight)
        {
            Weight = newWeight;
        }

        public List<bool> GetVertexConnections()
        {
            return Edges;
        }

        public void IncrementEdges()
        {
            Edges.Add(false);
        }
    }
}
