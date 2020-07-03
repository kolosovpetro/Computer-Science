using System.Collections.Generic;

namespace TreeLibrary.Interfaces
{
    public interface ITree
    {
        INode Root();
        int Count();
        bool IsEmpty();
        INode Parent(INode child);
        IEnumerable<INode> Children(INode parent);
        bool IsInternal(INode node);
        bool IsExternal(INode node);
        int Depth(INode node);
        int Height(INode node);
    }
}