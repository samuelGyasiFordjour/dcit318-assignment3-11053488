using System;

namespace WarehouseInventorySystem
{
    // Entry point for the Warehouse Inventory Management System
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Warehouse Inventory Management System ===");
                Console.WriteLine();

                // Instantiate warehouse manager
                var warehouseManager = new WareHouseManager();

                // Seed data
                warehouseManager.SeedData();

                // Print all grocery items
                Console.WriteLine("=== All Grocery Items ===");
                warehouseManager.PrintAllItems(warehouseManager.GetGroceriesRepository());

                // Print all electronic items
                Console.WriteLine("=== All Electronic Items ===");
                warehouseManager.PrintAllItems(warehouseManager.GetElectronicsRepository());

                // Demonstrate successful operations
                Console.WriteLine("=== Successful Operations ===");
                Console.WriteLine("Increasing stock for Electronic Item ID 1...");
                warehouseManager.IncreaseStock(warehouseManager.GetElectronicsRepository(), 1, 25);
                
                Console.WriteLine("\nRemoving Grocery Item ID 102...");
                warehouseManager.RemoveItemById(warehouseManager.GetGroceriesRepository(), 102);
                Console.WriteLine();

                // Demonstrate exception handling
                warehouseManager.DemonstrateExceptionHandling();

                // Show final state
                Console.WriteLine("=== Final Inventory State ===");
                Console.WriteLine("Electronics after operations:");
                warehouseManager.PrintAllItems(warehouseManager.GetElectronicsRepository());
                
                Console.WriteLine("Groceries after operations:");
                warehouseManager.PrintAllItems(warehouseManager.GetGroceriesRepository());

                Console.WriteLine("=== Warehouse Management Demo Complete ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical system error: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
