using System;
using Assignments1;
using Assignments2;
using Assignments3;
using Assignments4;
using Assignments5;

namespace Assignments_5_Library
{
    internal class Program
    {
        private static void Main()
        {
            string[] menu = {
                "1. Assignments 1",
                "2. Assignments 2",
                "3. Assignments 3",
                "4. Assignments 4",
                "5. Assignments 5"
            };

            Console.WriteLine("Main Menu: ");

            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Type number: ");

            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    Set1.Execute();
                    break;
                case "2":
                    Set2.Execute();
                    break;
                case "3":
                    Set3.Execute();
                    break;
                case "4":
                    Set4.Execute();
                    break;
                case "5":
                    Set5.Execute();
                    break;
            }
        }
    }
}
