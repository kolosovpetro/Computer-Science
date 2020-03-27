using ActiveRecordPattern.DBActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern.CopyRecordEntity
{
    class CopyRecordDbEngine : IDbEngine
    {
        public string ConnectionString => throw new NotImplementedException();

        public void Insert(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Select(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
