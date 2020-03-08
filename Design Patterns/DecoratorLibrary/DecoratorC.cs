namespace DecoratorLibrary
{
    class DecoratorC : BaseDecorator
    {
        public DecoratorC(IComponent newComp) : base(newComp) { }
        public override string WriteColor()
        {
            return base.WriteColor() + WriteBlue();
        }

        private string WriteBlue()
        {
            return "Blue ";
        }
    }
}
