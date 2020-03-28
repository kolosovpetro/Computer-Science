using NUnit.Framework;

namespace Queue.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void TestOfIsEmpty()
        {
            Queue<string> q1 = new Queue<string>(5);
            Assert.That(q1.IsEmpty(), Is.EqualTo(true));
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
        public void TestEnqueueToLast()
        {
            Queue<string> q1 = new Queue<string>(5);
            q1.Enqueue("This is last item");
            Assert.That(q1.Peek(), Is.EqualTo("This is last item"));
        }

        [Test]
        public void NewTestEnqueueToLast()
        {
            Queue<string> q1 = new Queue<string>(5);
            q1.Enqueue("This is item to be got");       // item 0
            q1.Enqueue("This is almost last item");     // item 1
            q1.Enqueue("This is last item");            // item 2

            q1.Dequeue();       // makes item 0 null
            q1.Dequeue();       // makes item 1 null

            Assert.That(q1.Peek(), Is.EqualTo("This is last item"));
        }

        [Test]
        public void TestOfDequeue()
        {
            Queue<string> q1 = new Queue<string>(5);
            q1.Enqueue("This is 0 item");
            q1.Enqueue("This is 1 item");
            q1.Enqueue("This is 2 item");
            q1.Enqueue("This is 3 item");
            q1.Enqueue("This is 4 item");

            q1.Dequeue();   // removes item 0

            Assert.That(q1.Peek(), Is.EqualTo("This is 1 item"));
            Assert.That(q1.Count, Is.EqualTo(5));
        }

    }
}
