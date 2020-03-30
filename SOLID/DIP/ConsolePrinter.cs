using System;

namespace SOLID.DIP
{
    internal class ConsolePrinter : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Printing book to console ... ");
        }
    }
}
