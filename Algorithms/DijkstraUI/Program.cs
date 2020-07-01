using System;
using DijkstraAlgorithm.DijkstraTDD;
using DijkstraAlgorithm.Implementations;

namespace DijkstraUI
{
    internal static class Program
    {
        private static void Main()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");

            var ab = new Edge(a, b, 6); // A - B
            var ba = new Edge(b, a, 6); // A - B

            var ad = new Edge(a, d, 1); // A - D
            var da = new Edge(d, a, 1); // A - D

            var db = new Edge(d, b, 2); // D - B
            var bd = new Edge(b, d, 2); // D - B

            var de = new Edge(d, e, 1); // D - E
            var ed = new Edge(e, d, 1); // D - E

            var eb = new Edge(e, b, 2); // E - B
            var be = new Edge(b, e, 2); // E - B

            var ec = new Edge(e, c, 5); // E - C
            var ce = new Edge(c, e, 5); // E - C

            var cb = new Edge(c, b, 5); // C - B
            var bc = new Edge(b, c, 5); // C - B

            var graph = new Graph(ab, ba, ad, da, db, bd, ed, de, eb, be, ec, ce, cb, bc);
            var dijkstra = new DijkstraMethod(graph);
            dijkstra.BuildShortPathTable(d);
            var patches = dijkstra.DistancesList;

            foreach (var path in patches)
            {
                Console.WriteLine(path);
            }
        }
    }
}