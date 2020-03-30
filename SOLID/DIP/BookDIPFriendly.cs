namespace SOLID.DIP
{
    class BookDipFriendly
    {
        public string Contents { get; set; }
        public IPrintable Printer { get; set; }      // here abstract entity of Printable

        public void Print()
        {
            Printer.Print();
        }

        // this class fits Dependency Inversion Principle, since Printer is done by abstraction
    }
}
