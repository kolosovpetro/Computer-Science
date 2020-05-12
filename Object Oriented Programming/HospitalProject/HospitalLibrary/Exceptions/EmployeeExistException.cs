using System;

namespace HospitalLibrary.Exceptions
{
    public class EmployeeExistException : Exception
    {
        public EmployeeExistException(string message) : base(message)
        {
        }
    }
}