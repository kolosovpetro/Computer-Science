using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class DecoratorA : BaseDecorator
    {
        public DecoratorA(IComponent newComp) : base(newComp) { }
        public override void Execute()
        {
            base.Execute();
            SendFacebook();
        }
        public void SendFacebook()
        {
            Console.WriteLine("Facebook message sent.");
        }
    }
}
