using System;

namespace FinanceManagementSystem
{
    // Class representing a financial transaction with immutable properties
    public class Transaction
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public string Category { get; private set; }

        public Transaction(int id, DateTime date, decimal amount, string category)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Category = category;
        }
    }
}
