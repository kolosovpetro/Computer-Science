using System;

namespace Assignments_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Difference in modification of references vs value types
            int i = 0;
            int[] t = { 0 };
            Modify(ref i);
            Modify(t);
            Console.WriteLine(i);
            Console.WriteLine(t[0]);

            // Example of out keyword usage
            int x = 1;
            Console.WriteLine(x);
            ModifyingProcedure(out x);
            Console.WriteLine(x);


        }

        // Example how to modify value type properly
        static void Modify(ref int a)
        {
            a = 5;
        }

        // Example how to modify reference type properly
        static void Modify(int[] a)
        {
            a[0] = 5;
        }

        // Returning values from voids
        static void ModifyingProcedure(out int a)
        {
            a = 23;
        }

    }
}
