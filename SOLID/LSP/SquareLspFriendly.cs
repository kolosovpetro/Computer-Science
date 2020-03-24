namespace SOLID.LSP
{
    class SquareLspFriendly : IPolygon
    {
        public double Lenght { get; set; }

        public SquareLspFriendly(double lenght)
        {
            Lenght = lenght;
        }

        public double GetArea()
        {
            return Lenght * Lenght;
        }
    }
}
