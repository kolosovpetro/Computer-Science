using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
    interface IAnimal
    {
        string Name { get; }
        string Age { get; }
        string Breath();
        string Eat();
        string Sleep();
        string Drink();       // water
    }
}
