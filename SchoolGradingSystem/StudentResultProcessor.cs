using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingSystem
{
    // Class to process student results from file input/output
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();
            int lineNumber = 0;

            Console.WriteLine("Reading students from file: " + inputFilePath);

            using (var reader = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    try
                    {
                        // Split the line by comma
                        string[] fields = line.Split(',');

                        // Validate number of fields
                        if (fields.Length != 3)
                        {
                            throw new MissingFieldException(
                                "Line " + lineNumber + " has " + fields.Length + 
                                " fields, expected 3. Content: '" + line + "'");
                        }

                        // Trim whitespace from fields
                        string idStr = fields[0].Trim();
                        string fullName = fields[1].Trim();
                        string scoreStr = fields[2].Trim();

                        // Validate that fields are not empty
                        if (string.IsNullOrEmpty(idStr) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(scoreStr))
                        {
                            throw new MissingFieldException(
                                "Line " + lineNumber + " contains empty fields. Content: '" + line + "'");
                        }

                        // Parse ID
                        int id;
                        if (!int.TryParse(idStr, out id))
                        {
                            throw new InvalidScoreFormatException(
                                "Line " + lineNumber + ": Invalid ID format '" + idStr + "'. ID must be a number.");
                        }

                        // Parse score
                        int score;
                        if (!int.TryParse(scoreStr, out score))
                        {
                            throw new InvalidScoreFormatException(
                                "Line " + lineNumber + ": Invalid score format '" + scoreStr + "'. Score must be a number.");
                        }

                        // Validate score range (optional but good practice)
                        if (score < 0 || score > 100)
                        {
                            throw new InvalidScoreFormatException(
                                "Line " + lineNumber + ": Score " + score + " is out of valid range (0-100).");
                        }

                        // Create student object
                        var student = new Student(id, fullName, score);
                        students.Add(student);

                        Console.WriteLine("Processed: " + student.ToString());
                    }
                    catch (InvalidScoreFormatException)
                    {
                        throw; // Re-throw custom exceptions
                    }
                    catch (MissingFieldException)
                    {
                        throw; // Re-throw custom exceptions
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Line " + lineNumber + ": Unexpected error processing line '" + line + "'. " + ex.Message);
                    }
                }
            }

            Console.WriteLine("Successfully read " + students.Count + " students from file.");
            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            Console.WriteLine("Writing report to file: " + outputFilePath);

            using (var writer = new StreamWriter(outputFilePath))
            {
                // Write header
                writer.WriteLine("=== STUDENT GRADE REPORT ===");
                writer.WriteLine("Generated on: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteLine("Total Students: " + students.Count);
                writer.WriteLine();

                // Write student details
                writer.WriteLine("STUDENT RESULTS:");
                writer.WriteLine("================");
                
                foreach (var student in students)
                {
                    writer.WriteLine(student.FullName + " (ID: " + student.Id + "): Score = " + 
                                   student.Score + ", Grade = " + student.GetGrade());
                }

                // Write grade distribution
                writer.WriteLine();
                writer.WriteLine("GRADE DISTRIBUTION:");
                writer.WriteLine("==================");
                
                var gradeCount = new Dictionary<string, int>
                {
                    {"A", 0}, {"B", 0}, {"C", 0}, {"D", 0}, {"F", 0}
                };

                foreach (var student in students)
                {
                    gradeCount[student.GetGrade()]++;
                }

                foreach (var grade in gradeCount)
                {
                    writer.WriteLine("Grade " + grade.Key + ": " + grade.Value + " students");
                }

                // Write statistics
                writer.WriteLine();
                writer.WriteLine("STATISTICS:");
                writer.WriteLine("===========");
                
                if (students.Count > 0)
                {
                    int totalScore = 0;
                    int highestScore = students[0].Score;
                    int lowestScore = students[0].Score;

                    foreach (var student in students)
                    {
                        totalScore += student.Score;
                        if (student.Score > highestScore)
                            highestScore = student.Score;
                        if (student.Score < lowestScore)
                            lowestScore = student.Score;
                    }

                    double averageScore = (double)totalScore / students.Count;

                    writer.WriteLine("Average Score: " + averageScore.ToString("F2"));
                    writer.WriteLine("Highest Score: " + highestScore);
                    writer.WriteLine("Lowest Score: " + lowestScore);
                }
            }

            Console.WriteLine("Report successfully written to " + outputFilePath);
        }
    }
}
