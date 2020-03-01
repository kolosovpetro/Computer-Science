using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class CurrentAdapter : IAdapter
    {
        public IService Receive(IIncompatableClass incompatable)
        {
            return new Service();
        }

        public IIncompatableClass Send(IService service)
        {
            throw new NotImplementedException();
        }
    }
}
