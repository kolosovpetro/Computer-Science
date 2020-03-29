using System;

namespace BinarySearchTree
{
    internal class Program
    {
        private static void Main()
        {
            BinSearchTree bst = new BinSearchTree(20);
            bst.Insert(new BinSearchTree(10));
            bst.Insert(new BinSearchTree(30));
            bst.Insert(new BinSearchTree(40));
            Console.WriteLine(bst.Left.Value);
            Console.WriteLine(bst.Right.Value);
            Console.WriteLine(bst.Right.Right.Value);
        }
    }
}
