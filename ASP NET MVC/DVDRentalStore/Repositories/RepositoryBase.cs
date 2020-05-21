using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DVDRentalStore.DAL;
using DVDRentalStore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DVDRentalStore.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {

        private RentalContext _rentalContext;
        private readonly DbSet<T> _dbSet;

        protected IDbFactory DbFactory { get; }

        protected RentalContext DbContext => _rentalContext ??= DbFactory.Init();

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }


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
            _dbSet.RemoveRange(objects);
        }

        public void Delete(IEnumerable<T> objects)
        {
            _dbSet.RemoveRange(objects);
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
    }
}
