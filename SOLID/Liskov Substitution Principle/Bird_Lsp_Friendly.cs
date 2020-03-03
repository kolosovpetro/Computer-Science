using System;

namespace SOLID.LSP
{
    /// <summary>
    /// Abstract class representing bird
    /// </summary>
    abstract public class Bird
    {
        /// <summary>
        /// Method for bird to sing. Yeah, there is only 1 bird cannot sing: Manakin. 
        /// But let's neglect it
        /// </summary>
        abstract public void Sing();
    }

    abstract public class FlyingBird : Bird
    {
        /// <summary>
        /// Instance method of flying birds to fly
        /// </summary>
        abstract public void Fly();
    }

    public class Duck : FlyingBird
    {
        /// <summary>
        /// Fly method implementation for class Duck.
        /// </summary>
        public override void Fly()
        {
            Console.WriteLine("I fly toooo high in beautiful skiiies.");
        }

        /// <summary>
        /// Implementation of sing method "Quack" for duck. 
        /// </summary>
        public override void Sing()
        {
            Console.WriteLine("Quack - Quack");
        }
    }

    public class Chicken : Bird
    {
        /// <summary>
        /// Sing Method implementation of Chicken
        /// </summary>
        public override void Sing()
        {
            Console.WriteLine("Kud-Kuda");
        }
    }
}
