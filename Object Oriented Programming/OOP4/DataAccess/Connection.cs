using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Connection: IConnection
    {
        
        protected Database database;
        protected bool isOpen;
        bool disposed = false;
        protected string password;
        protected string userName;

        IDatabase IConnection.Database { get;}

        public Connection(string newUserName, string newPassword)
        {
            this.userName = newUserName;
            this.password = newPassword;
        }

        public void Close()
        {                     
            if (isOpen == true)
            {
                this.isOpen = false;
            }
            else
            {
                throw new ConnectionClosedException("Connection was not opened");
            }            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if(disposing)
            {

            }
            disposed = true;
        }

        public string GetPassword()
        {            
            return this.password;            
        }

        public string GetUsername()
        {            
            return this.userName;
        }

        public bool IsOpen()
        {            
            if (isOpen == true)
            {
                Console.WriteLine("Open");
                return true;
            }
            else
            {
                Console.WriteLine("Closed");
                return false;
            }           
        }

        public void Open()
        {
            
            int loginValue;
            
            if (isOpen == true)
            {
                throw new ConnectionAlreadyOpenedException("Connection was already opened");
            }
            else
            {
                if (int.TryParse(this.userName, out loginValue) == true || int.TryParse(this.password, out loginValue) == false)
                {
                    throw new AuthenticationException();
                }
                else
                {
                    isOpen = true;
                }
            }           

        }
    }
}
