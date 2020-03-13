using System;

namespace Converters
{
    class Animal : IAnimal
    {
        public string Name { get; private set; }

        public string Age { get; private set; }

        public Animal(string name, string age)
        {
            Name = name;
            Age = age;
        }

        public virtual string Breath()
        {
            return null;
        }

        public virtual string Drink()
        {
            return null;
        }

        public virtual string Eat()
        {
            return null;
        }

        public virtual string Sleep()
        {
            return null;
        }
    }
}
