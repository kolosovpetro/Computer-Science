using System;

namespace HospitalLibrary
{
    [Serializable]
    public class Cardiologist : Doctor
    {
        public Cardiologist(string Name, string Surname, string Id, string Username,
            string Password, string GMC) :
            base(Name, Surname, Id, Username, Password, GMC)
        { }
    }
}
