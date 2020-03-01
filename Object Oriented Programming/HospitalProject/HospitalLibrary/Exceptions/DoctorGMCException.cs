using System;

namespace HospitalLibrary
{
    public class DoctorGMCException : Exception
    {
        public DoctorGMCException()
        {

        }

        public DoctorGMCException(string Message) : base(Message)
        {

        }
    }
}
