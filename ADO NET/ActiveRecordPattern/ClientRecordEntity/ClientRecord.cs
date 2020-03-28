﻿using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.CopyRecordEntity;
using System;
using System.Linq;
using ActiveRecordPattern.RentalsRecordEntity;

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
            ICopyListRecord copiesList = new CopyListDbContext()
                .Select(movieId);

            if (copiesList.AvailableCopiesCount == 0)
                throw new Exception("No available copies of this movie");

            var copyDbContext = new CopyDbContext();

            var availableCopy = copiesList.CopiesList.First(p => p.Available);             // store first available copy

            availableCopy.SetAvailable(false);           // set to available copy state: available - false

            copyDbContext.Update(availableCopy);                // update corresponding item in data base

            var rentalsDbContext = new RentalsDbContext();      // context for rentals DB

            var newRental = new RentalsRecord(availableCopy.CopyId, ClientId, DateTime.Now, DateTime.Now.AddDays(7));  // new rental

            rentalsDbContext.Insert(newRental);                 // insert new rental to data base     

        }
    }
}
