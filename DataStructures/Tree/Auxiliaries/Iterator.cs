using Trees.Trees;

namespace Trees.Auxiliaries
{
    internal class Iterator<T>
    {
        public Tree<T> Tree { get; }

        public Iterator(Tree<T> tree)
        {
            Tree = tree;
        }

        public bool TreeConsist(T Data)
        {
            foreach (var Node in Tree.TreeBase)
            {
                if (Node.Data.Equals(Data))
                    return true;
            }

            return false;
        }
        public bool TreeConsist(T Data, out Node<T> Searched)
        {
            foreach (var Node in Tree.TreeBase)
            {
                if (Node.Data.Equals(Data))
                {
                    Searched = Node;
                    return true;
                }
            }

            Searched = default;
            return false;
        }
    }
}
