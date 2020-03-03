using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{

    public struct PersonInfo
    {
        public int ID;
        public string firstName;
        public string lastName;
        public PersonInfo(int newId, string newFirstName, string newLastName)
        {
            ID = newId;
            firstName = newFirstName;
            lastName = newLastName;
        }
    }
    public class Database: IDatabase
    {
        protected string name;

        public Database(string newName)
        {
            this.name = newName;
        }


        public List<Dictionary<string, object>> GetData(IConnection connection)
        {
            
            List<Dictionary<string,object>> outputData = new List<Dictionary<string, object>>();       
            
            if (connection.IsOpen() == false)
            {
                throw new ConnectionClosedException();
            }
            else
            {
                var persons = new Dictionary<string, object>();

                for (int i = 0; i < 10; i++)
                {
                    persons.Add($"{i}", new PersonInfo(i, $"First_name_{i}", $"Last_name_{i}"));
                }
                outputData.Add(persons);
                return outputData;
            }
        }

        
        public string GetDatabaseName()
        {
            return this.name;
        }

      
        public IConnection GetNewConnection(string userName, string password)
        {
            Connection getNewConnecttion = new Connection(userName, password);
            return getNewConnecttion;
        }

        
    }
}
