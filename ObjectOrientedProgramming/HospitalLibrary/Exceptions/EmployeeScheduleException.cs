using System;

namespace HospitalLibrary.Exceptions
{
    public class EmployeeScheduleException : Exception
    {
        public EmployeeScheduleException(string message) : base(message)
        {
        }
    }
}