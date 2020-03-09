using System;

namespace PrototypeLibrary
{
    class Prototype : IPrototypable
    {
        public string Name { get; private set; }
        public string Model { get; private set; }

        public Prototype(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public IPrototypable Clone()
        {
            return new Prototype(Name, Model);      // deep copy
            // return this;                         // shallow copy
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public void ChangeModel(string newModel)
        {
            Model = newModel;
        }
    }
}
