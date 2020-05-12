using System;

namespace HospitalLibrary.Doctors
{
    [Serializable]
    public class Cardiologist : Doctor
    {
        public Cardiologist(string name, string surname, string id, string username, string password, string gmc) :
            base(name, surname, id, username, password, gmc)
        {
        }
    }
}