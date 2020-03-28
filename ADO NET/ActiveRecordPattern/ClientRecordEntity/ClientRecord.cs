using System;

namespace ActiveRecordPattern.ClientRecordEntity
{
    class ClientRecord : IClientRecord
    {
        public int ClientId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime Birthday { get; private set; }

        public ClientRecord() { }

        public ClientRecord(int clientId, string firstName, string lastName, DateTime birthday)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"Client id: {ClientId}, Firstname: {FirstName}, Lastname: {LastName}, Birthday: {Birthday}";
        }

        public void SetBirthday(DateTime newBirthday)
        {
            Birthday = newBirthday;
        }

        public void SetClientId(int newId)
        {
            ClientId = newId;
        }

        public void SetFirstName(string newFirstName)
        {
            FirstName = newFirstName;
        }

        public void SetLastName(string newLastName)
        {
            LastName = newLastName;
        }
    }
}
