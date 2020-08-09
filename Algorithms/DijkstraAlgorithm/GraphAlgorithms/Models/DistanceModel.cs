using GraphLibrary.Interfaces;

namespace GraphAlgorithms.Models
{
    public class DistanceModel<T>
    {
        public IVertex<T> Vertex { get; set; }
        public IVertex<T> PreviousVertex { get; set; }
        public int Distance { get; set; }

        public DistanceModel(IVertex<T> vertex, IVertex<T> previousVertex, int distance)
        {
            Vertex = vertex;
            PreviousVertex = previousVertex;
            Distance = distance;
        }

        public DistanceModel()
        {
        }

        public override string ToString()
        {
            return $"Vertex: {Vertex} - Distance: {Distance} - Previous: {PreviousVertex}";
        }
    }
}