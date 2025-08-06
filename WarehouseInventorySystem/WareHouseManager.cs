using System;
using System.Collections.Generic;

namespace WarehouseInventorySystem
{
    // Main warehouse management class
    public class WareHouseManager
    {
        private readonly InventoryRepository<ElectronicItem> _electronics;
        private readonly InventoryRepository<GroceryItem> _groceries;

        public WareHouseManager()
        {
            _electronics = new InventoryRepository<ElectronicItem>();
            _groceries = new InventoryRepository<GroceryItem>();
        }

        public void SeedData()
        {
            Console.WriteLine("=== Seeding Warehouse Data ===");
            
            try
            {
                // Add electronic items
                _electronics.AddItem(new ElectronicItem(1, "Samsung Galaxy S24", 50, "Samsung", 24));
                _electronics.AddItem(new ElectronicItem(2, "MacBook Pro", 25, "Apple", 12));
                _electronics.AddItem(new ElectronicItem(3, "Sony Headphones", 100, "Sony", 6));

                // Add grocery items
                _groceries.AddItem(new GroceryItem(101, "Rice Bag", 200, new DateTime(2025, 12, 31)));
                _groceries.AddItem(new GroceryItem(102, "Cooking Oil", 75, new DateTime(2025, 10, 15)));
                _groceries.AddItem(new GroceryItem(103, "Canned Tomatoes", 150, new DateTime(2026, 6, 30)));

                Console.WriteLine("Warehouse data seeded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error seeding data: " + ex.Message);
            }
            Console.WriteLine();
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            try
            {
                var items = repo.GetAllItems();
                if (items.Count == 0)
                {
                    Console.WriteLine("No items found in inventory.");
                    return;
                }

                Console.WriteLine("+-----+------------------+----------+--------------------+");
                Console.WriteLine("| ID  |       Name       | Quantity |       Details      |");
                Console.WriteLine("+-----+------------------+----------+--------------------+");

                foreach (var item in items)
                {
                    string details = "";
                    var electronic = item as ElectronicItem;
                    if (electronic != null)
                    {
                        details = electronic.Brand + " (" + electronic.WarrantyMonths + "m warranty)";
                    }
                    else
                    {
                        var grocery = item as GroceryItem;
                        if (grocery != null)
                        {
                            details = "Exp: " + grocery.ExpiryDate.ToString("yyyy-MM-dd");
                        }
                    }

                    Console.WriteLine("| " + item.Id.ToString().PadRight(3) + " | " + 
                        item.Name.PadRight(16) + " | " + 
                        item.Quantity.ToString().PadLeft(8) + " | " + 
                        details.PadRight(18) + " |");
                }
                Console.WriteLine("+-----+------------------+----------+--------------------+");
                Console.WriteLine("Total items: " + items.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving items: " + ex.Message);
            }
            Console.WriteLine();
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                int newQuantity = item.Quantity + quantity;
                repo.UpdateQuantity(id, newQuantity);
                Console.WriteLine("Successfully increased stock for item ID " + id + ". New quantity: " + newQuantity);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine("Stock increase failed: " + ex.Message);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine("Stock increase failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error during stock increase: " + ex.Message);
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.RemoveItem(id);
                Console.WriteLine("Successfully removed item: " + item.Name + " (ID: " + id + ")");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine("Remove item failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error during item removal: " + ex.Message);
            }
        }

        public void DemonstrateExceptionHandling()
        {
            Console.WriteLine("=== Exception Handling Demonstration ===");

            // Try to add duplicate item
            Console.WriteLine("1. Attempting to add duplicate electronic item...");
            try
            {
                _electronics.AddItem(new ElectronicItem(1, "Duplicate Phone", 10, "Generic", 12));
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine("Caught DuplicateItemException: " + ex.Message);
            }

            // Try to remove non-existent item
            Console.WriteLine("\n2. Attempting to remove non-existent grocery item...");
            try
            {
                _groceries.RemoveItem(999);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine("Caught ItemNotFoundException: " + ex.Message);
            }

            // Try to update with invalid quantity
            Console.WriteLine("\n3. Attempting to update with invalid quantity...");
            try
            {
                _electronics.UpdateQuantity(1, -10);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine("Caught InvalidQuantityException: " + ex.Message);
            }

            // Try to get non-existent item
            Console.WriteLine("\n4. Attempting to get non-existent item...");
            try
            {
                _groceries.GetItemById(888);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine("Caught ItemNotFoundException: " + ex.Message);
            }

            Console.WriteLine();
        }

        public InventoryRepository<ElectronicItem> GetElectronicsRepository()
        {
            return _electronics;
        }

        public InventoryRepository<GroceryItem> GetGroceriesRepository()
        {
            return _groceries;
        }
    }
}
