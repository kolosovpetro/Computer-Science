using System;
using GraphAlgorithms.Algorithms;
using GraphLibrary.Implementations;
using GraphLibrary.Interfaces;

namespace GraphAlgorithmsUI
{
    internal static class Program
    {
        private static void Main()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            graph.AddEdge(a, b, 6);
            graph.AddEdge(b, a, 6);

            graph.AddEdge(a, d, 1);
            graph.AddEdge(d, a, 1);

            graph.AddEdge(d, e, 1);
            graph.AddEdge(e, d, 1);

            graph.AddEdge(d, b, 2);
            graph.AddEdge(b, d, 2);

            graph.AddEdge(e, b, 2);
            graph.AddEdge(b, e, 2);

            graph.AddEdge(e, c, 5);
            graph.AddEdge(c, e, 5);

            graph.AddEdge(c, b, 5);
            graph.AddEdge(b, c, 5);
            
            var algorithms = new DijkstraAlgorithm<char>();
            var dijkstraMethod = algorithms.DijkstraMethod(graph, a);

            foreach (var path in dijkstraMethod)
            {
                Console.WriteLine(path);
            }
        }
    }
}