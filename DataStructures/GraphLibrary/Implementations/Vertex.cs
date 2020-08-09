using System;
using System.Collections.Generic;
using GraphLibrary.Interfaces;

namespace GraphLibrary.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        public T Data { get; }
        public bool IsVisited { get; private set; }
        public IGraph<T> CurrentGraph { get; }
        public int Degree { get; private set; }

        public Vertex(T data)
        {
            Data = data;
        }

        public Vertex(T data, IGraph<T> currentGraph)
        {
            Data = data;
            CurrentGraph = currentGraph;
        }

        public void Visit()
        {
            IsVisited = true;
        }

        public void IncrementDegree()
        {
            Degree++;
        }

        public void DecrementDegree()
        {
            Degree--;
        }

        private bool Equals(Vertex<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Data, other.Data)
                   && IsVisited == other.IsVisited && Degree == other.Degree;
        }

        public bool Equals(IVertex<T> other)
        {
            return other != null
                   && IsVisited == other.IsVisited
                   && Data.Equals(other.Data)
                   && Degree == other.Degree;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Vertex<T>) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Data, IsVisited, Degree);
        }
    }
}