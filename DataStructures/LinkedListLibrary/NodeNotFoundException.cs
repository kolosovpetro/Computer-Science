using System;

namespace LinkedListLibrary
{
    class NodeNotFoundException : Exception
    {
        public NodeNotFoundException()
        {

        }

        public NodeNotFoundException(string message) : base(message)
        {

        }
    }
}
