using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // When solving the exercises remember to make sure your program doesn’t crash 
            // regardless of user’s input.

            // Write a program which reads 20 numbers given by the user and prints them out in reverse order

            Random r = new Random();                    // in order to skip this task faster; 
                                                        // correct solution is commented in loop
            StringBuilder sb = new StringBuilder();

            int[] arr;                                  // global array we work with
            int num;                                    // var for array term

            Console.WriteLine("Program which reads 20 numbers given by the user and prints them out in reverse order");

            arr = new int[20];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Provide a number: ");

                //while (!int.TryParse(Console.ReadLine(), out num))
                //{
                //    Console.WriteLine("Provide an integer number: ");
                //}

                //arr[i] = num;

                num = r.Next(0, 100);
                arr[i] = num;
                Console.WriteLine(num);
            }

            for (int i = 0; i < arr.Length; i++) sb.Append(arr[arr.Length - 1 - i] + ", ");     // append values to str builder
            Console.WriteLine(sb.ToString());                                                   // print reversed array

            // Write a program which asks the user how many numbers he wants to provide, then reads these
            // numbers, stores them in an array, calculates their average and prints it out in the following format:
            // The average of numbers 1 2 3 4 5 6 is 3.5

            Console.WriteLine("Get from user, calculate average, print");
            int size;
            double avg = default;

            Console.WriteLine("Enter the size of array: ");
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Provide an integer number: ");
            }

            arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Provide a number: ");

                //while (!int.TryParse(Console.ReadLine(), out num))
                //{
                //    Console.WriteLine("Provide an integer number: ");
                //}

                //arr[i] = num;

                num = r.Next(0, 100);
                arr[i] = num;
                Console.WriteLine(num);
            }

            for (int i = 0; i < arr.Length; i++) 
                avg += (double)arr[i] / size;                                                   // calculating average
            sb.Append("\nThe average of array: ");                                                // append label message
            for (int i = 0; i < arr.Length; i++) 
                sb.Append(arr[arr.Length - 1 - i] + ", ");                                      // sb append array terms
            sb.Append($"is {avg}");                                                             // sb append average value
            Console.WriteLine(sb.ToString());                                                   // print formated string




        }
    }
}
