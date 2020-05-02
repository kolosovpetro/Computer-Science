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
                Person p1 = new Person
                {
                    FirstName = "Vasily",
                    LastName = "Ivanov",
                    Age = 23
                };

                Person p2 = new Person
                {
                    FirstName = "Andrey",
                    LastName = "Petrov",
                    Age = 22
                };

                personDb.Persons.AddRange(p1, p2);
                personDb.SaveChanges();

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
