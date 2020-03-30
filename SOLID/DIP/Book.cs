namespace SOLID.DIP
{
    internal class Book
    {
        public string Contents { get; set; }
        public ConsolePrinter ConsolePrinter { get; set; }      // here concrete class of printer, which limits print only to console

        public void Print()
        {
            ConsolePrinter.Print();
        }

        // this class breaks Dependency Inversion Principle, since Console printer is not abstraction.
    }
}
