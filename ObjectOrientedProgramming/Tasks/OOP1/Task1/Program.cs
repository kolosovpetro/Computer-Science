using System;

namespace Task1
{
    internal static class Program
    {
        public static void Main()
        {
            var person = new Person();
            person.SetData("Tom", "Caren","Swiety Marcin","8","4","61-803","Poznan","poijki");

            Console.WriteLine(person.IntroduceYourself());
        }
    }
}
