using System;

namespace FluentBuilder
{
    internal class Program
    {
        private static void Main()
        {
            Person p1 = new Person()
                .SetFirstname("Petro")
                .SetLastname("Kolosov")
                .SetAge(26)
                .SetCity("Berlin")
                .SetCounty("GR");

            Console.WriteLine(p1);
        }
    }
}
