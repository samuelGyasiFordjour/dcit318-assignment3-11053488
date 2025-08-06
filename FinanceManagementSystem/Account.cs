using System;

namespace FinanceManagementSystem
{
    // Base account class with basic transaction functionality
    public class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; protected set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        // Virtual method to apply a transaction to the account
        public virtual void ApplyTransaction(Transaction transaction)
        {
            Balance -= transaction.Amount;
        }
    }

    // Sealed savings account class with specific transaction rules
    public sealed class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance) 
            : base(accountNumber, initialBalance)
        {
        }

        // Override to enforce insufficient funds check
        public override void ApplyTransaction(Transaction transaction)
        {
            if (transaction.Amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                base.ApplyTransaction(transaction);
                Console.WriteLine("Transaction applied. Updated balance: GH₵" + Balance.ToString("F2"));
            }
        }
    }
}
