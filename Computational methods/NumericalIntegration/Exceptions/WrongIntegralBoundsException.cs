using System;

namespace NumericalIntegration.Exceptions
{
    internal class WrongIntegralBoundsException : Exception
    {
        public WrongIntegralBoundsException(string message) : base(message)
        {

        }
    }
}
