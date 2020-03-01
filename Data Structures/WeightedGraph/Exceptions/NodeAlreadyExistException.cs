using System;

namespace WeightedGraphNodes.Exceptions
{
    class NodeAlreadyExistException : Exception
    {
        public NodeAlreadyExistException()
        {

        }

        public NodeAlreadyExistException(string Message) : base(Message)
        {

        }
    }
}
