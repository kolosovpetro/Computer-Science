using System;
using FluentAssertions;
using NUnit.Framework;
using QueueLibrary.Implementations;
using QueueLibrary.Interfaces;

namespace QueueLibrary.TDD
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void IsEmptyAndIsFullTest()
        {
            IQueue<string> queue = new Queue<string>(10);
            queue.IsEmpty().Should().BeTrue();
            queue.IsFull().Should().BeFalse();
            queue.Count.Should().Be(0);
            queue.Capacity.Should().Be(10);
        }
        
        [Test]
        public void EnqueueTest()
        {
            IQueue<string> queue = new Queue<string>(3);
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");
            queue.IsEmpty().Should().BeFalse();
            queue.Count.Should().Be(3);

            Action act = () => queue.Enqueue("D");
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Queue is full");
        }
        
        [Test]
        public void DequeueTest()
        {
            IQueue<string> queue = new Queue<string>(3);
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");
            queue.IsEmpty().Should().BeFalse();
            queue.Count.Should().Be(3);

            var obj1 = queue.Dequeue();
            var obj2 = queue.Dequeue();
            var obj3 = queue.Dequeue();

            obj1.Should().Be("A");
            obj2.Should().Be("B");
            obj3.Should().Be("C");

            Action act = () => queue.Dequeue();
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Queue is empty");
        }

        [Test]
        public void PeekTest()
        {
            IQueue<string> queue = new Queue<string>(3);
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");
            queue.Peek().Should().Be("A");
            queue.Dequeue();
            queue.Dequeue();
            queue.Peek().Should().Be("C");
            queue.Dequeue();

            Action act = () => queue.Peek();
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Queue is empty");
        }

        [Test]
        public void ContainsTest()
        {
            IQueue<string> queue = new Queue<string>(3);
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            queue.Contains("B").Should().BeTrue();
            queue.Contains("D").Should().BeFalse();
        }

        [Test]
        public void ClearTest()
        {
            IQueue<string> queue = new Queue<string>(3);
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");
            queue.IsEmpty().Should().BeFalse();
            queue.Count.Should().Be(3);
            
            queue.Clear();
            queue.IsEmpty().Should().BeTrue();
            queue.Count.Should().Be(0);
        }

        [Test]
        public void ToArrayTest()
        {
            IQueue<string> queue = new Queue<string>(3);
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            var arr = queue.ToArray();
            arr[0].Should().Be("A");
            arr[1].Should().Be("B");
            arr[2].Should().Be("C");
        }

        [Test]
        public void CopyToTest()
        {
            IQueue<string> queue = new Queue<string>(3);
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            var arr = new string[10];
            queue.CopyTo(ref arr, 1);
            arr[0].Should().Be("B");
            arr[1].Should().Be("C");
        }
    }
}