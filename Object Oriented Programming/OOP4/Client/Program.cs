using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnection newConnection = new Connection("dfdfdf", "4545");
            IConnection oldConnection = new Connection("dfdfdf", "4545");
            IDatabase database = new Database("family data");
            newConnection.Open();
            database.GetData(newConnection);
            database.GetData(oldConnection);
        }
    }
}
