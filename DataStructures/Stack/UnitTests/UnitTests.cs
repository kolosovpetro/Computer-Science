using NUnit.Framework;
using Stack.Exceptions;

namespace Stack.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void TestOfIsEmpty()
        {
            Stack<string> s1 = new Stack<string>(0);
            Assert.That(s1.IsEmpty, Is.EqualTo(true));
        }

        [Test]
        public void TestOfIsFull()
        {
            Stack<string> s1 = new Stack<string>(2);
            s1.Push("entry 1");
            s1.Push("entry 2");
            Assert.That(s1.IsFull, Is.EqualTo(true));
        }
        [Test]
        public void TestOfPeek()
        {
            Stack<string> s1 = new Stack<string>(2);
            s1.Push("entry 1");
            s1.Push("entry 2");
            Assert.That(s1.Peek, Is.EqualTo("entry 2"));
        }
        [Test]
        public void TestOfPop()
        {
            Stack<string> s1 = new Stack<string>(5);
            s1.Push("entry 1");
            s1.Push("entry 2");
            s1.Push("entry 3");
            s1.Pop();
            s1.Pop();
            Assert.That(s1.Peek, Is.EqualTo("entry 1"));
        }
        [Test]
        public void TestOfStackIsFullException()
        {
            Stack<string> myStack = new Stack<string>(1);
            myStack.Push("entry 1");
            Assert.Throws<StackIsFullException>(() => myStack.Push("entry 2"));
        }
        [Test]
        public void TestOfStackIsEmptyException()
        {
            Stack<string> myStack = new Stack<string>(0);
            Assert.Throws<StackIsEmptyException>(() => myStack.Peek());
        }
        [Test]
        public void TestOfClear()
        {
            Stack<string> s1 = new Stack<string>(2);
            s1.Push("entry 1");
            s1.Push("entry 2");
            s1.Clear();
            Assert.That(s1.IsEmpty, Is.EqualTo(true));
        }
        [Test]
        public void TestOfContains()
        {
            Stack<string> s1 = new Stack<string>(2);
            s1.Push("entry 1");
            s1.Push("entry 2");
            Assert.That(s1.Contains("entry 1"), Is.EqualTo(true));
        }
        [Test]
        public void TestOfTrimExcess()
        {
            Stack<string> s1 = new Stack<string>(5);
            s1.Push("entry 1");
            s1.Push("entry 2");
            s1.Push("entry 3");
            s1.TrimExcess();
            Assert.That(s1.Count, Is.EqualTo(3));
        }
    }
}
