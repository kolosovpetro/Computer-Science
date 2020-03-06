using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Person person = new Person();
            person.SetData("Tom", "claren","Swiety Marcin","8","4","61-803","Poznan","poijki");

            Console.WriteLine(person.IntroduceYourself());
            Console.ReadKey();
        }
    }
}
