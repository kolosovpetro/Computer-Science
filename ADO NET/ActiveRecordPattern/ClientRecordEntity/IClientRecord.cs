using System;

namespace ActiveRecordPattern.ClientRecordEntity
{
    interface IClientRecord
    {
        // properties

        int ClientId { get; }
        string FirstName { get; }
        string LastName { get; }
        DateTime Birthday { get; }

        // methods

        void SetClientId(int newId);
        void SetFirstName(string newFirstName);
        void SetLastName(string newLastName);
        void SetBirthday(DateTime newBirthday);
        void Rent(int movieId);
    }
}
