using System;

namespace Client
{
    public class Person: IComparable
    {
        public int IdNumber { get; }
        public string FirstName { get; }
        public string FamilyName { get; }

        public Person(int newIdNumber, string newFirstName, string newFamilyName)
        {
            this.IdNumber = newIdNumber;
            this.FirstName = newFirstName;
            this.FamilyName = newFamilyName;
        }

        public override string ToString()
        {
            return this.IdNumber+". "+this.FirstName+" "+this.FamilyName;
        }

        public int CompareTo(object obj)
        {
            return IdNumber.CompareTo(obj);
        }       

    }
}
