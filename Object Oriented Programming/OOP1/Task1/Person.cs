namespace Task1
{
    internal class Person
    {
        private string FirstName { get; set; }
        private string FamilyName { get; set; }
        private PostalAddress Address { get; set; }

        public string IntroduceYourself()
        {
            return "My name is: " + FirstName + " " + FamilyName + "\n" + Address.AddressInPostalFormat;
        }

        public void SetData(string newFirstName, string newFamilyName, string newStreet, string newHouseNumber,
            string newApartmentNumber, string newPostCode, string newCity,
            string newCountry)
        {
            FirstName = newFirstName;
            FamilyName = newFamilyName;
            Address = new PostalAddress();
            Address.SetData(newStreet, newHouseNumber, newApartmentNumber, newPostCode, newCity, newCountry);
        }
    }
}