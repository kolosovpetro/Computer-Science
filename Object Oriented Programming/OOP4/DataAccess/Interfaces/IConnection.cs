using System;
namespace DataAccess
{
    public interface IConnection: IDisposable
    {
        /// <summary>
        /// Opens connection to database
        /// Thrown exceptions:
        /// - ConnectionAlreadyOpenedException - Connection was already opened.
        /// - AuthenticationException - User passed incorrect login data (correct values are: username = "asdf", password = "123")
        /// </summary>
        void Open();

        /// <summary>
        /// Closes connection to database
        /// Thrown exceptions:
        /// - ConnectionClosedException - Connection was not opened.
        /// </summary>
        void Close();

        /// <summary>
        /// Info on connection status. True - open, false - closed.
        /// </summary>
        /// <returns>Connection status</returns>
        bool IsOpen();

        /// <summary>
        /// Info on user name.
        /// </summary>
        /// <returns>User name</returns>
        string GetUsername();

        /// <summary>
        /// Info on user password.
        /// </summary>
        /// <returns>Password</returns>
        string GetPassword();

        /// <summary>
        /// Database used in connection.
        /// </summary>
        IDatabase Database { get; }
    }
}