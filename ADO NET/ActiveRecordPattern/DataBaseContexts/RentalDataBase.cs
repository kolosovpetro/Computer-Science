namespace ActiveRecordPattern.DataBaseContexts
{
    internal abstract class RentalDataBase
    {
        protected string ConnectionString { get; }

        protected RentalDataBase()
        {
            ConnectionString = System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings["Rental"]
            .ToString();
        }
    }
}
