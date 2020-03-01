using System;

namespace WeightedGraphNodes.Exceptions
{
    class EdgeNotExistException : Exception
    {
        public EdgeNotExistException()
        {

        }

        public EdgeNotExistException(string Message) : base(Message)
        {

        }
    }
}
