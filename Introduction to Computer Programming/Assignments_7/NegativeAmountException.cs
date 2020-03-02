using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_7
{
    class NegativeAmountException : Exception
    {
        public NegativeAmountException()
        {

        }

        public NegativeAmountException(string message) : base(message)
        {

        }
    }
}
