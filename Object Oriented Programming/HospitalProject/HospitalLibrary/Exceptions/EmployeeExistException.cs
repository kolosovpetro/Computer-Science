using System;

namespace HospitalLibrary
{
    public class EmployeeExistException : Exception
    {
        public EmployeeExistException()
        {

        }

        public EmployeeExistException(string Message) : base(Message)
        {

        }
    }
}
