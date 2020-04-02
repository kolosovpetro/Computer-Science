using DecoratorLibrary.BaseFunctionality;

namespace DecoratorLibrary
{
    /// <summary>
    /// Decorator with dependency injection of base functionality component. 
    /// Used in order to extend functionality of base component.
    /// </summary>
    internal class BaseDecorator : IComponent
    {
        protected IComponent Comp;                  // takes as input the instance of object with functionality
                                                    // we want to extend.
        public BaseDecorator(IComponent newComp)
        {
            Comp = newComp;                         // new object with with functionality to extend is instantiated in constructor
        }

        public virtual string WriteColor()
        {
            return Comp.WriteColor();               // implements interface IComponent on behalf of comp instance.
        }
    }
}
