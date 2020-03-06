using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class PostalAddress
    {
        public string Street { get; private set; }
        public string HouseNumber { get; private set; }
        public string ApartmentNumber { get; private set; }
        public string PostCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public string AddressInPostalFormat
        {
            get
            {
                //returns all information in nice, clear way
                return  this.Street + '/' + 
                        this.HouseNumber + '/' + 
                        this.ApartmentNumber + "\n" +
                        this.City + "\n" +
                        this.PostCode + "\n" +
                        this.Country;
            }
        }

        public void SetData(string newStreet, string newHouseNumber, string newApartmentNumber, string newPostCode, string newCity, string newCountry)
        {
            this.Street = newStreet;
            this.HouseNumber = newHouseNumber;
            this.ApartmentNumber = newApartmentNumber;
            this.PostCode = newPostCode;
            this.City = newCity;
            this.Country = newCountry;
        }

    }
}


    

