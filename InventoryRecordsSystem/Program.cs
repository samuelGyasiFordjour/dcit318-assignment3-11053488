using System;

namespace InventoryRecordsSystem
{
    // Entry point for the Inventory Records System
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Inventory Records System ===");
            Console.WriteLine("Demonstrating C# Records, Generics, and File Operations");
            Console.WriteLine();

            try
            {
                // Create an instance of InventoryApp
                var inventoryApp = new InventoryApp();

                // Phase 1: Seed sample data
                inventoryApp.SeedSampleData();

                // Show initial data
                Console.WriteLine("=== Initial Data in Memory ===");
                inventoryApp.PrintAllItems();
                inventoryApp.PrintSummaryStatistics();

                // Phase 2: Save data to persist to disk
                inventoryApp.SaveData();

                // Phase 3: Clear memory and simulate a new session
                inventoryApp.ClearMemory();

                // Verify memory is cleared
                Console.WriteLine("=== After Memory Clear ===");
                inventoryApp.PrintAllItems();

                // Phase 4: Load data to read from file
                inventoryApp.LoadData();

                // Phase 5: Print all items to confirm data was recovered
                Console.WriteLine("=== Data Recovered from File ===");
                inventoryApp.PrintAllItems();
                inventoryApp.PrintSummaryStatistics();

                // Demonstrate immutability by creating modified versions
                Console.WriteLine("=== Demonstrating Immutability ===");
                var items = inventoryApp.GetLogger().GetAll();
                if (items.Count > 0)
                {
                    var originalItem = items[0];
                    Console.WriteLine("Original item: " + originalItem);

                    var modifiedItem = originalItem.WithQuantity(originalItem.Quantity + 10);
                    Console.WriteLine("Modified item: " + modifiedItem);
                    Console.WriteLine("Original unchanged: " + originalItem);
                    
                    var renamedItem = originalItem.WithName(originalItem.Name + " (Updated)");
                    Console.WriteLine("Renamed item: " + renamedItem);
                    Console.WriteLine("Original still unchanged: " + originalItem);
                }

                Console.WriteLine();
                Console.WriteLine("=== System Demonstration Complete ===");
                Console.WriteLine("Key features demonstrated:");
                Console.WriteLine("- Immutable data structures (record-like behavior)");
                Console.WriteLine("- Generic type constraints (T : IInventoryEntity)");
                Console.WriteLine("- File I/O operations with proper error handling");
                Console.WriteLine("- Data persistence and recovery");
                Console.WriteLine("- Exception handling for file operations");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("CRITICAL ERROR: Application failed!");
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine();
                
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }

                Console.WriteLine("Stack Trace:");
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
