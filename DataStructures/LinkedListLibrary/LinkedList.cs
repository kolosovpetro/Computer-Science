namespace LinkedListLibrary
{
    internal class LinkedList<T> : ILinkedList<T>
    {
        public INode<T> First { get; private set; }

        public INode<T> Last { get; private set; }

        public int Count { get; private set; }

        public LinkedList()
        {
            First = null;
            Last = null;
        }

        public void AddAfter(T data, INode<T> newNode)
        {
            var current = SearchNode(data);
            var next = current.Next;

            if (Last.Data.Equals(current.Data))
            {
                current.SetNext(newNode);
                AddLast(newNode.Data);
            }

            current.SetNext(newNode);
            newNode.SetNext(next);
            Count++;
        }

        public void AddFirst(T newFirstData)
        {
            var newNode = new Node<T>(newFirstData);
            newNode.SetNext(newNode);
            First = newNode;
            AddLast(newNode.Data);
            Count++;
        }

        public void AddLast(T newLastData)
        {
            var newNode = new Node<T>(newLastData);
            Last = newNode;
            Count++;
        }

        public void DeleteNode(T nodeData)
        {
            if (!Contains(nodeData))
                throw new NodeNotFoundException("There is no such node in linked list.");

            INode<T> s = First;

            while (true)
            {
                if (s.Next.Data.Equals(nodeData)) break;

                if (!s.Next.Equals(null)) s = s.Next;
            }

            INode<T> current = SearchNode(nodeData);
            s.SetNext(current.Next);
        }

        public void RemoveFirst()
        {
            if (First.Equals(null))
                throw new NodeNotFoundException("First node is null");

            First = First.Next;
        }

        public void RemoveLast()
        {
            if (Last.Equals(null))
                throw new NodeNotFoundException("Last node is equal null.");

            INode<T> s = First;

            while (!s.Next.Data.Equals(Last.Data))
            {
                s = s.Next;
            }

            s.SetNext(null);
            AddLast(s.Data);
        }

        public INode<T> SearchNode(T nodeData)
        {
            INode<T> s = First;

            while (true)
            {
                if (s.Data.Equals(nodeData)) return s;

                if (s.Next.Equals(null)) break;

                s = s.Next;
            }

            return null;
        }

        public bool Contains(T data)
        {
            return SearchNode(data) != null;
        }
    }
}
