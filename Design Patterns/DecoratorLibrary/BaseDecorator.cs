namespace DecoratorLibrary
{
    /// <summary>
    /// Decorator with dependency injection of base functionality component. 
    /// Used in order to extend functionality of base component.
    /// </summary>
    class BaseDecorator : IComponent
    {
        protected IComponent comp;
        public BaseDecorator(IComponent newComp)
        {
            comp = newComp;
        }

        public virtual string WriteColor()
        {
            return comp.WriteColor();
        }
    }
}
