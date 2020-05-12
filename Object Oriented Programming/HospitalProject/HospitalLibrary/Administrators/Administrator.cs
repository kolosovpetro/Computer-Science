using System;

namespace HospitalLibrary.Administrators
{
    [Serializable]
    public class Administrator : Employee.Employee
    {
        public Administrator(string name, string surname, string id, string username, string password) :
            base(name, surname, id, username, password)
        {
        }
    }
}