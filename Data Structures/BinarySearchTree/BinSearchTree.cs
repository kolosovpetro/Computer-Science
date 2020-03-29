using System;

namespace BinarySearchTree
{
    internal class BinSearchTree : IBinarySearchTree
    {
        public int Value { get; }

        public IBinarySearchTree Left { get; private set; }

        public IBinarySearchTree Right { get; private set; }

        public BinSearchTree(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public IBinarySearchTree Root()
        {
            return this;
        }

        public void SetLeft(IBinarySearchTree newLeft)
        {
            Left = newLeft;
        }

        public void SetRight(IBinarySearchTree newRight)
        {
            Right = newRight;
        }

        public void Insert(IBinarySearchTree newTree)
        {
            var s = Root();

            while (true)
            {
                if (s.Value >= newTree.Value && s.Left != null)
                {
                    s = s.Left;
                    continue;
                }

                if (s.Value >= newTree.Value && s.Left == null)
                {
                    s.SetLeft(newTree);
                    break;
                }

                if (s.Value <= newTree.Value && s.Right != null)
                {
                    s = s.Right;
                    continue;
                }

                if (s.Value <= newTree.Value && s.Right == null)
                {
                    s.SetRight(newTree);
                    break;
                }


            }
        }

        public IBinarySearchTree Successor(IBinarySearchTree tree)
        {
            IBinarySearchTree s = tree;
            int step = default;

            while (true)
            {
                if (step % 2 == 0 && s.Right != null)
                {
                    s = s.Right;
                    step++;
                    continue;
                }

                if(step % 2 != 0 && s.Left != null)
                {
                    s = s.Left;
                    step++;
                    continue;
                }

                return s;
            }
        }

        public IBinarySearchTree Predecessor(IBinarySearchTree tree)
        {
            throw new NotImplementedException();
        }
    }
}
