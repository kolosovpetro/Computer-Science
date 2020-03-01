using System;

namespace Graph
{
    class VertexConnectionException : Exception
    {
        public VertexConnectionException()
        {

        }

        public VertexConnectionException(string Message) : base(Message)
        {

        }
    }
}
