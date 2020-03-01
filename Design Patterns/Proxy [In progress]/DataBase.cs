using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class DataBase
    {
        string Address;
        string Port;
        string Login;
        string Password;
        string Query;
        Queue<DataBase> QueryQueue;

        public DataBase(string newAddress, string newPort, string newLogin, string newPassword)
        {
            this.Address = newAddress;
            this.Port = newPort;
            this.Login = newLogin;
            this.Password = newPassword;
            this.QueryQueue = new Queue<DataBase>();
        }

        public void Connect()
        {
            Console.WriteLine("Data base has been connected.");
        }
        public void Disconnect()
        {
            Console.WriteLine("Data base has been disconnected.");
        }
        public void AddQuery(string Query)
        {
            this.Query = Query;
        }
        public void AddToQueue()
        {
            QueryQueue.Enqueue(this);
        }
        public void ExecuteQuery()
        {
            Console.WriteLine($"Query: {this.Query} has been executed.");
        }
        public void ExecuteQueue()
        {
            for (int i = QueryQueue.Count - 1; i >= 0; i--)
            {
                QueryQueue.Peek().ExecuteQuery();
                QueryQueue.Dequeue();
            }
        }
    }
}
