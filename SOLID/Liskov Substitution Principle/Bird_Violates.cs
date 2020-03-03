using System;

namespace SOLID.LSP
{
    /// <summary>
    /// Abstract class representing bird
    /// </summary>
    abstract public class Bird
    {
        /// <summary>
        /// Method for instance inherrited from bird to perfom fly
        /// </summary>
        abstract public void Fly();
    }

    public class Duck : Bird
    {
        /// <summary>
        /// Fly method implementation for class Duck.
        /// </summary>
        public override void Fly()
        {
            Console.WriteLine("I fly toooo high in beautiful skiiies.");
        }
    }

    public class Chicken : Bird
    {
        /// <summary>
        /// This method breaks LSP, since chicken cannot implement fly method. LSP is a way to check
        /// if abstrac model is correctly reflects reality.
        /// </summary>
        public override void Fly()
        {
            Console.WriteLine("What? I am chicken, and unfortunately, I cannot fly .... :((");
        }
    }
}
