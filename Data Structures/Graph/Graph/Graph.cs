using System;
using System.Collections.Generic;
using Graph.Exceptions;
using Graph.Interfaces;

namespace Graph.Graph
{
    internal class Graph<T> : IGraph<T>
    {
        public List<Vertex<T>> GraphBase { get; }
        public int Count { get; private set; }

        public Graph()
        {
            GraphBase = new List<Vertex<T>>();
        }

        public void AddVertex(T vertexData, double vertexWeight)
        {
            Vertex<T> newVertex = new Vertex<T>(vertexData, vertexWeight);
            GraphBase.Add(newVertex);

            foreach (Vertex<T> vertex in GraphBase)
            {
                vertex.IncrementEdges();
            }

            Count++;
        }

        public int VertexIndex(T vertexData)
        {
            Contains(vertexData, out int index);
            return index;
        }

        public void AddEdge(T vertexData1, T vertexData2)
        {
            int index1 = VertexIndex(vertexData1);
            int index2 = VertexIndex(vertexData2);
            GraphBase[index1].AddConnection(index2);

        }

        public bool AreConnected(T vertexData1, T vertexData2)
        {
            if (Contains(vertexData1, out int index1) && Contains(vertexData2, out int index2))
            {
                return GraphBase[index1].Edges[index2];
            }

            return false;
        }

        public void RemoveEdge(T vertexData1, T vertexData2)
        {
            int index1 = VertexIndex(vertexData1);
            int index2 = VertexIndex(vertexData2);
            GraphBase[index1].RemoveConnection(index2);
        }

        public bool Contains(T vertexData)
        {
            foreach (Vertex<T> vertex in GraphBase)
            {
                if (!vertex.Data.Equals(vertexData)) continue;
                return true;
            }

            return false;
        }

        public bool Contains(T vertexData, out int index)
        {
            index = -1;

            for (int i = 0; i < GraphBase.Count; i++)
            {
                if (!GraphBase[i].Data.Equals(vertexData)) continue;
                index = i;
                return true;
            }

            return false;
        }

        public Vertex<T> VertexAt(int index)
        {
            if (index < Count && index != 0)
            {
                return GraphBase[index];
            }

            throw new Exception("No such vertex in a graph."); // here to be custom exception
        }

        public void RemoveVertex(T vertexData)
        {
            if (Contains(vertexData, out int index))
            {
                GraphBase.RemoveAt(index);
            }

            throw new VertexConnectionException("Vertex is not exist or already removed.");
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
