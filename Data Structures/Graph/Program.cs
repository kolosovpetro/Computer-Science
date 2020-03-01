using System;
namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<char> g1 = new Graph<char>();
            g1.AddVertex('N', 20);
            g1.AddVertex('B', 30);
            g1.AddVertex('A', 40);
            g1.AddVertex('F', 50);
            g1.AddVertex('D', 60);
            Console.WriteLine(g1.Contains('N'));
            try
            {
                g1.AddEdge('N', 'B');
                g1.AddEdge('A', 'T');
            }
            catch (VertexConnectionException vc)
            {
                Console.WriteLine(vc.Message);
            }

        }
    }
}
