using DecoratorLibrary.BaseFunctionality;

namespace DecoratorLibrary
{
    class DecoratorA : BaseDecorator
    {
        public DecoratorA(IComponent newComp) : base(newComp) { }       // takes the parameter of IComponent

        public override string WriteColor()                             // overrides base method with additional functionality
        {
            return base.WriteColor() + WriteRed();
        }

        private string WriteRed()                                       // additional functionality added to base method
        {
            return "Red ";
        }
    }
}
