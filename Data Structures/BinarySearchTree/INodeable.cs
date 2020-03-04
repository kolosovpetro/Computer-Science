using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    interface INodeable<T>
    {
        T Key { get; }
        int Value { get; }
        INodeable<T> Left { get; }
        INodeable<T> Right { get; }
    }
}
