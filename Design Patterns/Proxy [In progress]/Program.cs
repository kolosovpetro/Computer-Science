using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            string Address = "wsb.poznan.pl";
            string Port = "1337";
            string Login = "admin";
            string Password = "admin";

            DataBase db1 = new DataBase(Address, Port, Login, Password);
            db1.Connect();
            db1.AddQuery("This is query 1");
            db1.AddToQueue();
            db1.AddQuery("This is query 2");
            db1.AddToQueue();
            db1.ExecuteQueue();
            db1.Disconnect();

            // result executes two similar queries since it is necessary to define new instance of object database instead
            // using this, but i'm lazy to do it for the moment :)
        }
    }
}
