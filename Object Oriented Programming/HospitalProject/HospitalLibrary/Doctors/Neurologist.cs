using System;

namespace HospitalLibrary.Doctors
{
    [Serializable]
    public class Neurologist : Doctor
    {
        public Neurologist(string name, string surname, string id, string username, string password, string gmc) :
            base(name, surname, id, username, password, gmc)
        {
        }
    }
}