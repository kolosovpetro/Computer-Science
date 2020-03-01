using System;
using System.Linq;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> q1 = new Queue<string>(5);
            q1.Enqueue("term 1");
            q1.Enqueue("term 2");
            q1.Enqueue("term 3");
            q1.Enqueue("term 4");
            q1.Enqueue("term 5");

            foreach (string item in q1)
            {
                Console.Write(item + ", ");
            }

            for (int i = 0; i < q1.Count(); i++)
            {
                Console.WriteLine(q1[i]);
            }
        }
    }
}
