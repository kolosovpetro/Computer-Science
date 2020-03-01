using System;

namespace WeightedGraphNodes.Exceptions
{
    class EdgeAlreadyExistException : Exception
    {
        public EdgeAlreadyExistException()
        {

        }

        public EdgeAlreadyExistException(string Message) : base(Message)
        {

        }
    }
}
