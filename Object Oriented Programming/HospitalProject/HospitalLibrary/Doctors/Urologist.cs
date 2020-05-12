using System;

namespace HospitalLibrary.Doctors
{
    [Serializable]
    public class Urologist : Doctor
    {
        public Urologist(string name, string surname, string id, string username, string password, string gmc) :
            base(name, surname, id, username, password, gmc)
        {
        }
    }
}