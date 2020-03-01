using System;

namespace PolynomialFunctions
{
    class RootNotFoundException : Exception
    {
        public RootNotFoundException()
        {

        }

        public RootNotFoundException(string Message) : base(Message)
        {

        }
    }
}
