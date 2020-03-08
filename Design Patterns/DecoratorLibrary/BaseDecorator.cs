namespace DecoratorLibrary
{
    /// <summary>
    /// Decorator with dependency injection of base functionality component. 
    /// Used in order to extend functionality of base component.
    /// </summary>
    class BaseDecorator : IComponent
    {
        protected IComponent comp;                  // takes as input the instance of object with functionality
                                                    // we want to extend.
        public BaseDecorator(IComponent newComp)
        {
            comp = newComp;                         // new object with fith functionality to extend is instaticated in constructor
        }

        public virtual string WriteColor()
        {
            return comp.WriteColor();               // implements interface IComponent on behalf of comp instance.
        }
    }
}
