using System;

namespace HospitalLibrary
{
    [Serializable]
    public abstract class Doctor : Employee
    {
        public string Speciality { get; private set; }
        public string GMC { get; private set; }

        public Doctor(string Name, string Surname, string Id, string Username,
            string Password, string GMC) :
            base(Name, Surname, Id, Username, Password)
        {
            if (GMC.Length > 7)
            {
                throw new DoctorGMCException("GMC number must be less then 7 digits.");
            }

            Speciality = GetType().Name;
            this.GMC = GMC;
        }

        public void ChangeGMCNumber(string newNumber)
        {
            GMC = newNumber;
        }

        public override string EmployeeInfo()
        {
            string ShiflList = "Dusties:";

            for (int i = 0; i < Duties.Count; i++)
            {
                ShiflList += $" Day {i}: {Duties[i]}";
            }

            return $"{Name}, {Surname} - {Id} - Username: {Username}, Pass: {Password} - Doctor - {GetType().Name}";
        }
    }
}
