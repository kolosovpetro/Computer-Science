using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> MyDictionary = new MyDictionary<int, string>();
            MyDictionary.Add(0, "Andrey");
            MyDictionary.Add(1, "Eugene");
            MyDictionary.Add(3, "Elizabeth");
            MyDictionary.Add(4, "Landariel");
            MyDictionary.Add(5, "Andy");

            foreach (Node<int, string> page in MyDictionary)
            {
                Console.WriteLine($"{page.Key}, {page.Value}");
            }

            for (int i = 0; i < MyDictionary.Count; i++)
            {
                Console.WriteLine($"{MyDictionary[i].Key}, {MyDictionary[i].Value}");
            }
        }
    }
}
