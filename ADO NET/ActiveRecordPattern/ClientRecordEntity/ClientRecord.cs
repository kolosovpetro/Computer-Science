using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.CopyRecordEntity;
using System;
using System.Linq;

namespace ActiveRecordPattern.ClientRecordEntity
{
    internal class ClientRecord : IClientRecord
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
            return $"Client id: {ClientId}, " +
                $"Firstname: {FirstName}, " +
                $"Lastname: {LastName}, " +
                $"Birthday: {Birthday}";
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

        public void Rent(int movieId)
        {
            var copiesList = new CopyListDbContext()
                .Select(movieId).CopiesList;

            var copyDbCont = new CopyDbContext();

            var copyRecords = copiesList.ToList();

            if (copyRecords.Count == 0)
                throw new Exception("No available copies of this movie");

            copyRecords.ElementAt(0).SetAvailable(false);
            copyDbCont.Update(copyRecords.ElementAt(0));

        }
    }
}
