using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Person
    {
        string firstName;
        string familyName;

        public string FirstName { get { return firstName; } private set { firstName = value; } }
        public string FamilyName { get { return familyName; } private set { familyName = value; } }
        public PostalAddress Adress { get; private set; }

        public string IntroduceYourself()
        {
            return "My name is: " + this.FirstName + " " + this.FamilyName + "\n" + Adress.AddressInPostalFormat;

        }
        public void SetData(string newFirstName, string newFamilyName, string newStreet, string newHouseNumber, string newApartmentNumber, string newPostCode, string newCity, string newCountry)//string newStreet,string newHouseNumber,string newApartmentNumber, string newPostCode,string newCity,string newCountry)
        {
            this.FirstName = newFirstName;
            this.FamilyName = newFamilyName;
            Adress = new PostalAddress();
            this.Adress.SetData(newStreet, newHouseNumber, newApartmentNumber, newPostCode, newCity, newCountry);
        }

    }
}
