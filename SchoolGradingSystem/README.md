# School Grading System

This is a C# school grading system that demonstrates file I/O operations, custom exception handling, and data validation. The system reads student data from a text file, validates it, assigns grades, and generates a comprehensive report.

## Features

### Student Management
- **Student Class**: Represents student with Id, FullName, and Score
- **Automatic Grading**: Converts numeric scores to letter grades (A-F)
- **Grade Scale**: A(80-100), B(70-79), C(60-69), D(50-59), F(below 50)

### File Processing
- **Input Processing**: Reads comma-separated values from text files
- **Data Validation**: Validates field count, data types, and ranges
- **Report Generation**: Creates formatted reports with statistics

### Exception Handling
- **Custom Exceptions**:
  - `InvalidScoreFormatException`: Non-numeric or out-of-range scores
  - `MissingFieldException`: Incomplete student records
- **Built-in Exceptions**:
  - `FileNotFoundException`: Missing input files
  - `IOException`: File access problems
  - `UnauthorizedAccessException`: Permission issues

### Report Features
- Student results with grades
- Grade distribution statistics
- Score analytics (average, highest, lowest)
- Professional formatting with headers and sections

## How to Run

### Option 1: Using .NET Core/5+ (Recommended)
1. Navigate to the SchoolGradingSystem folder
2. Run `dotnet build` to compile the project
3. Run `dotnet run` to execute the application

### Option 2: Using Windows .NET Framework Compiler
1. Open PowerShell or Command Prompt
2. Navigate to the SchoolGradingSystem folder
3. Compile using the .NET Framework C# compiler:
   ```powershell
   & "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:SchoolGradingSystem.exe *.cs
   ```
4. Run the compiled executable:
   ```powershell
   .\SchoolGradingSystem.exe
   ```

## Input File Format

The input file should contain student data in CSV format:
```
StudentID, Full Name, Score
101, Alice Smith, 84
102, Bob Johnson, 76
103, Carol Williams, 92
```

### Requirements:
- Each line must have exactly 3 fields separated by commas
- Student ID must be a valid integer
- Score must be a valid integer (0-100)
- Full name cannot be empty

## Sample Files

The project includes sample input files:
- `students_input.txt`: Valid student data for normal processing
- `students_with_errors.txt`: Contains various errors for testing exception handling

## Architecture Highlights

- **File I/O**: StreamReader and StreamWriter with using statements
- **Exception Hierarchy**: Custom exceptions inheriting from System.Exception
- **Data Validation**: Multi-layer validation with specific error messages
- **Resource Management**: Proper disposal of file handles
- **Error Recovery**: Graceful handling of various error conditions
- **Statistics Generation**: Automatic calculation of grade distributions and scores

## Sample Output

### Console Output:
```
=== School Grading System ===

Processing file: students_input.txt
Output will be written to: grade_report.txt

Reading students from file: students_input.txt
Processed: ID: 101, Name: Alice Smith, Score: 84, Grade: A
Processed: ID: 102, Name: Bob Johnson, Score: 76, Grade: B
...
Successfully read 10 students from file.

Writing report to file: grade_report.txt
Report successfully written to grade_report.txt

File processing completed successfully!

=== Processing Summary ===
Students processed: 10
Grade Distribution:
  Grade A: 3 students
  Grade B: 2 students
  Grade C: 2 students
  Grade D: 1 students
  Grade F: 2 students
```

### Generated Report File:
```
=== STUDENT GRADE REPORT ===
Generated on: 2025-08-06 15:30:00
Total Students: 10

STUDENT RESULTS:
================
Alice Smith (ID: 101): Score = 84, Grade = A
Bob Johnson (ID: 102): Score = 76, Grade = B
Carol Williams (ID: 103): Score = 92, Grade = A
...

GRADE DISTRIBUTION:
==================
Grade A: 3 students
Grade B: 2 students
Grade C: 2 students
Grade D: 1 students
Grade F: 2 students

STATISTICS:
===========
Average Score: 73.10
Highest Score: 97
Lowest Score: 45
```

### Error Handling Examples:
```
=== Testing Error Handling ===

ERROR: Invalid score format detected!
Details: Line 2: Invalid score format 'abc'. Score must be a number.
Please check the input file for non-numeric scores or scores outside the valid range (0-100).

ERROR: Missing field detected!
Details: Line 3 has 2 fields, expected 3. Content: '103, Carol Williams'
Please ensure each line has exactly 3 fields: ID, Name, Score separated by commas.

ERROR: File not found!
Details: Could not find file 'nonexistent_file.txt'.
Please ensure the input file exists and try again.
```

## Key Concepts Demonstrated

1. **File I/O Operations**: Reading from and writing to text files
2. **Custom Exception Design**: Domain-specific error types with meaningful messages
3. **Exception Handling Strategy**: Try-catch blocks with specific exception types
4. **Data Validation**: Multi-level validation with clear error reporting
5. **Resource Management**: Using statements for automatic resource disposal
6. **String Processing**: Parsing CSV data and handling whitespace
7. **Collections**: Using List<T> and Dictionary<K,V> for data management
8. **Object-Oriented Design**: Separation of concerns between classes
9. **Error Recovery**: Graceful degradation when encountering problems
10. **Professional Reporting**: Formatted output with statistics and summaries

## Exception Handling Best Practices

The system demonstrates proper exception handling:
- **Specific Exceptions**: Catch most specific exceptions first
- **Custom Messages**: Provide context-specific error information
- **Error Logging**: Display helpful information for troubleshooting
- **Graceful Recovery**: Continue processing when possible
- **Resource Cleanup**: Ensure files are properly closed even on errors
