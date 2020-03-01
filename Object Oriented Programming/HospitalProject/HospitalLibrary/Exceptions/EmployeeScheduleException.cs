using System;

namespace HospitalLibrary
{
    public class EmployeeScheduleException : Exception
    {
        public EmployeeScheduleException()
        {

        }

        public EmployeeScheduleException(string Message) : base(Message)
        {

        }
    }
}
