using System;

namespace FinanceManagementSystem
{
    // Entry point for the Finance Management System application
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var financeApp = new FinanceApp();
                financeApp.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
