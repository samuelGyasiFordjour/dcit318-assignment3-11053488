namespace FinanceManagementSystem
{
    // Interface defining the contract for processing transactions
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}
