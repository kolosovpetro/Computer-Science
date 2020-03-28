using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.CopyRecordEntity;
using System;
using System.Collections.Generic;
using System.Linq;

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
            IEnumerable<ICopyRecord> copiesList = new CopyListDbContext()
                .Select(movieId).CopiesList;
            var copyDbCont = new CopyDbContext();

            if (copiesList.Count() != 0)
            {
                copiesList.ElementAt(0).SetAvailable(false);
                copyDbCont.Update(copiesList.ElementAt(0));
                return;
            }

            throw new Exception("No available copies of this movie");
        }
    }
}
