using System;

namespace HospitalLibrary
{
    [Serializable]
    public class Urologist : Doctor
    {
        public Urologist(string Name, string Surname, string Id, string Username,
            string Password, string GMC) :
            base(Name, Surname, Id, Username, Password, GMC)
        { }
    }
}
