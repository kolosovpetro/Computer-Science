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
        public readonly DbSet<T> DbSet;        // set of T objects in Db

        protected IDbFactory DbFactory
        {
            get;
        }

        protected RentalContext DbContext => _rentalContext ??= DbFactory.Init();

        #endregion

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            DbSet = DbContext.Set<T>();
        }


        #region Implementations
        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            _rentalContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> @where)
        {
            var objects = DbSet.Where(where).AsEnumerable();
            DbSet.RemoveRange(objects);
        }

        public void Delete(IEnumerable<T> objects)
        {
            DbSet.RemoveRange(objects);
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> @where)
        {
            return DbSet.Where(where).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> @where)
        {
            return DbSet.Where(where).ToList();
        }

        public void Save()
        {
            _rentalContext.SaveChanges();
        }

        #endregion
    }
}
