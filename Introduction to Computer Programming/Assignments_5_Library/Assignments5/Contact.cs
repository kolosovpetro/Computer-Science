using System;

namespace Assignments5
{
    public struct Contact
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _phoneNumber;
        private readonly string _emailAddress;

        public string FullData =>
            $"Firstname: {_firstName}, Lastname: {_lastName}, " +
            $"Phone: {_phoneNumber}, Email: {_emailAddress}";

        public Contact(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _emailAddress = emailAddress;
        }

        public void DisplayInfo()
        {
            Console.WriteLine(FullData);
        }
    }
}
