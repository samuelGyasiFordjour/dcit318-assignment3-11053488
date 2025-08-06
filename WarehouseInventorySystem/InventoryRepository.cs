using System.Collections.Generic;
using System.Linq;

namespace WarehouseInventorySystem
{
    // Generic inventory repository with constraint
    public class InventoryRepository<T> where T : IInventoryItem
    {
        private readonly Dictionary<int, T> _items;

        public InventoryRepository()
        {
            _items = new Dictionary<int, T>();
        }

        public void AddItem(T item)
        {
            if (_items.ContainsKey(item.Id))
            {
                throw new DuplicateItemException("Item with ID " + item.Id + " already exists in inventory.");
            }
            _items[item.Id] = item;
        }

        public T GetItemById(int id)
        {
            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException("Item with ID " + id + " not found in inventory.");
            }
            return _items[id];
        }

        public void RemoveItem(int id)
        {
            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException("Item with ID " + id + " not found in inventory.");
            }
            _items.Remove(id);
        }

        public List<T> GetAllItems()
        {
            return _items.Values.ToList();
        }

        public void UpdateQuantity(int id, int newQuantity)
        {
            if (newQuantity < 0)
            {
                throw new InvalidQuantityException("Quantity cannot be negative. Provided: " + newQuantity);
            }

            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException("Item with ID " + id + " not found in inventory.");
            }

            _items[id].Quantity = newQuantity;
        }
    }
}
