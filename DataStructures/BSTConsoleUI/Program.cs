using System;
using BinarySearchTree.Implementations;
using BinarySearchTree.Interfaces;

namespace BSTConsoleUI
{
    internal static class Program
    {
        private static void Main()
        {
            INode tree = new Node(50);
            
            // sub tree 1
            tree.Insert(72);
            tree.Insert(54);
            tree.Insert(76);
            tree.Insert(67);
            
            // sub tree 2
            tree.Insert(17);
            tree.Insert(12);
            tree.Insert(23);
            tree.Insert(9);
            tree.Insert(14);
            tree.Insert(19);
            
            tree.PrintSorted();
            tree.Delete(tree.Right);
            Console.WriteLine();
            tree.PrintSorted();
        }
    }
}