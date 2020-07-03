using DoubleLinkedListLibrary.Implementations;
using DoubleLinkedListLibrary.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace DoubleLinkedListLibrary.TDD
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void InitializationTest()
        {
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.Count.Should().Be(0);
            linkedList.First.Should().BeNull();
            linkedList.Last.Should().BeNull();
            linkedList.IsEmpty.Should().BeTrue();
        }

        [Test]
        public void AddFirstTest()
        {
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.First.Value.Should().Be("First node");
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Last.Should().Be(linkedList.First);
        }

        [Test]
        public void AddLastTest()
        {
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            linkedList.Last.Value.Should().Be("Last node");
            linkedList.First.Next.Value.Should().Be("Last node");
            linkedList.Last.Previous.Value.Should().Be("First node");
            linkedList.Count.Should().Be(2);
        }

        [Test]
        public void ContainsTest()
        {
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains("First node").Should().BeTrue();
            linkedList.First.Next.Should().Be(linkedList.Last);
            linkedList.First.Next.Value.Should().Be("Last node");
            linkedList.Last.Next.Should().BeNull();
            linkedList.Contains("Last node").Should().BeTrue();
            linkedList.Contains("Other data").Should().BeFalse();
        }

        [Test]
        public void FindTest()
        {
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            var find = linkedList.Find("Last node");
            find.Should().NotBeNull();
            find.Value.Should().Be("Last node");
        }

        [Test]
        public void AddAfterTest()
        {
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            var first = linkedList.First;
            linkedList.AddAfter(first, "Second node");
            linkedList.Count.Should().Be(3);
            linkedList.First.Next.Value.Should().Be("Second node");
            linkedList.Last.Previous.Value.Should().Be("Second node");
        }

        [Test]
        public void AddBeforeTest()
        {
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            var first = linkedList.First;
            linkedList.AddAfter(first, "Second node");
            var second = linkedList.Find("Second node");
            second.Should().NotBeNull();
            linkedList.AddBefore(second, "New second node");
            linkedList.Count.Should().Be(4);
            var newSecond = linkedList.Find("New second node");
            newSecond.Should().NotBeNull();
            newSecond.Previous.Should().Be(linkedList.First);
            newSecond.Next.Should().Be(second);
            second.Previous.Should().Be(newSecond);
            linkedList.First.Next.Should().Be(newSecond);
        }

        [Test]
        public void RemoveByValueTest()
        {
            // initialization
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            var first = linkedList.First;
            linkedList.AddAfter(first, "Second node");
            var second = linkedList.Find("Second node");
            linkedList.AddAfter(second, "Third node");
            var third = linkedList.Find("Third node");
            linkedList.Count.Should().Be(4);
            
            // removing
            linkedList.Remove("Second node");
            linkedList.Count.Should().Be(3);
            linkedList.First.Next.Should().Be(third);
            third.Previous.Should().Be(linkedList.First);
        }

        [Test]
        public void RemoveByReferenceTest()
        {
            // initialization
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            var first = linkedList.First;
            linkedList.AddAfter(first, "Second node");
            var second = linkedList.Find("Second node");
            linkedList.AddAfter(second, "Third node");
            var third = linkedList.Find("Third node");
            linkedList.Count.Should().Be(4);
            
            // removing
            linkedList.Remove(second);
            linkedList.Count.Should().Be(3);
            linkedList.First.Next.Should().Be(third);
            third.Previous.Should().Be(linkedList.First);
        }

        [Test]
        public void RemoveFirstTest()
        {
            // initialization
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            var first = linkedList.First;
            linkedList.AddAfter(first, "Second node");
            var second = linkedList.Find("Second node");
            linkedList.AddAfter(second, "Third node");
            var third = linkedList.Find("Third node");
            linkedList.Count.Should().Be(4);
            
            // removing
            linkedList.RemoveFirst();
            linkedList.Count.Should().Be(3);
            linkedList.First.Should().Be(second);
            linkedList.First.Next.Should().Be(third);
            third.Next.Should().Be(linkedList.Last);
            
            linkedList.RemoveFirst();
            linkedList.Count.Should().Be(2);
            linkedList.First.Should().Be(third);
            linkedList.First.Next.Should().Be(linkedList.Last);
            
            linkedList.RemoveFirst();
            linkedList.Count.Should().Be(1);
            linkedList.First.Should().Be(linkedList.Last);
            
            linkedList.RemoveFirst();
            linkedList.Count.Should().Be(0);
            linkedList.IsEmpty.Should().BeTrue();
            linkedList.First.Should().BeNull();
            linkedList.Last.Should().BeNull();

        }

        [Test]
        public void RemoveLastTest()
        {
            // initialization
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            var first = linkedList.First;
            linkedList.AddAfter(first, "Second node");
            var second = linkedList.Find("Second node");
            linkedList.AddAfter(second, "Third node");
            var third = linkedList.Find("Third node");
            linkedList.Count.Should().Be(4);
            
            // removing
            linkedList.RemoveLast();
            linkedList.Count.Should().Be(3);
            linkedList.Last.Should().Be(third);

            linkedList.RemoveLast();
            linkedList.Count.Should().Be(2);
            linkedList.Last.Should().Be(second);
            
            linkedList.RemoveLast();
            linkedList.Count.Should().Be(1);
            linkedList.Last.Should().Be(linkedList.First);
            
            linkedList.RemoveLast();
            linkedList.Count.Should().Be(0);
            linkedList.IsEmpty.Should().BeTrue();
            linkedList.First.Should().BeNull();
            linkedList.Last.Should().BeNull();
        }

        [Test]
        public void ClearTest()
        {
            // initialization
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            var first = linkedList.First;
            linkedList.AddAfter(first, "Second node");
            var second = linkedList.Find("Second node");
            linkedList.AddAfter(second, "Third node");
            var third = linkedList.Find("Third node");
            linkedList.Count.Should().Be(4);
            
            // clear
            linkedList.Clear();
            linkedList.IsEmpty.Should().BeTrue();
            linkedList.Count.Should().Be(0);
            linkedList.Last.Should().BeNull();
            linkedList.First.Should().BeNull();
            linkedList.Last.Should().BeNull();
        }

        [Test]
        public void CopyToTest()
        {
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("First node");
            linkedList.AddLast("Last node");
            var first = linkedList.First;
            linkedList.AddAfter(first, "Second node");
            var second = linkedList.Find("Second node");
            linkedList.AddAfter(second, "Third node");
            linkedList.Count.Should().Be(4);

            var arr = new string[10];
            linkedList.CopyTo(ref arr, 1);
            arr.Should().NotBeNull();
            arr.Length.Should().BeGreaterThan(0);
            arr[0].Should().Be("Second node");
            arr[1].Should().Be("Third node");
            arr[2].Should().Be("Last node");

        }

        [Test]
        public void FindLastTest()
        {
            ILinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("A");
            
            linkedList.AddLast("C");
            
            var first = linkedList.First;
            
            // first B
            linkedList.AddAfter(first, "B");
            var second = linkedList.Find("B");
            
            // second B
            linkedList.AddAfter(second, "B");
            linkedList.Count.Should().Be(4);

            var findLast = linkedList.FindLast("B");
            findLast.Next.Should().Be(linkedList.Last);

        }
    }
}