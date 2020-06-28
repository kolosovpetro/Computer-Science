namespace CodeFirstCLI.Models
{
    public class Address
    {
        public int? AddressId { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int AptNumber { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        // navigational property for user living in current address
        public virtual User User { get; set; }
    }
}