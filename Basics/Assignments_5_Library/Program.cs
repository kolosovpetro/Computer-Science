using System;
using Assignments1;
using Assignments2;
using Assignments3;
using Assignments4;
using Assignments5;

namespace Assignments_5_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menu = new string[]
            {
                "1. Assignments 1",
                "2. Assignments 2",
                "3. Assignments 3",
                "4. Assignments 4",
                "5. Assignments 5"
            };

            Console.WriteLine("Main Menu: ");

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Type number: ");

            string ans = Console.ReadLine();

            switch (ans)
            {
                case "1":
                    Asgn1.Execute();
                    break;
                case "2":
                    Asgn2.Execute();
                    break;
                case "3":
                    Asgn3.Execute();
                    break;
                case "4":
                    Asgn4.Execute();
                    break;
                case "5":
                    Asgn5.Execute();
                    break;
                default:
                    break;
            }
        }
    }
}
