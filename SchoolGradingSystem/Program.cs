using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingSystem
{
    // Entry point for the School Grading System
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== School Grading System ===");
            Console.WriteLine();

            var processor = new StudentResultProcessor();

            // Test with valid data
            ProcessStudentFile(processor, "students_input.txt", "grade_report.txt");

            Console.WriteLine();
            Console.WriteLine("=== Testing Error Handling ===");
            Console.WriteLine();

            // Test with file containing errors
            ProcessStudentFile(processor, "students_with_errors.txt", "error_report.txt");

            Console.WriteLine();

            // Test with non-existent file
            ProcessStudentFile(processor, "nonexistent_file.txt", "missing_report.txt");

            Console.WriteLine();
            Console.WriteLine("=== School Grading System Demo Complete ===");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void ProcessStudentFile(StudentResultProcessor processor, string inputFile, string outputFile)
        {
            try
            {
                Console.WriteLine("Processing file: " + inputFile);
                Console.WriteLine("Output will be written to: " + outputFile);
                Console.WriteLine();

                // Read students from file
                var students = processor.ReadStudentsFromFile(inputFile);

                Console.WriteLine();

                // Write report to file
                processor.WriteReportToFile(students, outputFile);

                Console.WriteLine();
                Console.WriteLine("File processing completed successfully!");

                // Display summary
                Console.WriteLine();
                Console.WriteLine("=== Processing Summary ===");
                Console.WriteLine("Students processed: " + students.Count);
                
                if (students.Count > 0)
                {
                    var gradeCount = new Dictionary<string, int>
                    {
                        {"A", 0}, {"B", 0}, {"C", 0}, {"D", 0}, {"F", 0}
                    };

                    foreach (var student in students)
                    {
                        gradeCount[student.GetGrade()]++;
                    }

                    Console.WriteLine("Grade Distribution:");
                    foreach (var grade in gradeCount)
                    {
                        if (grade.Value > 0)
                        {
                            Console.WriteLine("  Grade " + grade.Key + ": " + grade.Value + " students");
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ERROR: File not found!");
                Console.WriteLine("Details: " + ex.Message);
                Console.WriteLine("Please ensure the input file exists and try again.");
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine("ERROR: Invalid score format detected!");
                Console.WriteLine("Details: " + ex.Message);
                Console.WriteLine("Please check the input file for non-numeric scores or scores outside the valid range (0-100).");
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine("ERROR: Missing field detected!");
                Console.WriteLine("Details: " + ex.Message);
                Console.WriteLine("Please ensure each line has exactly 3 fields: ID, Name, Score separated by commas.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("ERROR: Access denied!");
                Console.WriteLine("Details: " + ex.Message);
                Console.WriteLine("Please check file permissions and try again.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("ERROR: File I/O error!");
                Console.WriteLine("Details: " + ex.Message);
                Console.WriteLine("There was a problem reading or writing the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: An unexpected error occurred!");
                Console.WriteLine("Details: " + ex.Message);
                Console.WriteLine("Please contact support if this problem persists.");
                
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner exception: " + ex.InnerException.Message);
                }
            }
        }
    }
}
