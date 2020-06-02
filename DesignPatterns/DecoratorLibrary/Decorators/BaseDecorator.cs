using DecoratorLibrary.BaseFunctionality;

namespace DecoratorLibrary.Decorators
{
    internal class BaseDecorator : IComponent
    {
        protected IComponent Component { get; }

        // aggregation in constructor
        public BaseDecorator(IComponent component)
        {
            Component = component;
        }

        // virtual method to be overriden in child-decorators
        public virtual string WriteColor()
        {
            return Component.WriteColor();
        }
    }
}
