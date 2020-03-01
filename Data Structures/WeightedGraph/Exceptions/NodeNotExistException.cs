using System;

namespace WeightedGraphNodes.Exceptions
{
    class NodeNotExistException : Exception
    {
        public NodeNotExistException()
        {

        }

        public NodeNotExistException(string Message) : base(Message)
        {

        }
    }
}
