using System;
using System.Collections.Generic;

namespace PostgreDatabaseFirst
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public float? Salary { get; set; }
    }
}
