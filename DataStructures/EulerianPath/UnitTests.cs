using System.Linq;
using FluentAssertions;
using GraphLibrary.Implementations;
using NUnit.Framework;

namespace EulerianPath
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void NodeDegreeTest()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            var ab = new Edge(a, b);
            var bc = new Edge(b, c);
            var ca = new Edge(c, a);
            var ad = new Edge(a, d);
            
            var graph = new Graph(ab, bc, ca, ad);
            a.Degree.Should().Be(3);
            b.Degree.Should().Be(2);
            c.Degree.Should().Be(2);
            d.Degree.Should().Be(1);
        }

        [Test]
        public void GraphVerticesTest()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            var ab = new Edge(a, b);
            var bc = new Edge(b, c);
            var ca = new Edge(c, a);
            var ad = new Edge(a, d);
            
            var graph = new Graph(ab, bc, ca, ad);
            graph.Vertices.Count().Should().Be(4);
            graph.Vertices.ElementAt(0).Should().Be(a);
            graph.Vertices.ElementAt(1).Should().Be(b);
            graph.Vertices.ElementAt(2).Should().Be(c);
            graph.Vertices.ElementAt(3).Should().Be(d);
        }

        [Test]
        public void GraphIsValidTest()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            var ab = new Edge(a, b);
            var bc = new Edge(b, c);
            var ca = new Edge(c, a);
            //var ad = new Edge(a, d);
            
            var graph = new Graph(ab, bc, ca);
            var euler = new EulerianPathBuilder(graph);
            euler.GraphIsValid().Should().BeTrue();
            euler.GetStartEdge().Should().Be(ab);
        }

        [Test]
        public void NumberOfOddVerticesTest()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            var ab = new Edge(a, b);
            var bc = new Edge(b, c);
            var ca = new Edge(c, a);
            var ad = new Edge(a, d);
            
            var graph = new Graph(ab, bc, ca, ad);
            var euler = new EulerianPathBuilder(graph);
            euler.OddVerticesNumber().Should().Be(2);
        }

        [Test]
        public void IsBridgeTest()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            var ab = new Edge(a, b);
            var bc = new Edge(b, c);
            var ca = new Edge(c, a);
            var ad = new Edge(a, d);
            
            var graph = new Graph(ab, bc, ca, ad);
            var euler = new EulerianPathBuilder(graph);
            euler.IsBridge(ab).Should().BeFalse();
            euler.IsBridge(bc).Should().BeFalse();
            euler.IsBridge(ca).Should().BeFalse();
            euler.IsBridge(ad).Should().BeTrue();
        }

        [Test]
        public void GetFirstEdgeTest()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            var ab = new Edge(a, b);
            var bc = new Edge(b, c);
            var ca = new Edge(c, a);
            var ad = new Edge(a, d);
            
            var graph = new Graph(ab, bc, ca, ad);
            var euler = new EulerianPathBuilder(graph);
            euler.GetStartEdge().Should().Be(ab);
        }
        
        [Test]
        public void NeighborEdgesTest()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            var ab = new Edge(a, b);
            var bc = new Edge(b, c);
            var ca = new Edge(c, a);
            var ad = new Edge(a, d);
            
            var graph = new Graph(ab, bc, ca, ad);
            var euler = new EulerianPathBuilder(graph);
            var neighborEdges = euler.NeighborEdges(a).ToList();
            neighborEdges.Count.Should().Be(2);
            neighborEdges.ElementAt(0).Should().Be(ab);
            neighborEdges.ElementAt(1).Should().Be(ad);
        }

        [Test]
        public void HasEulerianPathTest()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            var ab = new Edge(a, b);
            var bc = new Edge(b, c);
            var ca = new Edge(c, a);
            var ad = new Edge(a, d);
            var dc = new Edge(d, c);
            
            var graph = new Graph(ab, bc, ca, ad, dc);
            var euler = new EulerianPathBuilder(graph);
            euler.HasEulerianPath().Should().BeTrue();
        }
    }
}