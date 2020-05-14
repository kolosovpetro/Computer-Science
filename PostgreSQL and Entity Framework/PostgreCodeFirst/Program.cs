using System;
using System.Linq;

namespace PostgreCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var personDb = new PersonDbContext())
            {
                var persons = personDb.Persons.ToList();

                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.FirstName} - {person.LastName} - {person.Age}");
                }
            }
            Console.Read();
        }
    }
}
