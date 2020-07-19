using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using DataAccess.Interfaces;

namespace DataAccess
{
    public sealed class Connection : IConnection
    {
        private Database Database;
        private bool _isOpen;
        bool _disposed;
        private readonly string _password;
        private readonly string _userName;
        private readonly IDatabase _database;

        IDatabase IConnection.Database => _database;

        public Connection(string newUserName, string newPassword, IDatabase database)
        {
            _userName = newUserName;
            _password = newPassword;
            _database = database;
        }

        public void Close()
        {
            if (_isOpen)
            {
                _isOpen = false;
            }
            else
            {
                throw new ConnectionClosedException("Connection was not opened");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {

            }
            _disposed = true;
        }

        public string GetPassword()
        {
            return _password;
        }

        public string GetUsername()
        {
            return _userName;
        }

        public bool IsOpen()
        {
            if (_isOpen)
            {
                Console.WriteLine("Open");
                return true;
            }

            Console.WriteLine("Closed");
            return false;
        }

        public void Open()
        {
            if (_isOpen)
            {
                throw new ConnectionAlreadyOpenedException("Connection was already opened");
            }

            if (int.TryParse(_userName, out _) || int.TryParse(_password, out _) == false)
            {
                throw new AuthenticationException();
            }

            _isOpen = true;

        }
    }
}
