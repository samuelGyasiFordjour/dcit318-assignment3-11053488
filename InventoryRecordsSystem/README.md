# Inventory Records System

This is a C# inventory records system that demonstrates the use of immutable data structures (records), generics with constraints, and file I/O operations for data persistence. The system manages inventory items with type safety and immutability patterns.

## Features

### Immutable Data Structures
- **InventoryItem**: Immutable class simulating C# record behavior (C# 5 compatible)
- **Immutability Methods**: `WithQuantity()`, `WithName()` for creating modified copies
- **Value Equality**: Override of Equals and GetHashCode for proper value comparison
- **Data Integrity**: Properties with private setters prevent modification after creation

### Generic Type System
- **InventoryLogger<T>**: Generic class with constraint `where T : IInventoryEntity`
- **Type Safety**: Compile-time guarantees for inventory operations
- **Interface Constraints**: Ensures only valid inventory entities can be logged
- **Reusability**: Same logger can work with different inventory entity types

### File Operations
- **Data Persistence**: Save inventory data to text files
- **Data Recovery**: Load inventory data from files
- **Error Handling**: Comprehensive exception handling for file operations
- **Resource Management**: Using statements for proper file handle disposal

### Marker Interface Pattern
- **IInventoryEntity**: Interface defining common properties for inventory entities
- **Polymorphism**: Enables treating different inventory types uniformly
- **Contract Definition**: Establishes minimum requirements for inventory items

## How to Run

### Option 1: Using .NET Core/5+ (Recommended)
1. Navigate to the InventoryRecordsSystem folder
2. Run `dotnet build` to compile the project
3. Run `dotnet run` to execute the application

### Option 2: Using Windows .NET Framework Compiler
1. Open PowerShell or Command Prompt
2. Navigate to the InventoryRecordsSystem folder
3. Compile using the .NET Framework C# compiler:
   ```powershell
   & "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:InventoryRecordsSystem.exe *.cs
   ```
4. Run the compiled executable:
   ```powershell
   .\InventoryRecordsSystem.exe
   ```

## Architecture Highlights

