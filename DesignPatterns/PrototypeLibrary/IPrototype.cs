namespace PrototypeLibrary
{
    internal interface IPrototype
    {
        string Name { get; }
        string Model { get; }
        IPrototype Clone();
        void ChangeName(string name);
        void ChangeModel(string model);
    }
}
