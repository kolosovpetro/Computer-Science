using ActiveRecordPattern.DataBaseContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern.RentalsRecordEntity
{
    class RentalsDbContext<T> : IConnectable, ISelectable<T>, IUpdateable<T>, IInsertable<T> where T : RentalsRecord
    {
        public string ConnectionString => throw new NotImplementedException();

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public T Select(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
