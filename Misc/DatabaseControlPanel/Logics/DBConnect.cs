using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControlPanel
{
    public class DBConnect
    {
        public string Host { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Database { get; private set; }
        public NpgsqlConnection Connection { get; private set; }

        public DBConnect(string newHost, string newUsername, string newPassword, string newDatabase)
        {
            this.Host = $"Host={newHost};";
            this.Username = $"Username={newUsername};";
            this.Password = $"Password={newPassword};";
            this.Database = $"Database={newDatabase}";

            this.Connection = new NpgsqlConnection(Host + Username + Password + Database);
        }

        public NpgsqlDataReader ExecuteQuery(string Query)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(Query, this.Connection);
            NpgsqlDataReader Result = cmd.ExecuteReader();
            return Result;
        }
    }
}
