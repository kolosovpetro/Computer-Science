namespace Converters
{
    class Cat : Animal
    {
        public Cat(string name, string age) : base(name, age) { }

        public override string Eat()
        {
            return "I'm Cat and I'm eating... omnomonom";
        }

        public override string Breath()
        {
            return "I'm Cat and I'm breathing...";
        }

        public override string Drink()
        {
            return "I'm Cat and I'm breathing ...";
        }

        public override string Sleep()
        {
            return "I'm Cat and I'm sleeping ...";
        }

        // converter

        public static implicit operator Dog(Cat c)
        {
            return new Dog(c.Name, c.Age);
        }
    }
}
