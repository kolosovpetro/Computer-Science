using System;

namespace PostgreDatabaseFirst.Models
{
    public partial class Rentals
    {
        public int CopyId { get; set; }
        public int ClientId { get; set; }
        public DateTime? DateOfRental { get; set; }
        public DateTime? DateOfReturn { get; set; }

        public virtual Clients Client { get; set; }
        public virtual Copies Copy { get; set; }

        public override string ToString()
        {
            return $"Copy id: {CopyId} - Client id: {ClientId} - {DateOfRental} - {DateOfReturn}";
        }
    }
}
