﻿namespace ActiveRecordPattern.DataBaseContexts
{
    abstract class RentalDataBase
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
