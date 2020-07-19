namespace Assignments_7
{
    public class BankAccount
    {
        private double _accountBalance;

        /// <summary>
        /// Constructor of class Bank Account. Initializes field accountBalance.
        /// </summary>
        /// <param name="accountBalance">Balance of current bank account</param>
        /// <see cref="BankAccount"/>
        public BankAccount(double accountBalance)
        {
            _accountBalance = accountBalance;
        }

        /// <summary>
        /// Method in order to deduct particular amount of money from Account Balance.
        /// </summary>
        /// <param name="deduction">Amount of money to be deducted from Account balance.</param>
        /// <see cref="Deduct(double)"/>
        public void Deduct(double deduction)
        {
            if (deduction < 0)
            {
                throw new NegativeAmountException("Deduction cannot be negative.");
            }

            if (_accountBalance - deduction < 0)
            {
                throw new NotEnoughMoneyException("Insufficient account balance");
            }

            _accountBalance -= deduction;
        }

        /// <summary>
        /// Getter of accountBalance field of Bank Account instance.
        /// </summary>
        /// <returns>Returns current account balance.</returns>
        /// <see cref="GetAccountBalance"/>
        public double GetAccountBalance()
        {
            return _accountBalance;
        }

    }
}
