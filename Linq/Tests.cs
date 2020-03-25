using NUnit.Framework;
using System.Linq;

namespace Linq
{
    [TestFixture]
    class Tests
    {
        ILinqLibrary<int> intMethods = new LinqMethods<int>();
        ILinqLibrary<string> stringMethods = new LinqMethods<string>();
        ILinqLibrary<char> charMethods = new LinqMethods<char>();

        [Test]
        public void TermCountTest()
        {
            int[] testArr = new int[] { 4, 4, 4, 5, 6 };
            Assert.That(intMethods.TermCount(testArr, 4), Is.EqualTo(3));

            string[] strArr = new string[] { "abc", "abd", "abc", "a", "b" };
            Assert.That(stringMethods.TermCount(strArr, "abc"), Is.EqualTo(2));
        }

        [Test]
        public void TestParseable()
        {
            string[] strArr = new string[] { "abc", "abd", "2", "a", "1" };
            Assert.That(stringMethods.Parseable(strArr), Is.EqualTo(new string[] { "2", "1" }));

            char[] charArr = new char[] { 'a', 'b', 'c', '2', '1', '0', 't' };
            Assert.That(charMethods.Parseable(charArr), Is.EqualTo(new char[] { '2', '1', '0' }));
        }

        [Test]
        public void SubsetTest()
        {
            char[] charArr = new char[] { 'a', 'b', 'c', '2', '1', '0', 't' };
            Assert.That(charMethods.Subset(charArr, 0, 3).ToArray(), Is.EqualTo(new char[] { 'a', 'b', 'c' }));
        }

        [Test]
        public void TestJoinCollections()
        {
            char[] c1 = new char[] { 'a', 'b', 'c', '2', '1', '0', 't' };
            char[] c2 = new char[] { 'a', 'b', 'c' };
            Assert.That(charMethods.JoinCollections(c1, c2).ToArray(), Is.EqualTo(new char[] { 'a', 'b', 'c', '2', '1', '0', 't', 'a', 'b', 'c' }));
        }

        [Test]
        public void TestRemoveItem()
        {
            char[] charArr = new char[] { 'a', 'b', 'c', 'a', 'a', '0', 't' };
            Assert.That(charMethods.RemoveAll(charArr, 'a'), Is.EqualTo(new char[] { 'b', 'c', '0', 't' }));
        }
    }
}
