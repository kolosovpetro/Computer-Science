using System;

namespace HospitalLibrary
{
    [Serializable]
    public class Nurse : Employee
    {
        public Nurse(string Name, string Surname, string Id, string Username, 
            string Password) :
            base(Name, Surname, Id, Username, Password)
        { }
    }
}
