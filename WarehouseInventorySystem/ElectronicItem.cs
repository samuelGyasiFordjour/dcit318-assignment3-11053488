namespace WarehouseInventorySystem
{
    // Electronic item class implementing IInventoryItem
    public class ElectronicItem : IInventoryItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; set; }
        public string Brand { get; private set; }
        public int WarrantyMonths { get; private set; }

        public ElectronicItem(int id, string name, int quantity, string brand, int warrantyMonths)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Brand = brand;
            WarrantyMonths = warrantyMonths;
        }

        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + Name + ", Quantity: " + Quantity + 
                   ", Brand: " + Brand + ", Warranty: " + WarrantyMonths + " months";
        }
    }
}
