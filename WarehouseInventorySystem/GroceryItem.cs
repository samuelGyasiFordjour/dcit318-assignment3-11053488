using System;

namespace WarehouseInventorySystem
{
    // Grocery item class implementing IInventoryItem
    public class GroceryItem : IInventoryItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; private set; }

        public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }

        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + Name + ", Quantity: " + Quantity + 
                   ", Expiry: " + ExpiryDate.ToString("yyyy-MM-dd");
        }
    }
}
