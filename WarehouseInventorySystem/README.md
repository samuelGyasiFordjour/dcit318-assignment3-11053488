# Warehouse Inventory Management System

This is a C# warehouse inventory management system that demonstrates the use of Collections (Dictionary, List), Generics (generic classes with constraints), and Exception Handling (custom and built-in exceptions) to manage different types of products with safe and efficient operations.

## Features

### Marker Interface
- **IInventoryItem**: Interface defining common properties for all inventory items
  - Id, Name, Quantity properties
  - Implemented by all product types

### Product Classes
- **ElectronicItem**: Represents electronic products with Brand and WarrantyMonths
- **GroceryItem**: Represents grocery products with ExpiryDate
- Both implement IInventoryItem interface

### Generic Repository with Constraints
- **InventoryRepository<T>**: Generic repository with constraint `where T : IInventoryItem`
  - Dictionary-based storage using item ID as key
  - Type-safe operations: AddItem, GetItemById, RemoveItem, GetAllItems, UpdateQuantity
  - Comprehensive exception handling

### Custom Exceptions
- **DuplicateItemException**: Thrown when adding items with existing IDs
- **ItemNotFoundException**: Thrown when item is not found
- **InvalidQuantityException**: Thrown when quantity is negative

### Collections Used
- **Dictionary<int, T>**: Fast O(1) lookup by item ID
- **List<T>**: For returning collections of items
- **LINQ**: For querying and data manipulation

### Main Application
- **WareHouseManager**: Main application logic managing both electronics and groceries
- **Program**: Entry point demonstrating all system capabilities

## How to Run

### Option 1: Using .NET Core/5+ (Recommended)
1. Navigate to the WarehouseInventorySystem folder
2. Run `dotnet build` to compile the project
3. Run `dotnet run` to execute the application

### Option 2: Using Windows .NET Framework Compiler
1. Open PowerShell or Command Prompt
2. Navigate to the WarehouseInventorySystem folder
3. Compile using the .NET Framework C# compiler:
   ```powershell
   & "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:WarehouseInventorySystem.exe *.cs
   ```
4. Run the compiled executable:
   ```powershell
   .\WarehouseInventorySystem.exe
   ```

## Architecture Highlights

- **Generic Constraints**: `where T : IInventoryItem` ensures type safety
- **Dictionary Storage**: O(1) lookup performance for item retrieval
- **Custom Exception Hierarchy**: Specific exception types for different error conditions
- **Exception Safety**: All operations wrapped in try-catch blocks
- **Polymorphism**: Interface-based design allows treating different item types uniformly
- **LINQ Integration**: Functional querying capabilities
- **C# 5 Compatibility**: Works with older .NET Framework versions

## Sample Output

When you run the application, you'll see output similar to this:

```
=== Warehouse Inventory Management System ===

=== Seeding Warehouse Data ===
Warehouse data seeded successfully!

=== All Grocery Items ===
+-----+------------------+----------+--------------------+
| ID  |       Name       | Quantity |       Details      |
+-----+------------------+----------+--------------------+
| 101 | Rice Bag         |      200 | Exp: 2025-12-31    |
| 102 | Cooking Oil      |       75 | Exp: 2025-10-15    |
| 103 | Canned Tomatoes  |      150 | Exp: 2026-06-30    |
+-----+------------------+----------+--------------------+
Total items: 3

=== All Electronic Items ===
+-----+------------------+----------+--------------------+
| ID  |       Name       | Quantity |       Details      |
+-----+------------------+----------+--------------------+
| 1   | Samsung Galaxy S24|       50 | Samsung (24m warranty)|
| 2   | MacBook Pro      |       25 | Apple (12m warranty)|
| 3   | Sony Headphones  |      100 | Sony (6m warranty) |
+-----+------------------+----------+--------------------+
Total items: 3

=== Successful Operations ===
Increasing stock for Electronic Item ID 1...
Successfully increased stock for item ID 1. New quantity: 75

Removing Grocery Item ID 102...
Successfully removed item: Cooking Oil (ID: 102)

=== Exception Handling Demonstration ===
1. Attempting to add duplicate electronic item...
Caught DuplicateItemException: Item with ID 1 already exists in inventory.

2. Attempting to remove non-existent grocery item...
Caught ItemNotFoundException: Item with ID 999 not found in inventory.

3. Attempting to update with invalid quantity...
Caught InvalidQuantityException: Quantity cannot be negative. Provided: -10

4. Attempting to get non-existent item...
Caught ItemNotFoundException: Item with ID 888 not found in inventory.

Press any key to exit...
```

## Key Concepts Demonstrated

1. **Generic Constraints**: `where T : IInventoryItem` ensures only valid types can be used
2. **Collections**: Dictionary for fast lookup, List for collections
3. **Custom Exceptions**: Specific exception types for different error conditions
4. **Exception Handling**: Try-catch blocks for graceful error handling
5. **Interface Implementation**: Common interface for different product types
6. **Type Safety**: Compile-time guarantees through generics
7. **SOLID Principles**: Interface segregation and dependency inversion
8. **Performance**: O(1) dictionary operations for scalable inventory management

## Exception Handling Strategy

The system demonstrates comprehensive exception handling:
- **Custom Exceptions**: Domain-specific error types
- **Defensive Programming**: Validation before operations
- **User-Friendly Messages**: Clear error descriptions
- **Exception Propagation**: Proper exception bubbling
- **Recovery Mechanisms**: Graceful degradation on errors
