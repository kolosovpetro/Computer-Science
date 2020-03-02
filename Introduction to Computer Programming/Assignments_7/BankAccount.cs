using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_7
{
    public class BankAccount
    {
        private double accountBalance;

        /// <summary>
        /// Constructor of class Bank Account. Initializes field accountBalance.
        /// </summary>
        /// <param name="accountBalance">Balance of current bank account</param>
        /// <see cref="BankAccount"/>
        public BankAccount(double accountBalance)
        {
            this.accountBalance = accountBalance;
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

            if (this.accountBalance - deduction < 0)
            {
                throw new NotEnoughMoneyException("Insufficent account balance");
            }

            this.accountBalance -= deduction;
        }

        /// <summary>
        /// Getter of accountBalance field of Bank Account instance.
        /// </summary>
        /// <returns>Returns current account balance.</returns>
        /// <see cref="GetAccountBalance"/>
        public double GetAccountBalance()
        {
            return this.accountBalance;
        }

    }
}
