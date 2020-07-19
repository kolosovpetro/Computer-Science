using System.Collections.Generic;

namespace DataMapperPattern.DataBaseContexts
{
    internal interface IIdentityMap<T>
    {
        IDictionary<int, T> CacheDictionary { get; }
        void UpdateCache(T entity);
    }
}
