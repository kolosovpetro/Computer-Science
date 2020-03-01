using MonteCarloMethod.Classes;
using System;
using System.Collections.Generic;

namespace MonteCarloMethod
{
    class Program
    {
        static void Main(string[] args)
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

                    if (Input.ToLower() == "end")
                    {
                        Tasks.CheckSize();
                        break;
                    }

                    Tasks.AddTask(new Task(Input));
                    TaskNumber++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " Try again");
                }
            }

            Bucket b = new Bucket(Tasks);

            Console.WriteLine($"\nAfter probing {b.Size} random plans, the results are: ");
            Console.WriteLine($"Minimum: {b.Min}");
            Console.WriteLine($"Average: {b.Avg}");
            Console.WriteLine($"Maximum: {b.Max}");

            Console.WriteLine("\nProbability of finishing plan in: ");
            foreach (KeyValuePair<double, double> prob in b.Probabilities)
            {
                Console.WriteLine($"{prob.Key} days: {prob.Value} %");
            }

            Console.WriteLine("\nAccumulated probability to finish plan before or in time: ");

            foreach (KeyValuePair<double, double> prob in b.AccumProbabilities)
            {
                Console.WriteLine($"{prob.Key} days: {prob.Value} %");
            }

            for (int i = 0; i < b.AccumProbabilities.Count; i++)
            {
                if (i == 0)
                {

                }
            }
        }
    }
}
