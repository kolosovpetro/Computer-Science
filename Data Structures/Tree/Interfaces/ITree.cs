using System.Collections.Generic;

namespace Trees.Interfaces
{
    internal interface ITree<T>
    {
        T Root();
        void SetData(int NodeIndex, T Data);
        bool IsEmpty();
        T ParentOf(T Child);
        List<T> Children(T Father);
        bool IsInternal(T Node);
        bool IsExternal(T Node);
    }
}
