using System.Collections.Generic;
namespace DataAccess
{
    public interface IDatabase
    {
        /// <summary>
        /// Creates and opens connection to database.
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>New connection to database</returns>
        IConnection GetNewConnection(string userName, string password);

        /// <summary>
        /// Retrieves data from database.
        /// Thrown exceptions:
        /// - ConnectionClosedException - Attempt to retieve data from a closed connection.
        /// </summary>
        /// <param name="connection">Connection to database</param>
        /// <returns>Dane
        /// Data is retrieved as ten dictonaries. Each contains 3 keys: IdNumber, FirstName, FamilyName.
        /// Subsequent keys values are:
        /// - idNumber (int): subsequent numbers from 0 to 9
        /// - firstName (string): First_name_0, First_name_1, ..., First_name_9
        /// - familyName (string): Family_name_0, Family_name_1, ..., Family_name_9</returns>
        List<Dictionary<string, object>> GetData(IConnection connection);

        /// <summary>
        /// Returns database.
        /// </summary>
        /// <returns>Database name.</returns>
        string GetDatabaseName();
    }
}
