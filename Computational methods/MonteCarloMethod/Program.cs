using MonteCarloMethod.Classes;
using System;

namespace MonteCarloMethod
{
    internal class Program
    {
        private static void Main()
        {
            Plan Tasks = new Plan();
            int TaskNumber = default;

            Console.WriteLine("To finish add Tasks, type END");
            Console.WriteLine("Enter the Task and its Estimations (e.g 10 20 30 ...): ");

            while (true)
            {
                try
                {
                    Console.Write($"Task {TaskNumber} > ");
                    string Input = Console.ReadLine();

                    if (Input != null && Input.ToLower() == "end")
                    {
                        Tasks.CheckSize();
                        break;
                    }

                    Tasks.AddTask(new Task(Input));
                    TaskNumber++;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message + " Try again");
                }
            }

            Bucket Bucket = new Bucket(Tasks);

            Console.WriteLine($"\nAfter probing {Bucket.Size} random plans, the results are: ");
            Console.WriteLine($"Minimum: {Bucket.Min}");
            Console.WriteLine($"Average: {Bucket.Avg}");
            Console.WriteLine($"Maximum: {Bucket.Max}");

            Console.WriteLine("\nProbability of finishing plan in: ");
            foreach (var Prob in Bucket.Probabilities)
            {
                Console.WriteLine($"{Prob.Key} days: {Prob.Value} %");
            }

            Console.WriteLine("\nAccumulated probability to finish plan before or in time: ");

            foreach (var Prob in Bucket.AccumulatedProbabilities)
            {
                Console.WriteLine($"{Prob.Key} days: {Prob.Value} %");
            }
        }
    }
}
