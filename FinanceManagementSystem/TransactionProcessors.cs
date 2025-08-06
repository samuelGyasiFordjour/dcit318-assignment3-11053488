using System;

namespace FinanceManagementSystem
{
    // Bank transfer processor implementation
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine("Processing bank transfer: GH₵" + transaction.Amount.ToString("F2") + " for " + transaction.Category);
        }
    }

    // Mobile money processor implementation
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine("Processing mobile money payment: GH₵" + transaction.Amount.ToString("F2") + " for " + transaction.Category);
        }
    }

    // Crypto wallet processor implementation
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine("Processing crypto wallet transaction: GH₵" + transaction.Amount.ToString("F2") + " for " + transaction.Category);
        }
    }
}
