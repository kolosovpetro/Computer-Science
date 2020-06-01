namespace PrototypeLibrary
{
    interface IPrototypable
    {
        string Name { get; }
        string Model { get; }
        IPrototypable Clone();
        void ChangeName(string newName);
        void ChangeModel(string newModel);
    }
}
