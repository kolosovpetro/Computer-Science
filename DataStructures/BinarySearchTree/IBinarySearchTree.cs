namespace BinarySearchTree
{
    internal interface IBinarySearchTree
    {
        int Value { get; }
        IBinarySearchTree Left { get; }
        IBinarySearchTree Right { get; }

        IBinarySearchTree Successor(IBinarySearchTree tree);
        IBinarySearchTree Predecessor(IBinarySearchTree tree);
        IBinarySearchTree Root();
        void SetLeft(IBinarySearchTree newLeft);
        void SetRight(IBinarySearchTree newRight);
        void Insert(IBinarySearchTree newTree);
    }
}
