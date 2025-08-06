using System;
using System.Collections.Generic;

namespace FinanceManagementSystem
{
    // Main finance application that demonstrates the system functionality
    public class FinanceApp
    {
        private readonly List<Transaction> _transactions;

        public FinanceApp()
        {
            _transactions = new List<Transaction>();
        }

        public void Run()
        {
            Console.WriteLine("=== Finance Management System ===");
            Console.WriteLine();

            // Create a savings account with initial balance
            var savingsAccount = new SavingsAccount("SAV001", 1000m);
            Console.WriteLine("Created Savings Account: " + savingsAccount.AccountNumber + " with initial balance: GH₵" + savingsAccount.Balance.ToString("F2"));
            Console.WriteLine();

            // Create sample transactions
            var transaction1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            var transaction2 = new Transaction(2, DateTime.Now.AddMinutes(10), 250m, "Utilities");
            var transaction3 = new Transaction(3, DateTime.Now.AddMinutes(20), 75m, "Entertainment");

            // Create processors
            var mobileMoneyProcessor = new MobileMoneyProcessor();
            var bankTransferProcessor = new BankTransferProcessor();
            var cryptoWalletProcessor = new CryptoWalletProcessor();

            // Process and apply transactions
            Console.WriteLine("Processing transactions:");
            Console.WriteLine();

            // Create a list to track processors used
            var processorUsed = new List<string>();

            // Transaction 1 - Mobile Money
            Console.WriteLine("Transaction 1: ID=" + transaction1.Id + ", Amount=GH₵" + transaction1.Amount.ToString("F2") + ", Category=" + transaction1.Category);
            mobileMoneyProcessor.Process(transaction1);
            processorUsed.Add("Mobile Money");
            savingsAccount.ApplyTransaction(transaction1);
            _transactions.Add(transaction1);
            Console.WriteLine();

            // Transaction 2 - Bank Transfer
            Console.WriteLine("Transaction 2: ID=" + transaction2.Id + ", Amount=GH₵" + transaction2.Amount.ToString("F2") + ", Category=" + transaction2.Category);
            bankTransferProcessor.Process(transaction2);
            processorUsed.Add("Bank Transfer");
            savingsAccount.ApplyTransaction(transaction2);
            _transactions.Add(transaction2);
            Console.WriteLine();

            // Transaction 3 - Crypto Wallet
            Console.WriteLine("Transaction 3: ID=" + transaction3.Id + ", Amount=GH₵" + transaction3.Amount.ToString("F2") + ", Category=" + transaction3.Category);
            cryptoWalletProcessor.Process(transaction3);
            processorUsed.Add("Crypto Wallet");
            savingsAccount.ApplyTransaction(transaction3);
            _transactions.Add(transaction3);
            Console.WriteLine();

            // Processor Summary Table
            Console.WriteLine("=== Processor Summary Table ===");
            Console.WriteLine("+----+-------------+----------------+");
            Console.WriteLine("| ID |  Category   |   Processor    |");
            Console.WriteLine("+----+-------------+----------------+");
            for (int i = 0; i < _transactions.Count; i++)
            {
                Console.WriteLine("| " + _transactions[i].Id.ToString().PadRight(2) + " | " + 
                    _transactions[i].Category.PadRight(11) + " | " + 
                    processorUsed[i].PadRight(14) + " |");
            }
            Console.WriteLine("+----+-------------+----------------+");
            Console.WriteLine();

            // Summary
            Console.WriteLine("=== Transaction Summary ===");
            Console.WriteLine("Total transactions processed: " + _transactions.Count);
            Console.WriteLine("Final account balance: GH₵" + savingsAccount.Balance.ToString("F2"));
            Console.WriteLine();
            
            // Transaction Details Table
            Console.WriteLine("=== Transaction Details Table ===");
            Console.WriteLine("+----+---------------------+----------+-------------+");
            Console.WriteLine("| ID |        Date         |  Amount  |  Category   |");
            Console.WriteLine("+----+---------------------+----------+-------------+");
            foreach (var transaction in _transactions)
            {
                Console.WriteLine("| " + transaction.Id.ToString().PadRight(2) + " | " + 
                    transaction.Date.ToString("yyyy-MM-dd HH:mm").PadRight(19) + " | GH₵" + 
                    transaction.Amount.ToString("F2").PadLeft(6) + " | " + 
                    transaction.Category.PadRight(11) + " |");
            }
            Console.WriteLine("+----+---------------------+----------+-------------+");
            Console.WriteLine();
            
            // Account Summary Table
            Console.WriteLine("=== Account Summary Table ===");
            Console.WriteLine("+---------+----------------+");
            Console.WriteLine("| Account |    Balance     |");
            Console.WriteLine("+---------+----------------+");
            Console.WriteLine("| " + savingsAccount.AccountNumber.PadRight(7) + " | GH₵" + 
                savingsAccount.Balance.ToString("F2").PadLeft(10) + " |");
            Console.WriteLine("+---------+----------------+");
        }
    }
}
