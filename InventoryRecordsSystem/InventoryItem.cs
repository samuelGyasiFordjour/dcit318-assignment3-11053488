using System;

namespace InventoryRecordsSystem
{
    // Immutable inventory item class (C# 5 compatible version of record)
    public class InventoryItem : IInventoryEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public DateTime DateAdded { get; private set; }

        public InventoryItem(int id, string name, int quantity, DateTime dateAdded)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            DateAdded = dateAdded;
        }

        // Create a new instance with updated quantity (immutability pattern)
        public InventoryItem WithQuantity(int newQuantity)
        {
            return new InventoryItem(Id, Name, newQuantity, DateAdded);
        }

        // Create a new instance with updated name (immutability pattern)
        public InventoryItem WithName(string newName)
        {
            return new InventoryItem(Id, newName, Quantity, DateAdded);
        }

        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + Name + ", Quantity: " + Quantity + 
                   ", DateAdded: " + DateAdded.ToString("yyyy-MM-dd");
        }

        // Override Equals for value equality (record-like behavior)
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (InventoryItem)obj;
            return Id == other.Id && 
                   Name == other.Name && 
                   Quantity == other.Quantity && 
                   DateAdded == other.DateAdded;
        }

        public override int GetHashCode()
        {
            // Simple hash code implementation
            return Id.GetHashCode() ^ (Name != null ? Name.GetHashCode() : 0) ^ 
                   Quantity.GetHashCode() ^ DateAdded.GetHashCode();
        }
    }
}
