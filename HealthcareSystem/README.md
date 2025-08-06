# Healthcare Management System

This is a C# healthcare management system that demonstrates the use of Collections (List, Dictionary) and Generics to manage patient records and prescriptions with type safety and scalability.

## Features

### Generic Repository Pattern
- **Repository<T>**: Generic class for entity storage and retrieval
  - Add, GetAll, GetById, Remove operations
  - Type-safe operations for any entity type
  - LINQ-based querying with predicates

### Entity Classes
- **Patient**: Represents patient information with Id, Name, Age, Gender
- **Prescription**: Represents prescription data with Id, PatientId, MedicationName, DateIssued

### Collections Management
- **List<T>**: Used in Repository for entity storage
- **Dictionary<int, List<Prescription>>**: Maps PatientId to their prescriptions for fast lookup
- **LINQ**: Used for querying and data manipulation

### Main Application
- **HealthSystemApp**: Main application logic with repositories and prescription mapping
- **Program**: Entry point demonstrating the system functionality

## How to Run

### Option 1: Using .NET Core/5+ (Recommended)
1. Navigate to the HealthcareSystem folder
2. Run `dotnet build` to compile the project
3. Run `dotnet run` to execute the application

### Option 2: Using Windows .NET Framework Compiler
1. Open PowerShell or Command Prompt
2. Navigate to the HealthcareSystem folder
3. Compile using the .NET Framework C# compiler:
   ```powershell
   & "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:HealthcareSystem.exe *.cs
   ```
4. Run the compiled executable:
   ```powershell
   .\HealthcareSystem.exe
   ```

## Architecture Highlights

- **Generic Repository**: Type-safe data access layer using generics
- **Collections**: Dictionary for efficient patient-prescription mapping
- **LINQ Integration**: Functional querying with lambda expressions
- **Immutable Entities**: Properties with private setters for data integrity
- **Table Formatting**: Professional output display with formatted tables
- **C# 5 Compatibility**: Works with older .NET Framework versions

## Sample Output

When you run the application, you'll see output similar to this:

```
=== Healthcare Management System ===

=== Seeding Healthcare System Data ===
Data seeded successfully!

=== Building Prescription Map ===
Prescription map built successfully!
Patients with prescriptions: 3

=== All Patients ===
+----+----------------+-----+--------+
| ID |      Name      | Age | Gender |
+----+----------------+-----+--------+
| 1  | Kwame Asante   | 35  | Male   |
| 2  | Akosua Osei    | 28  | Female |
| 3  | Yaa Boateng    | 45  | Female |
+----+----------------+-----+--------+
Total patients: 3

=== Prescriptions for Patient ID: 1 ===
Patient: Kwame Asante

+----+----------------+------------+
| ID |   Medication   |    Date    |
+----+----------------+------------+
| 1  | Paracetamol    | 2025-08-01 |
| 2  | Ibuprofen      | 2025-08-03 |
+----+----------------+------------+
Total prescriptions: 2

=== Healthcare System Summary ===
Total Patients: 3
Total Prescriptions: 5
Patients with Prescriptions: 3

=== Patient-Prescription Summary ===
+----+----------------+---------------+
| ID |      Name      | Prescriptions |
+----+----------------+---------------+
| 1  | Kwame Asante   |             2 |
| 2  | Akosua Osei    |             2 |
| 3  | Yaa Boateng    |             1 |
+----+----------------+---------------+

Press any key to exit...
```

## Key Concepts Demonstrated

1. **Generics**: Repository<T> provides type-safe operations for any entity type
2. **Collections**: List<T> for storage, Dictionary<K,V> for fast lookups
3. **LINQ**: FirstOrDefault, Where clauses for querying
4. **Functional Programming**: Func<T, bool> predicates for flexible queries
5. **Data Relationships**: One-to-many mapping between patients and prescriptions
6. **Scalability**: Easy to extend with new entity types using the same repository pattern
