using DecoratorLibrary.BaseFunctionality;

namespace DecoratorLibrary.Decorators
{
    internal class DecoratorC : BaseDecorator
    {
        public DecoratorC(IComponent component) : base(component) { }

        // override of parent method
        public override string WriteColor()
        {
            return base.WriteColor() + WriteBlue();
        }

        // additional functionality
        private static string WriteBlue()
        {
            return "Blue ";
        }
    }
}
