using System;

namespace HospitalLibrary.Exceptions
{
    public class DoctorGmcException : Exception
    {
        public DoctorGmcException(string message) : base(message)
        {
        }
    }
}