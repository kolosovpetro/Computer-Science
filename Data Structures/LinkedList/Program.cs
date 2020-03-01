using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> ll = new LinkedList<string>();
            ll.AddFirst("First Node");
            ll.AddFirst("Test 0");
            ll.AddFirst("Test 1");
            ll.AddFirst("Test 2");
            ll.AddFirst("Test 3");
            ll.AddLast("Last Node");
            Node<string> Result = ll.Search("Tes 3"); // null reference if Last Node
            Console.WriteLine(Result.Data);
            Console.WriteLine(ll.Last.Data); // null refenrece exception
        }
    }
}
