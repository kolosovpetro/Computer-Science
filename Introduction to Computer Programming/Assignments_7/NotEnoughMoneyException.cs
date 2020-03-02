using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_7
{
    class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException()
        {

        }

        public NotEnoughMoneyException(string message) : base(message)
        {

        }
    }
}
