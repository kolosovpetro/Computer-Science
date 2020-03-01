namespace Prototype
{
    class ConcretePrototypeA : IPrototype
    {
        protected int Width;
        protected int Height;
        protected int Lenght;
        public int GetWidth
        {
            get
            {
                return this.Width;
            }
        }
        public int GetHeight
        {
            get
            {
                return this.Height;
            }
        }
        public int GetLength
        {
            get
            {
                return this.Lenght;
            }
        }
        public ConcretePrototypeA(int newWidth, int newHeight, int newLength)
        {
            this.Width = newWidth;
            this.Height = newHeight;
            this.Lenght = newLength;
        }
        public virtual IPrototype Clone()
        {
            return this;
        }
    }
}
