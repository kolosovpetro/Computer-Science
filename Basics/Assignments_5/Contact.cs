using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_5
{
    struct Contact
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly string phoneNumber;
        private readonly string emailAddress;
        public string FullData
        {
            get
            {
                return $"Firstname: {firstName}, Lastname: {lastName}, " +
                    $"Phone: {phoneNumber}, Email: {emailAddress}";
            }
        }

        public Contact(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this.FullData);
        }
    }
}
