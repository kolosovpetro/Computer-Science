namespace Converters
{
    class Dog : Animal
    {
        public Dog(string name, string age) : base(name, age) { }

        public override string Eat()
        {
            return "I'm Dog and I'm eating... omnomonom";
        }

        public override string Breath()
        {
            return "I'm Dog and I'm breathing...";
        }

        public override string Drink()
        {
            return "I'm Dog and I'm breathing ...";
        }

        public override string Sleep()
        {
            return "I'm Dog and I'm sleeping ...";
        }

        // converter

        public static implicit operator Cat(Dog d)
        {
            return new Cat(d.Name, d.Age);
        }
    }
}
