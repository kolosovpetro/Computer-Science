using System;

namespace HospitalLibrary
{
    [Serializable]
    public class Laryngologist : Doctor
    {
        public Laryngologist(string Name, string Surname, string Id, string Username,
            string Password, string GMC) :
            base(Name, Surname, Id, Username, Password, GMC)
        { }
    }
}
