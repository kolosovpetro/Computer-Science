// TODO: By using the following classes we're breaking an implicit contract. Fix it.

using System;

namespace Exercises.LiskovSubstitutionPrinciple
{
    public abstract class Shape
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public abstract double Area();
    }


    public class Rectangle : Shape
    {
        public override double Area()
        {
            return Height * Width;
        }
    }

    public class Square : Rectangle
    {
        public int Sides { get; set; }
        public override double Area()
        {
            return Sides * Sides;
        }
    }

    public class Disk : Shape
    {
        int Radius { get; set; }
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
