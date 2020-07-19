using System;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Doctors
{
    [Serializable]
    public abstract class Doctor : Employee.Employee
    {
        public string Speciality { get; private set; }
        public string Gmc { get; private set; }

        protected Doctor(string name, string surname, string id, string username, string password, string gmc) :
            base(name, surname, id, username, password)
        {
            if (gmc.Length > 7)
            {
                throw new DoctorGmcException("GMC number must be less then 7 digits.");
            }

            Speciality = GetType().Name;
            Gmc = gmc;
        }

        public void ChangeGmcNumber(string newNumber)
        {
            Gmc = newNumber;
        }

        public override string EmployeeInfo()
        {
            return $"{Name}, {Surname} - {Id} - Username: {Username}, Pass: {Password} - Doctor - {GetType().Name}";
        }
    }
}