namespace SOLID.LSP
{
    internal class SquareLspFriendly : IPolygon
    {
        public double Length { get; set; }

        public SquareLspFriendly(double length)
        {
            Length = length;
        }

        public double GetArea()
        {
            return Length * Length;
        }
    }
}
