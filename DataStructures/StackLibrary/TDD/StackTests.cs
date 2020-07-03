using System;
using FluentAssertions;
using NUnit.Framework;
using StackLibrary.Implementation;
using StackLibrary.Interfaces;

namespace StackLibrary.TDD
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void IsFullAndIsEmptyTest()
        {
            IStack<string> stack = new Stack<string>(10);
            stack.IsEmpty().Should().BeTrue();
            stack.IsFull().Should().BeFalse();
            stack.Capacity.Should().Be(10);
        }

        [Test]
        public void PushTest()
        {
            IStack<string> stack = new Stack<string>(2);
            stack.Push("new string");
            stack.Push("new string 2");
            stack.Count.Should().Be(2);
            stack.IsEmpty().Should().BeFalse();
            stack.IsFull().Should().BeTrue();

            Action act = () => stack.Push("new string 3");

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Stack is full");
        }

        [Test]
        public void PopTest()
        {
            IStack<string> stack = new Stack<string>(10);
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Push("D");
            stack.Count.Should().Be(4);
            stack.Pop().Should().Be("D");
            stack.Count.Should().Be(3);
            stack.Pop().Should().Be("C");
            stack.Count.Should().Be(2);
            stack.Pop().Should().Be("B");
            stack.Count.Should().Be(1);
            stack.Pop().Should().Be("A");
            stack.IsEmpty().Should().BeTrue();

            Action act = () => stack.Pop();

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Stack is empty");
        }

        [Test]
        public void ContainsTest()
        {
            IStack<string> stack = new Stack<string>(10);
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Push("D");

            stack.Contains("A").Should().BeTrue();
            stack.Contains("E").Should().BeFalse();
        }

        [Test]
        public void ClearTest()
        {
            IStack<string> stack = new Stack<string>(10);
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Push("D");
            stack.IsEmpty().Should().BeFalse();
            stack.Clear();
            stack.IsEmpty().Should().BeTrue();

            Action act = () => stack.Pop();

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Stack is empty");
        }

        [Test]
        public void PeekTest()
        {
            IStack<string> stack = new Stack<string>(10);
            Action act = () => stack.Peek();

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Stack is empty");
            
            stack.Push("A");
            stack.Push("B");
            stack.Peek().Should().Be("B");
            stack.IsEmpty().Should().BeFalse();
            stack.Count.Should().Be(2);
        }

        [Test]
        public void ToArrayTest()
        {
            IStack<string> stack = new Stack<string>(10);
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Push("D");

            var arr = stack.ToArray();
            arr.Length.Should().Be(4);
            arr[0].Should().Be("A");
            arr[1].Should().Be("B");
            arr[2].Should().Be("C");
            arr[3].Should().Be("D");
        }

        [Test]
        public void CopyToTest()
        {
            IStack<string> stack = new Stack<string>(10);
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Push("D");
            
            var arr = new string[10];
            stack.CopyTo(ref arr, 1);
            arr.Length.Should().Be(3);
            arr[0].Should().Be("B");
            arr[1].Should().Be("C");
            arr[2].Should().Be("D");
        }
    }
}