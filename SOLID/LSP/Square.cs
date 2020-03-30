namespace SOLID.LSP
{
    internal class Square : Rectangle
    {
        public override double Width
        {
            get => base.Width;

            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override double Height
        {
            get => base.Height;

            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}
