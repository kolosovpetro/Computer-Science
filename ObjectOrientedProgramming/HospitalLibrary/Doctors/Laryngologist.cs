using System;

namespace HospitalLibrary.Doctors
{
    [Serializable]
    public class Laryngologist : Doctor
    {
        public Laryngologist(string name, string surname, string id, string username, string password, string gmc) :
            base(name, surname, id, username, password, gmc)
        {
        }
    }
}