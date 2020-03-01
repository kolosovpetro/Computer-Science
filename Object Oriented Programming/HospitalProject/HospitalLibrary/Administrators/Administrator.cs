using System;

namespace HospitalLibrary
{
    [Serializable]
    public class Administrator : Employee
    {
        public Hospital NewHospital { get; private set; }

        public Administrator(string Name, string Surname, string Id, string Username, 
            string Password) :
            base(Name, Surname, Id, Username, Password)
        { }


    }
}