- **Record-like Behavior**: Immutable classes with value equality (C# 5 compatible)
- **Generic Constraints**: Type safety through interface constraints
- **File I/O**: StreamReader/StreamWriter with proper exception handling
- **Resource Management**: Using statements for automatic disposal
- **Error Handling**: Multi-layer exception handling for different error scenarios
- **Data Validation**: Input validation and error recovery
- **Separation of Concerns**: Clear separation between data, logging, and application logic

## Sample Output

When you run the application, you'll see output similar to this:

```
=== Inventory Records System ===
Demonstrating C# Records, Generics, and File Operations

=== Seeding Sample Inventory Data ===
Added to log: ID: 1, Name: Laptop Computer, Quantity: 25, DateAdded: 2025-07-15
Added to log: ID: 2, Name: Office Chair, Quantity: 50, DateAdded: 2025-07-20
Added to log: ID: 3, Name: Wireless Mouse, Quantity: 100, DateAdded: 2025-07-25
Added to log: ID: 4, Name: Monitor 24 inch, Quantity: 30, DateAdded: 2025-08-01
Added to log: ID: 5, Name: USB Cable, Quantity: 200, DateAdded: 2025-08-05
Sample data seeding completed. Total items: 5

=== Initial Data in Memory ===
=== All Inventory Items ===
+----+-------------------+----------+------------+
| ID |       Name        | Quantity |    Date    |
+----+-------------------+----------+------------+
| 1  | Laptop Computer   |       25 | 2025-07-15 |
| 2  | Office Chair      |       50 | 2025-07-20 |
| 3  | Wireless Mouse    |      100 | 2025-07-25 |
| 4  | Monitor 24 inch   |       30 | 2025-08-01 |
| 5  | USB Cable         |      200 | 2025-08-05 |
+----+-------------------+----------+------------+
Total items: 5

=== Inventory Summary Statistics ===
Total Items: 5
Total Quantity: 405
Average Quantity: 81.00
Oldest Entry: 2025-07-15
Newest Entry: 2025-08-05

=== Saving Inventory Data ===
Saving inventory data to file: inventory_data.txt
Successfully saved 5 items to inventory_data.txt
Data saved successfully!

=== Simulating Memory Clear ===
Inventory log cleared.
Memory cleared - simulating new application session.

=== After Memory Clear ===
=== All Inventory Items ===
No items found in inventory.

=== Loading Inventory Data ===
Loading inventory data from file: inventory_data.txt
Successfully loaded 5 items from inventory_data.txt
Data loaded successfully! Total items: 5

=== Data Recovered from File ===
=== All Inventory Items ===
+----+-------------------+----------+------------+
| ID |       Name        | Quantity |    Date    |
+----+-------------------+----------+------------+
| 1  | Laptop Computer   |       25 | 2025-07-15 |
| 2  | Office Chair      |       50 | 2025-07-20 |
| 3  | Wireless Mouse    |      100 | 2025-07-25 |
| 4  | Monitor 24 inch   |       30 | 2025-08-01 |
| 5  | USB Cable         |      200 | 2025-08-05 |
+----+-------------------+----------+------------+
Total items: 5

=== Demonstrating Immutability ===
Original item: ID: 1, Name: Laptop Computer, Quantity: 25, DateAdded: 2025-07-15
Modified item: ID: 1, Name: Laptop Computer, Quantity: 35, DateAdded: 2025-07-15
Original unchanged: ID: 1, Name: Laptop Computer, Quantity: 25, DateAdded: 2025-07-15
Renamed item: ID: 1, Name: Laptop Computer (Updated), Quantity: 25, DateAdded: 2025-07-15
Original still unchanged: ID: 1, Name: Laptop Computer, Quantity: 25, DateAdded: 2025-07-15

=== System Demonstration Complete ===
Key features demonstrated:
- Immutable data structures (record-like behavior)
- Generic type constraints (T : IInventoryEntity)
- File I/O operations with proper error handling
- Data persistence and recovery
- Exception handling for file operations

Press any key to exit...
```

### Generated File Content (inventory_data.txt):
```
=== INVENTORY DATA ===
Saved on: 2025-08-06 16:45:30
Total Items: 5

INVENTORY ITEMS:
================
1|Laptop Computer|25|2025-07-15 00:00:00
2|Office Chair|50|2025-07-20 00:00:00
3|Wireless Mouse|100|2025-07-25 00:00:00
4|Monitor 24 inch|30|2025-08-01 00:00:00
5|USB Cable|200|2025-08-05 00:00:00
```

## Key Concepts Demonstrated

1. **Immutable Data Structures**: 
   - Properties with private setters
   - Methods returning new instances instead of modifying existing ones
   - Value equality implementation

2. **Generic Programming**:
   - Generic classes with type constraints
   - Interface-based constraints (`where T : IInventoryEntity`)
   - Type safety at compile time

3. **File I/O Operations**:
   - StreamReader and StreamWriter usage
   - Using statements for resource management
   - Text-based serialization and deserialization

4. **Exception Handling**:
   - Multiple catch blocks for specific exception types
   - Error recovery and graceful degradation
   - Resource cleanup in finally blocks (implicit with using)

5. **Interface Design**:
   - Marker interfaces for type categorization
   - Contract definition for minimum requirements
   - Polymorphic behavior

6. **Data Persistence**:
   - Saving application state to files
   - Loading application state from files
   - Data format design for persistence

7. **C# 5 Compatibility**:
   - Record-like behavior without record syntax
   - Manual implementation of immutability patterns
   - Compatible generic constraints and file operations

## Design Patterns Used

- **Repository Pattern**: InventoryLogger acts as a repository for inventory items
- **Factory Pattern**: Methods for creating modified instances (WithQuantity, WithName)
- **Template Method**: Generic logger with specific implementations for different types
- **Marker Interface**: IInventoryEntity defines type category without behavior
- **Immutable Object**: InventoryItem prevents modification after creation
