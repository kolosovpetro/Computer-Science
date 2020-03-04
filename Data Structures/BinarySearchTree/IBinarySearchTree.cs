namespace BinarySearchTree
{
    interface IBinarySearchTree
    {
        int Value { get; }
        IBinarySearchTree Left { get; }
        IBinarySearchTree Right { get; }

        IBinarySearchTree Successor();
        IBinarySearchTree Predecessor();
        IBinarySearchTree Root();
        void SetLeft(IBinarySearchTree newLeft);
        void SetRight(IBinarySearchTree newRight);
        void Insert(IBinarySearchTree newTree);
    }
}
