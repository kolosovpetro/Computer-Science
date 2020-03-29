using System;

namespace WeightedGraphNodes.Exceptions
{
    internal class NodeNotExistException : Exception
    {
        public NodeNotExistException(string message) : base(message)
        {

        }
    }
}
