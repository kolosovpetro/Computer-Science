using NUnit.Framework;

namespace Trees.UnitTests
{
    [TestFixture]
    class TreeTests
    {
        char[] Data = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K' };
        int[] Parents = new int[] { 0, 0, 0, 0, 1, 1, 2, 2, 5, 5, 5 };
        [Test]
        public void TestOfRoot()
        {
            Tree<char> bt1 = new Tree<char>(Data, Parents);
            Assert.That(bt1.Root(), Is.EqualTo('A'));
        }
        [Test]
        public void TestOfSetData()
        {
            Tree<char> bt1 = new Tree<char>(Data, Parents);
            bt1.SetData(3, 'B');
            Assert.That(bt1.GetNodeByIndex(3), Is.EqualTo('B'));
        }
        [Test]
        public void TestOfIsEmpty()
        {
            Tree<string> bt1 = new Tree<string>(Parents);
            bt1.SetData(0, "This is ROOT");
            Assert.That(bt1.IsEmpty, Is.EqualTo(false));
        }
        [Test]
        public void TestOfParent()
        {
            Tree<char> bt1 = new Tree<char>(Data, Parents);
            char Parent = bt1.ParentOf('E');
            Assert.That(Parent, Is.EqualTo('B'));
        }
        [Test]
        public void TestOfChildren()
        {
            Tree<char> bt1 = new Tree<char>(Data, Parents);
            var Children = bt1.Children('F');
            Assert.That(Children.Count, Is.EqualTo(3));
            Assert.That(Children[0], Is.EqualTo('I'));
            Assert.That(Children[1], Is.EqualTo('J'));
            Assert.That(Children[2], Is.EqualTo('K'));
        }
        [Test]
        public void TestOfIsInternal()
        {
            Tree<char> bt1 = new Tree<char>(Data, Parents);
            Assert.That(bt1.IsInternal('B'), Is.EqualTo(true));
        }
        [Test]
        public void TestOfIsExternal()
        {
            Tree<char> bt1 = new Tree<char>(Data, Parents);
            Assert.That(bt1.IsExternal('F'), Is.EqualTo(false));
        }
    }
}
