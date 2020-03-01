using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write 1 to see message 1, write elsewhat to see Unknown message:");
            string UserChoose = Console.ReadLine();
            Controller c1 = new Controller(UserChoose);
            Model m1 = new Model(c1);
            View w1 = new View(m1);
            w1.PrintMessage();
        }
    }
}
