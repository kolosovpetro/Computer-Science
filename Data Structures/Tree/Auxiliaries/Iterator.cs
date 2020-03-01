using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Auxiliaries
{
    class Iterator<T>
    {
        public Tree<T> Tree { get; private set; }

        public Iterator(Tree<T> newTree)
        {
            Tree = newTree;
        }

        public bool TreeConsist(T Data)
        {
            foreach (Node<T> Node in Tree.TreeBase)
            {
                if (Node.Data.Equals(Data))
                    return true;
            }

            return false;
        }
        public bool TreeConsist(T Data, out Node<T> Searched)
        {
            foreach (Node<T> Node in Tree.TreeBase)
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
