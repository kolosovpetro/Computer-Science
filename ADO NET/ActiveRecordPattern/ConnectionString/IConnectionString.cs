using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern.ConnectionString
{
    interface IConnectionString
    {
        string ConnectionString { get; }
    }
}
