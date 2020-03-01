using System.Collections.Generic;

namespace HospitalLibrary
{
    public interface IEmployee
    {
        List<bool> Duties { get; }
        string Name { get; }
        string Surname { get; }
        string Id { get; }
    }
}
