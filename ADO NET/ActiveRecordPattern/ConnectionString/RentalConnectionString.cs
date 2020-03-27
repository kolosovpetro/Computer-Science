namespace ActiveRecordPattern.ConnectionString
{
    class RentalConnectionString : IConnectionString
    {
        public string ConnectionString { get; }

        public RentalConnectionString()
        {
            ConnectionString = System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings["Rental"]
            .ToString();
        }
    }
}
