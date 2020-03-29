using NUnit.Framework;
using Trees.Trees;

namespace Trees.UnitTests
{
    [TestFixture]
    internal class TreeTests
    {
        private readonly char[] _data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K' };
        private readonly int[] _parents = { 0, 0, 0, 0, 1, 1, 2, 2, 5, 5, 5 };

        [Test]
        public void TestOfRoot()
        {
            var bt1 = new Tree<char>(_data, _parents);
            Assert.That(bt1.Root(), Is.EqualTo('A'));
        }

        [Test]
        public void TestOfSetData()
        {
            var bt1 = new Tree<char>(_data, _parents);
            bt1.SetData(3, 'B');
            Assert.That(bt1.GetNodeByIndex(3), Is.EqualTo('B'));
        }

        [Test]
        public void TestOfIsEmpty()
        {
            var bt1 = new Tree<string>(_parents);
            bt1.SetData(0, "This is ROOT");
            Assert.That(bt1.IsEmpty, Is.EqualTo(false));
        }

        [Test]
        public void TestOfParent()
        {
            var bt1 = new Tree<char>(_data, _parents);
            char parent = bt1.ParentOf('E');
            Assert.That(parent, Is.EqualTo('B'));
        }

        [Test]
        public void TestOfChildren()
        {
            var bt1 = new Tree<char>(_data, _parents);
            var children = bt1.Children('F');
            Assert.That(children.Count, Is.EqualTo(3));
            Assert.That(children[0], Is.EqualTo('I'));
            Assert.That(children[1], Is.EqualTo('J'));
            Assert.That(children[2], Is.EqualTo('K'));
        }

        [Test]
        public void TestOfIsInternal()
        {
            var bt1 = new Tree<char>(_data, _parents);
            Assert.That(bt1.IsInternal('B'), Is.EqualTo(true));
        }

        [Test]
        public void TestOfIsExternal()
        {
            var bt1 = new Tree<char>(_data, _parents);
            Assert.That(bt1.IsExternal('F'), Is.EqualTo(false));
        }
    }
}
