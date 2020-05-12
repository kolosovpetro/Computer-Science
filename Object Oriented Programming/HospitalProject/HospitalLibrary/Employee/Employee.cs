using System;
using System.Collections.Generic;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Employee
{
    [Serializable]
    public abstract class Employee
    {
        public List<bool> Duties { get; protected set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }


        protected Employee(string name, string surname, string id, string username, string password)
        {
            Name = name;
            Surname = surname;
            Id = id;
            Username = username;
            Password = password;
            Duties = new List<bool>();

            // we assume that working month is equal to 30 days
            // we initialize list of workdays and fill it with all holidays (i.e false values)

            for (int i = 0; i < 31; i++)
                Duties.Add(false);
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeSurname(string surname)
        {
            Surname = surname;
        }

        public void ChangeIdNumber(string id)
        {
            Id = id;
        }

        public void ChangeUsername(string username)
        {
            Username = username;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void AddDuty(int dayIndex)
        {
            if (dayIndex > Duties.Count || Duties[dayIndex])
                throw new EmployeeScheduleException("Day index out of range or already set to be duty.");
            Duties[dayIndex] = true;
        }

        public void RemoveDuty(int dayIndex)
        {
            if (dayIndex > Duties.Count || !Duties[dayIndex])
                throw new EmployeeScheduleException("Day index out of range or already set not to be duty.");
            Duties[dayIndex] = false;
        }

        public virtual string EmployeeInfo()
        {
            return $"{Name}, {Surname} - {Id} - Username: {Username}, Pass: {Password} - {GetType().Name}";
        }
    }
}