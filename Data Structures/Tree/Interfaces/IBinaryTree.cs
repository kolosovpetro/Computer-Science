namespace Trees.Interfaces
{
    interface IBinaryTree<T>
    {
        T LeftChildOf(T FatherData);
        T RightChildOf(T FatherData);
        bool HasLeft(T FatherData);
        bool HasRight(T FatherData);
    }
}
