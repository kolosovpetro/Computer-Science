namespace PostgreDatabaseFirst.ViewModels
{
    public class ClientViewModel
    {
        public string FirstName { get; }
        public string LastName { get; }

        public ClientViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
