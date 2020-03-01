using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class DecoratorC : BaseDecorator
    {
        public DecoratorC(IComponent newComp) : base(newComp) { }
        public override void Execute()
        {
            base.Execute();
            SendLinkedIn();
        }
        public void SendLinkedIn()
        {
            Console.WriteLine("LinkedIn message sent.");
        }
    }
}
