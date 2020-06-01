using System;

namespace Client
{
    public class Person : IComparable
    {
        private int IdNumber { get; }
        private string FirstName { get; }
        private string FamilyName { get; }

        public Person(int newIdNumber, string newFirstName, string newFamilyName)
        {
            IdNumber = newIdNumber;
            FirstName = newFirstName;
            FamilyName = newFamilyName;
        }

        public override string ToString()
        {
            return IdNumber + ". " + FirstName + " " + FamilyName;
        }

        public int CompareTo(object obj)
        {
            return IdNumber.CompareTo(obj);
        }
    }
}