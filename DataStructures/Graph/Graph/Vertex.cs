using System.Collections.Generic;
using Graph.Exceptions;
using Graph.Interfaces;

namespace Graph.Graph
{
    internal class Vertex<T> : IVertex<T>
    {
        public T Data { get; private set; }
        public double Weight { get; private set; }
        public List<bool> Edges { get; }

        public Vertex(T newData, double newWeight)
        {
            Data = newData;
            Weight = newWeight;
            Edges = new List<bool>();
        }

        public void AddConnection(int vertexIndex)
        {
            if (vertexIndex < Edges.Count && vertexIndex >= 0 && !Edges[vertexIndex])
                Edges[vertexIndex] = true;
            else
                throw new VertexConnectionException("Vertices are not exist or already connected.");
        }

        public void RemoveConnection(int vertexIndex)
        {
            if (vertexIndex < Edges.Count && vertexIndex >= 0 && Edges[vertexIndex])
                Edges[vertexIndex] = false;
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
