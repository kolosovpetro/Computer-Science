using System;
using System.Collections.Generic;

namespace DVDRentalStore.Models
{
    public partial class EmployeesModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public float? Salary { get; set; }
    }
}
