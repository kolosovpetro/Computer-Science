namespace DecoratorLibrary
{
    class DecoratorB : BaseDecorator
    {
        public DecoratorB(IComponent newComp) : base(newComp) { }
        public override string WriteColor()
        {
            return base.WriteColor() + WriteBlack();
        }

        private string WriteBlack()
        {
            return "Black ";
        }
    }
}
