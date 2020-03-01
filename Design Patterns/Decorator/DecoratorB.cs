using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class DecoratorB : BaseDecorator
    {
        public DecoratorB(IComponent newComp) : base(newComp) { }
        public override void Execute()
        {
            base.Execute();
            SendTwitter();
        }
        public void SendTwitter()
        {
            Console.WriteLine("Twitter message sent.");
        }
    }
}
