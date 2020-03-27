using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern.DBActions
{
    interface IDbEngine
    {
        string ConnectionString { get; }

        // methods

        void Insert(IEntity entity);
        void Update(IEntity entity);
        IEntity Select(int id);
    }
}
