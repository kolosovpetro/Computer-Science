namespace FluentBuilder
{
    internal class Person
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public int Age { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public Person SetFirstname(string firstname)
        {
            Firstname = firstname;
            return this;
        }

        public Person SetLastname(string lastname)
        {
            Lastname = lastname;
            return this;
        }

        public Person SetAge(int age)
        {
            Age = age;
            return this;
        }

        public Person SetCity(string city)
        {
            City = city;
            return this;
        }

        public Person SetCounty(string country)
        {
            Country = country;
            return this;
        }

        public override string ToString()
        {
            return $"{Firstname}, {Lastname}, {Age}, {City}, {Country}";
        }
    }
}
