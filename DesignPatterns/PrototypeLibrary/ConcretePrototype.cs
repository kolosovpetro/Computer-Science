namespace PrototypeLibrary
{
    internal class ConcretePrototype : IPrototype
    {
        public string Name { get; private set; }
        public string Model { get; private set; }

        public ConcretePrototype(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public IPrototype Clone()
        {
            return new ConcretePrototype(Name, Model);      // deep copy
            // return this;                                 // shallow copy
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeModel(string model)
        {
            Model = model;
        }
    }
}
