using System.Collections.Generic;
using PostgreDatabaseFirst.ViewModels;

namespace PostgreDatabaseFirst.Comparers
{
    internal class ClientNameComparer : IEqualityComparer<ClientViewModel>
    {
        public bool Equals(ClientViewModel x, ClientViewModel y)
        {
            if (x == null || y == null) return false;
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }

        public int GetHashCode(ClientViewModel obj)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + obj.FirstName.GetHashCode();
                hash = hash * 23 + obj.LastName.GetHashCode();
                return hash;
            }
        }
    }
}
