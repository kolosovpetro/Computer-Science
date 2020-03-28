using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern.RentalsRecordEntity
{
    class RentalsRecord : IRentalsRecord
    {
        public int CopyId { get; private set; }

        public int ClientId { get; private set; }

        public DateTime DateOfRental { get; private set; }

        public DateTime? DateOfReturn { get; private set; }

        public RentalsRecord() { }

        public RentalsRecord(int copyId, int clientId, DateTime dateOfRental, DateTime dateOfReturn)
        {
            CopyId = copyId;
            ClientId = clientId;
            DateOfRental = dateOfRental;
            DateOfReturn = dateOfReturn;
        }

        public void SetClientId(int newId)
        {
            ClientId = newId;
        }

        public void SetCopyId(int newId)
        {
            CopyId = newId;
        }

        public void SetDateOfRental(DateTime newDate)
        {
            DateOfRental = newDate;
        }

        public void SetDateOfReturn(DateTime newDate)
        {
            DateOfReturn = newDate;
        }
    }
}
