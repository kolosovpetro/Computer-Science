using System;
using DijkstraAlgorithm.DijkstraTDD;
using DijkstraAlgorithm.Implementations;

namespace DijkstraUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");

            var ab = new Edge(a, b, 6); // A - B
            var ad = new Edge(a, d, 1); // A - D
            var db = new Edge(d, b, 2); // D - B
            var de = new Edge(d, e, 1); // D - E
            var eb = new Edge(e, b, 2); // E - B
            var ec = new Edge(e, c, 5); // E - C
            var cb = new Edge(c, b, 5); // C - B
            var bc = new Edge(b, c, 5); // C - B

            var graph = new Graph(ab, ad, db, de, eb, ec, cb, bc);
            var dijkstra = new DijkstraMethod(graph);
            dijkstra.BuildShortPathTable();
            var patches = dijkstra.DistancesList;

            foreach (var path in patches)
            {
                Console.WriteLine(path);
            }
        }
    }
}