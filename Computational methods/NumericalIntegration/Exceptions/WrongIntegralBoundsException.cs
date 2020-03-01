using System;

namespace NumericalIntegration
{
    class WrongIntegralBoundsException : Exception
    {
        public WrongIntegralBoundsException()
        {

        }

        public WrongIntegralBoundsException(string Message) : base(Message)
        {

        }
    }
}
