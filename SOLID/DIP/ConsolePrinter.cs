using System;

namespace SOLID.DIP
{
    class ConsolePrinter : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Printing book to console ... ");
        }
    }
}
