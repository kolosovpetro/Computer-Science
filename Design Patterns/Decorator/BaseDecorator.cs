using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class BaseDecorator : IComponent
    {
        protected IComponent Comp;
        public BaseDecorator(IComponent newComp)
        {
            this.Comp = newComp;
        }
        public virtual void Execute()
        {
            Comp.Execute();
        }
    }
}
