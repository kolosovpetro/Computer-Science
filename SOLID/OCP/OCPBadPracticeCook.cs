using System;

namespace SOLID.OCP
{
    // Open-Closed Principle - program should be open for extensions, but closed for modification.
    // To follow OCP we can simply use design pattern "Strategy", 

    class OcpBadPracticeCook
    {
        public string Name { get; set; }
        public OcpBadPracticeCook(string name)
        {
            this.Name = name;
        }

        public void MakeDinner()        // here is concrete implementation of MakeDinner Method
        {
            Console.WriteLine("Чистим картошку");
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }

        // What is we want cook to prepare something different?
        // in order to extend functionality of such class, we have to write + million new methods
        // which leads to spaghetti code
    }
}
