using DijkstraAlgorithm.Interfaces;

namespace DijkstraAlgorithm.Models
{
    public class TableModel
    {
        public INode CurrentNode { get; set; }
        public int Distance { get; set; }
        public INode PreviousNode { get; set; }

        public override string ToString()
        {
            return $"Current Node: {CurrentNode}, Distance: {Distance}, Prev. Node: {PreviousNode}";
        }
    }
}