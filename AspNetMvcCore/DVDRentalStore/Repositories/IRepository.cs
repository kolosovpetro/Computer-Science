using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DVDRentalStore.Repositories
{
    internal interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void Delete(IEnumerable<T> objects);

        // Get an entity by int id
        T GetById(int id);

        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);

        // Gets all entities of type T
        IEnumerable<T> GetAll();

        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        // Save changes
        void Save();
    }
}
