using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DVDRentalStore.DAL;
using Microsoft.EntityFrameworkCore;

namespace DVDRentalStore.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties

        private RentalContext _rentalContext;    // database context
        private readonly DbSet<T> _dbSet;        // set of T objects in Db

        protected IDbFactory DbFactory
        {
            get;
        }

        protected RentalContext DbContext => _rentalContext ??= DbFactory.Init();

        #endregion

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }


        #region Implementations
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _rentalContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> @where)
        {
            var objects = _dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                _dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> @where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> @where)
        {
            return _dbSet.Where(where).ToList();
        }

        public void Save()
        {
            _rentalContext.SaveChanges();
        }

        #endregion
    }
}
