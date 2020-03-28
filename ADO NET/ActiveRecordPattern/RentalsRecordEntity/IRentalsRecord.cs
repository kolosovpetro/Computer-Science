using System;

namespace ActiveRecordPattern.RentalsRecordEntity
{
    interface IRentalsRecord
    {
        // properties

        int CopyId { get; }
        int ClientId { get; }
        DateTime DateOfRental { get; }
        DateTime? DateOfReturn { get; }

        // methods

        void SetCopyId(int newId);
        void SetClientId(int newId);
        void SetDateOfRental(DateTime newDate);
        void SetDateOfReturn(DateTime newDate);
    }
}
