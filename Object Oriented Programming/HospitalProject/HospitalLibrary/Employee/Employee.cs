using System;
using System.Collections.Generic;

namespace HospitalLibrary
{
    [Serializable]
    public abstract class Employee : IEmployee
    {
        public List<bool> Duties { get; protected set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }


        public Employee(string Name, string Surname, string Id, string Username, string Password)
        {

            this.Name = Name;
            this.Surname = Surname;
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
            this.Duties = new List<bool>();

            // we assume that working month is equal to 30 days
            // we initialize list of workdays and fill it with all holidays (i.e false values)

            for (int i = 0; i < 31; i++)
                Duties.Add(false);
        }

        public void ChangeName(string Name)
        {
            this.Name = Name;
        }

        public void ChangeSurname(string Surname)
        {
            this.Surname = Surname;
        }

        public void ChangeIdNumber(string Id)
        {
            this.Id = Id;
        }

        public void ChangeUsername(string Username)
        {
            this.Username = Username;
        }

        public void ChangePassword(string Password)
        {
            this.Password = Password;
        }

        public void AddDuty(int DayIndex)
        {
            if (DayIndex <= Duties.Count && !Duties[DayIndex])
            {
                Duties[DayIndex] = true;
                return;
            }

            throw new EmployeeScheduleException("Day index out of range or already set to be duty.");
        }

        public void RemoveDuty(int DayIndex)
        {
            if (DayIndex <= Duties.Count && Duties[DayIndex])
            {
                Duties[DayIndex] = false;
                return;
            }

            throw new EmployeeScheduleException("Day index out of range or already set not to be duty.");
        }

        public virtual string EmployeeInfo()
        {
            string ShiflList = "Dusties:";

            for (int i = 0; i < Duties.Count; i++)
            {
                ShiflList += $" {i}: {Duties[i]} |";
            }

            return $"{Name}, {Surname} - {Id} - Username: {Username}, Pass: {Password} - {GetType().Name}";
        }
    }
}
