namespace SOLID.LSP
{
    internal class Rectangle : IPolygon
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

        public double GetArea()
        {
            return Width * Height;
        }
    }
}
