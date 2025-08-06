# Finance Management System

This is a C# finance management system that demonstrates the use of interfaces, records, and sealed classes to create a modular and maintainable financial transaction processing system.

## Features

### Core Models (Records)
- **Transaction**: Immutable record representing financial transactions with Id, Date, Amount, and Category

### Payment Behavior (Interfaces)
- **ITransactionProcessor**: Interface defining transaction processing contract
- **BankTransferProcessor**: Processes bank transfers
- **MobileMoneyProcessor**: Processes mobile money payments  
- **CryptoWalletProcessor**: Processes cryptocurrency transactions

### Account Management (Classes)
- **Account**: Base class with account number and balance management
- **SavingsAccount**: Sealed class that extends Account with insufficient funds validation

### Main Application
- **FinanceApp**: Orchestrates the system and demonstrates functionality
- **Program**: Entry point with Main method

## How to Run

### Option 1: Using .NET Core/5+ (Recommended)
1. Navigate to the FinanceManagementSystem folder
2. Run `dotnet build` to compile the project
3. Run `dotnet run` to execute the application

### Option 2: Using Windows .NET Framework Compiler
1. Open PowerShell or Command Prompt
2. Navigate to the FinanceManagementSystem folder
3. Compile using the .NET Framework C# compiler:
   ```powershell
   & "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:FinanceManagementSystem.exe *.cs
   ```
4. Run the compiled executable:
   ```powershell
   .\FinanceManagementSystem.exe
   ```

**Note**: The code has been made compatible with C# 5 (.NET Framework 4.0) by:
- Converting records to regular classes with immutable properties
- Replacing string interpolation with string concatenation
- Using compatible property declarations

## Architecture Highlights

- **Immutable Classes**: Transaction uses class with private setters for immutability (C# 5 compatible)
- **Interfaces**: ITransactionProcessor enables polymorphic transaction processing
- **Sealed Classes**: SavingsAccount cannot be further inherited
- **Virtual Methods**: Account.ApplyTransaction can be overridden by derived classes
- **Data Integrity**: Balance validation prevents overdrafts in SavingsAccount
- **C# 5 Compatibility**: Code works with older .NET Framework versions
- **Table Formatting**: Results displayed in organized tables for better readability

## Currency
All monetary values are displayed in Ghanaian Cedis (GH₵) with two decimal places.

## Sample Output

When you run the application, you'll see output similar to this:

```
=== Finance Management System ===

Created Savings Account: SAV001 with initial balance: GH₵1000.00

Processing transactions:

Transaction 1: ID=1, Amount=GH₵150.00, Category=Groceries
Processing mobile money payment: GH₵150.00 for Groceries
Transaction applied. Updated balance: GH₵850.00

Transaction 2: ID=2, Amount=GH₵250.00, Category=Utilities
Processing bank transfer: GH₵250.00 for Utilities
Transaction applied. Updated balance: GH₵600.00

Transaction 3: ID=3, Amount=GH₵75.00, Category=Entertainment
Processing crypto wallet transaction: GH₵75.00 for Entertainment
Transaction applied. Updated balance: GH₵525.00

=== Processor Summary Table ===
+----+-------------+----------------+
| ID |  Category   |   Processor    |
+----+-------------+----------------+
| 1  | Groceries   | Mobile Money   |
| 2  | Utilities   | Bank Transfer  |
| 3  | Entertainment| Crypto Wallet  |
+----+-------------+----------------+

=== Transaction Summary ===
Total transactions processed: 3
Final account balance: GH₵525.00

=== Transaction Details Table ===
+----+---------------------+----------+-------------+
| ID |        Date         |  Amount  |  Category   |
+----+---------------------+----------+-------------+
| 1  | 2025-08-06 14:30    | GH₵150.00| Groceries   |
| 2  | 2025-08-06 14:40    | GH₵250.00| Utilities   |
| 3  | 2025-08-06 14:50    | GH₵ 75.00| Entertainment|
+----+---------------------+----------+-------------+

=== Account Summary Table ===
+---------+----------------+
| Account |    Balance     |
+---------+----------------+
| SAV001  | GH₵    525.00 |
+---------+----------------+

Press any key to exit...
```
