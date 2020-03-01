using NUnit.Framework;

namespace Queue
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void TestOfIsEmpty()
        {
            Queue<string> q1 = new Queue<string>(5);
            q1.Enqueue("abc");
            Assert.That(q1.IsEmpty(), Is.EqualTo(false));
        }
        [Test]
        public void TestOfIsFull()
        {
            Queue<string> q1 = new Queue<string>(2);
            q1.Enqueue("abc");
            q1.Enqueue("abc1");
            Assert.That(q1.IsFull(), Is.EqualTo(true));
        }
        [Test]
        public void TestEnqueToLast()
        {
            Queue<string> q1 = new Queue<string>(5);
            q1.Enqueue("This is last item");
            Assert.That(q1.Peek(), Is.EqualTo("This is last item"));
        }
        [Test]
        public void NewTestEnqueToLast()
        {
            Queue<string> q1 = new Queue<string>(5);
            q1.Enqueue("This is item to be got");
            q1.Enqueue("This is almost last item");
            q1.Enqueue("This is last item");
            q1.Dequeue();
            q1.Dequeue();
            Assert.That(q1.Peek(), Is.EqualTo("This is item to be got"));
        }
        [Test]
        public void TestOfDequeue()
        {
            Queue<string> q1 = new Queue<string>(5);
            q1.Enqueue("This is last item");
            q1.Dequeue();
            Assert.That(q1.Peek(), Is.EqualTo(null));
        }

    }
}
