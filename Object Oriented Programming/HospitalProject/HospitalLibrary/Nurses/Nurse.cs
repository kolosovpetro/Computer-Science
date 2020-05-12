using System;

namespace HospitalLibrary.Nurses
{
    [Serializable]
    public class Nurse : Employee.Employee
    {
        public Nurse(string name, string surname, string id, string username, string password) :
            base(name, surname, id, username, password)
        {
        }
    }
}