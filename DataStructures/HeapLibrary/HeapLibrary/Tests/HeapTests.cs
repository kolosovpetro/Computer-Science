using System.Linq;
using FluentAssertions;
using HeapLibrary.Implementations;
using HeapLibrary.Interfaces;
using NUnit.Framework;

namespace HeapLibrary.Tests
{
    [TestFixture]
    public class HeapTests
    {
        [Test]
        public void HeapPushTest()
        {
            IBinaryHeap heap = new MaxBinaryHeap();
            heap.PushRange(1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17);
            heap.HeapBase.ToArray().SequenceEqual(new[] {17, 15, 10, 8, 13, 3, 6, 1, 5, 4, 9})
                .Should().BeTrue();
        }
    }
}