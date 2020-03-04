using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void InsertTest()
        {
            BinSearchTree bst = new BinSearchTree(20);
            bst.Insert(new BinSearchTree(10));
            bst.Insert(new BinSearchTree(30));
            bst.Insert(new BinSearchTree(40));

            Assert.That(bst.Left.Value, Is.EqualTo(10));
            Assert.That(bst.Right.Value, Is.EqualTo(30));
            Assert.That(bst.Right.Right.Value, Is.EqualTo(40));
        }

        [Test]
        public void SuccessorTest()
        {
            BinSearchTree bst = new BinSearchTree(20);
            bst.Insert(new BinSearchTree(10));
            bst.Insert(new BinSearchTree(30));
            bst.Insert(new BinSearchTree(25));

            Assert.That(bst.Successor(bst).Value, Is.EqualTo(25));
        }
    }
}
