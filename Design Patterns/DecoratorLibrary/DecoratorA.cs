namespace DecoratorLibrary
{
    class DecoratorA : BaseDecorator
    {
        public DecoratorA(IComponent newComp) : base(newComp) { }
        public override string WriteColor()
        {
            return base.WriteColor() + WriteRed();
        }

        private string WriteRed()
        {
            return "Red ";
        }
    }
}
