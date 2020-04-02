namespace DecoratorLibrary.BaseFunctionality
{
    /// <summary>
    /// This is a basic functionality of a program. It is entire functionality. In our case it is the first word we print out.
    /// Class implementing this interface to be passed to BaseDecorator.
    /// </summary>
    class Component : IComponent
    {
        public string WriteColor()
        {
            return "White ";
        }
    }
}
