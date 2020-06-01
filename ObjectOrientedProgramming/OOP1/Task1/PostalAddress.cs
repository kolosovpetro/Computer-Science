namespace Task1
{
    internal class PostalAddress
    {
        private string Street { get; set; }
        private string HouseNumber { get; set; }
        private string ApartmentNumber { get; set; }
        private string PostCode { get; set; }
        private string City { get; set; }
        private string Country { get; set; }

        public string AddressInPostalFormat =>
            Street + '/' +
            HouseNumber + '/' +
            ApartmentNumber + "\n" +
            City + "\n" +
            PostCode + "\n" +
            Country;

        public void SetData(string newStreet, string newHouseNumber, string newApartmentNumber,
            string newPostCode, string newCity, string newCountry)
        {
            Street = newStreet;
            HouseNumber = newHouseNumber;
            ApartmentNumber = newApartmentNumber;
            PostCode = newPostCode;
            City = newCity;
            Country = newCountry;
        }
    }
}