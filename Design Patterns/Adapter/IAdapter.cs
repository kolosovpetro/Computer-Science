using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    interface IAdapter : IIncompatableClass, IService
    {
        IIncompatableClass Send(IService service);
        IService Receive(IIncompatableClass incompatable);
    }
}
