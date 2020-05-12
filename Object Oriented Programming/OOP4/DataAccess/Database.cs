using System.Collections.Generic;
using DataAccess.Exceptions;
using DataAccess.Interfaces;


namespace DataAccess
{

    public struct PersonInfo
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        
        public PersonInfo(int newId, string newFirstName, string newLastName)
        {
            _id = newId;
            _firstName = newFirstName;
            _lastName = newLastName;
        }
    }
    public class Database: IDatabase
    {
        private readonly string _name;

        public Database(string newName)
        {
            _name = newName;
        }


        public IConnection GetNewConnection(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public List<Dictionary<string, object>> GetData(IConnection connection)
        {
            
            List<Dictionary<string,object>> outputData = new List<Dictionary<string, object>>();       
            
            if (connection.IsOpen() == false)
            {
                throw new ConnectionClosedException();
            }

            var persons = new Dictionary<string, object>();

            for (int i = 0; i < 10; i++)
            {
                persons.Add($"{i}", new PersonInfo(i, $"First_name_{i}", $"Last_name_{i}"));
            }
            outputData.Add(persons);
            return outputData;
        }

        
        public string GetDatabaseName()
        {
            return _name;
        }

      
        public IConnection GetNewConnection(string userName, string password, Database db)
        {
            var getNewConnection = new Connection(userName, password, db);
            return getNewConnection;
        }

        
    }
}
