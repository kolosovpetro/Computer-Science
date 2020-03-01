using System;

namespace HospitalLibrary
{
    [Serializable]
    public class Neurologist : Doctor
    {
        public Neurologist(string Name, string Surname, string Id, string Username,
            string Password, string GMC) :
            base(Name, Surname, Id, Username, Password, GMC)
        { }
    }
}
