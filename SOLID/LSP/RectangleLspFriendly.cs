namespace SOLID.LSP
{
    class RectangleLspFriendly : IPolygon
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public RectangleLspFriendly(double width, double length)
        {
            Width = width;
            Height = length;
        }

        public double GetArea()
        {
            return Width * Height;
        }
    }
}
