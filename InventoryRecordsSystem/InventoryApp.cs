using System;

namespace InventoryRecordsSystem
{
    // Main inventory application class
    public class InventoryApp
    {
        private readonly InventoryLogger<InventoryItem> _logger;

        public InventoryApp()
        {
            _logger = new InventoryLogger<InventoryItem>("inventory_data.txt");
        }

        public void SeedSampleData()
        {
            Console.WriteLine("=== Seeding Sample Inventory Data ===");

            // Add sample inventory items
            _logger.Add(new InventoryItem(1, "Laptop Computer", 25, new DateTime(2025, 7, 15)));
            _logger.Add(new InventoryItem(2, "Office Chair", 50, new DateTime(2025, 7, 20)));
            _logger.Add(new InventoryItem(3, "Wireless Mouse", 100, new DateTime(2025, 7, 25)));
            _logger.Add(new InventoryItem(4, "Monitor 24 inch", 30, new DateTime(2025, 8, 1)));
            _logger.Add(new InventoryItem(5, "USB Cable", 200, new DateTime(2025, 8, 5)));

            Console.WriteLine("Sample data seeding completed. Total items: " + _logger.Count);
            Console.WriteLine();
        }

        public void SaveData()
        {
            Console.WriteLine("=== Saving Inventory Data ===");
            try
            {
                _logger.SaveToFile();
                Console.WriteLine("Data saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save data: " + ex.Message);
                throw;
            }
            Console.WriteLine();
        }

        public void LoadData()
        {
            Console.WriteLine("=== Loading Inventory Data ===");
            try
            {
                _logger.LoadFromFile();
                Console.WriteLine("Data loaded successfully! Total items: " + _logger.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load data: " + ex.Message);
                throw;
            }
            Console.WriteLine();
        }

        public void PrintAllItems()
        {
            Console.WriteLine("=== All Inventory Items ===");

            var items = _logger.GetAll();
            if (items.Count == 0)
            {
                Console.WriteLine("No items found in inventory.");
                return;
            }

            Console.WriteLine("+----+-------------------+----------+------------+");
            Console.WriteLine("| ID |       Name        | Quantity |    Date    |");
            Console.WriteLine("+----+-------------------+----------+------------+");

            foreach (var item in items)
            {
                Console.WriteLine("| " + item.Id.ToString().PadRight(2) + " | " + 
                    item.Name.PadRight(17) + " | " + 
                    item.Quantity.ToString().PadLeft(8) + " | " + 
                    item.DateAdded.ToString("yyyy-MM-dd") + " |");
            }

            Console.WriteLine("+----+-------------------+----------+------------+");
            Console.WriteLine("Total items: " + items.Count);
            Console.WriteLine();
        }

        public void ClearMemory()
        {
            Console.WriteLine("=== Simulating Memory Clear ===");
            _logger.ClearLog();
            Console.WriteLine("Memory cleared - simulating new application session.");
            Console.WriteLine();
        }

        public void PrintSummaryStatistics()
        {
            Console.WriteLine("=== Inventory Summary Statistics ===");

            var items = _logger.GetAll();
            if (items.Count == 0)
            {
                Console.WriteLine("No items to analyze.");
                return;
            }

            int totalQuantity = 0;
            DateTime oldestDate = items[0].DateAdded;
            DateTime newestDate = items[0].DateAdded;

            foreach (var item in items)
            {
                totalQuantity += item.Quantity;
                if (item.DateAdded < oldestDate)
                    oldestDate = item.DateAdded;
                if (item.DateAdded > newestDate)
                    newestDate = item.DateAdded;
            }

            double averageQuantity = (double)totalQuantity / items.Count;

            Console.WriteLine("Total Items: " + items.Count);
            Console.WriteLine("Total Quantity: " + totalQuantity);
            Console.WriteLine("Average Quantity: " + averageQuantity.ToString("F2"));
            Console.WriteLine("Oldest Entry: " + oldestDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Newest Entry: " + newestDate.ToString("yyyy-MM-dd"));
            Console.WriteLine();
        }

        public InventoryLogger<InventoryItem> GetLogger()
        {
            return _logger;
        }
    }
}
