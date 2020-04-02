using DecoratorLibrary.BaseFunctionality;

namespace DecoratorLibrary
{
    class DecoratorC : BaseDecorator
    {
        public DecoratorC(IComponent newComp) : base(newComp) { }       // takes the parameter of IComponent

        public override string WriteColor()                             // overrides base method with additional functionality
        {
            return base.WriteColor() + WriteBlue();
        }

        private string WriteBlue()                                       // additional functionality added to base method
        {
            return "Blue ";
        }
    }
}
