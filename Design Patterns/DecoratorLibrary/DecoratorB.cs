namespace DecoratorLibrary
{
    class DecoratorB : BaseDecorator
    {
        public DecoratorB(IComponent newComp) : base(newComp) { }       // takes the parameter of IComponent

        public override string WriteColor()                             // overrides base method with additional functionality
        {
            return base.WriteColor() + WriteBlack();
        }

        private string WriteBlack()                                     // additional functionlity added to base method
        {
            return "Black ";
        }
    }
}
