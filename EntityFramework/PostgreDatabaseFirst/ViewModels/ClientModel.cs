namespace PostgreDatabaseFirst.ViewModels
{
    public class ClientModel
    {
        public int CopyId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public ClientModel(int copyId, string firstName, string lastName)
        {
            CopyId = copyId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
