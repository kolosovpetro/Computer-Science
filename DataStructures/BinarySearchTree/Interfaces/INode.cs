namespace BinarySearchTree.Interfaces
{
    public interface INode
    {
        int Key { get; set; }
        INode Parent { get; set; }
        INode Left { get; set; }
        INode Right { get; set; }
        int Count { get; }
        INode Root { get; set; }
        INode Search(int key);
        INode Insert(int key);
        INode Delete(INode node);
        INode Max();
        INode Min();
        INode Min(INode node);
        INode Successor(INode node);
        void PrintSorted();
    }
}