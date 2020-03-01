using System;
using System.Collections.Generic;

namespace Graph
{
    class Graph<T> : IGraph<T>
    {
        public List<Vertex<T>> GraphBase { get; private set; }
        public int Count { get; private set; }

        public Graph()
        {
            GraphBase = new List<Vertex<T>>();
        }

        public void AddVertex(T VertexData, double VertexWeight)
        {
            Vertex<T> NewVertex = new Vertex<T>(VertexData, VertexWeight);
            GraphBase.Add(NewVertex);

            for (int i = 0; i < GraphBase.Count; i++)
            {
                GraphBase[i].IncrementEdges();
            }

            Count++;
        }

        public int VertexIndex(T VertexData)
        {
            Contains(VertexData, out int Index);
            return Index;
        }

        public void AddEdge(T VertexData1, T VertexData2)
        {
            int Index1 = VertexIndex(VertexData1);
            int Index2 = VertexIndex(VertexData2);
            GraphBase[Index1].AddConnection(Index2);

        }

        public bool AreConnected(T VertexData1, T VertexData2)
        {
            if (Contains(VertexData1, out int Index1) && Contains(VertexData2, out int Index2))
            {
                return GraphBase[Index1].Edges[Index2];
            }

            return false;
        }

        public void RemoveEdge(T VertexData1, T VertexData2)
        {
            int Index1 = VertexIndex(VertexData1);
            int Index2 = VertexIndex(VertexData2);
            GraphBase[Index1].RemoveConnection(Index2);
        }

        public bool Contains(T VertexData)
        {
            foreach (Vertex<T> Vertex in GraphBase)
            {
                if (Vertex.Data.Equals(VertexData))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(T VertexData, out int Index)
        {
            Index = -1;

            for (int i = 0; i < GraphBase.Count; i++)
            {
                if (GraphBase[i].Data.Equals(VertexData))
                {
                    Index = i;
                    return true;
                }
            }

            return false;
        }

        public Vertex<T> VertexAt(int Index)
        {
            if (Index < Count && Index >= 0)
            {
                return GraphBase[Index];
            }

            throw new Exception(); // here to be custom exception
        }

        public void RemoveVertex(T VertexData)
        {
            if (Contains(VertexData, out int Index))
            {
                GraphBase.RemoveAt(Index);
            }

            throw new VertexConnectionException("Vertex is not exist or already removed.");
        }

        public bool IsEmpty()
        {
            if (Count == 0)
                return true;
            return false;
        }
    }
}
