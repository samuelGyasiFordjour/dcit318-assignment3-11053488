using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InventoryRecordsSystem
{
    // Generic inventory logger with file operations
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private readonly List<T> _log;
        private readonly string _filePath;

        public InventoryLogger(string filePath)
        {
            _log = new List<T>();
            _filePath = filePath;
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item", "Item cannot be null");

            _log.Add(item);
            Console.WriteLine("Added to log: " + item.ToString());
        }

        public List<T> GetAll()
        {
            return new List<T>(_log); // Return a copy to maintain immutability
        }

        public void SaveToFile()
        {
            try
            {
                Console.WriteLine("Saving inventory data to file: " + _filePath);

                using (var writer = new StreamWriter(_filePath, false, Encoding.UTF8))
                {
                    // Write header
                    writer.WriteLine("=== INVENTORY DATA ===");
                    writer.WriteLine("Saved on: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine("Total Items: " + _log.Count);
                    writer.WriteLine();

                    // Write data header
                    writer.WriteLine("INVENTORY ITEMS:");
                    writer.WriteLine("================");

                    // Write each item (assuming T is InventoryItem for serialization)
                    foreach (var item in _log)
                    {
                        var inventoryItem = item as InventoryItem;
                        if (inventoryItem != null)
                        {
                            writer.WriteLine(inventoryItem.Id + "|" + 
                                           inventoryItem.Name + "|" + 
                                           inventoryItem.Quantity + "|" + 
                                           inventoryItem.DateAdded.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            writer.WriteLine("Generic Item ID: " + item.Id);
                        }
                    }
                }

                Console.WriteLine("Successfully saved " + _log.Count + " items to " + _filePath);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("ERROR: Access denied while saving to file.");
                Console.WriteLine("Details: " + ex.Message);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("ERROR: Directory not found.");
                Console.WriteLine("Details: " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine("ERROR: I/O error occurred while saving file.");
                Console.WriteLine("Details: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Unexpected error occurred while saving.");
                Console.WriteLine("Details: " + ex.Message);
                throw;
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("File not found: " + _filePath);
                    Console.WriteLine("Starting with empty inventory log.");
                    return;
                }

                Console.WriteLine("Loading inventory data from file: " + _filePath);
                _log.Clear();

                using (var reader = new StreamReader(_filePath, Encoding.UTF8))
                {
                    string line;
                    bool dataSection = false;
                    int loadedCount = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        // Skip header lines until we reach the data section
                        if (line == "INVENTORY ITEMS:")
                        {
                            // Skip the separator line
                            reader.ReadLine();
                            dataSection = true;
                            continue;
                        }

                        if (!dataSection || string.IsNullOrWhiteSpace(line))
                            continue;

                        try
                        {
                            // Parse the line (assuming T is InventoryItem)
                            string[] parts = line.Split('|');
                            if (parts.Length >= 4)
                            {
                                int id = int.Parse(parts[0]);
                                string name = parts[1];
                                int quantity = int.Parse(parts[2]);
                                DateTime dateAdded = DateTime.Parse(parts[3]);

                                // This assumes T is InventoryItem - in a real generic scenario,
                                // you'd need a factory pattern or deserialization interface
                                var item = new InventoryItem(id, name, quantity, dateAdded);
                                _log.Add((T)(object)item);
                                loadedCount++;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("WARNING: Skipping malformed line: " + line);
                            Console.WriteLine("Format error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("WARNING: Error processing line: " + line);
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }

                    Console.WriteLine("Successfully loaded " + loadedCount + " items from " + _filePath);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ERROR: File not found.");
                Console.WriteLine("Details: " + ex.Message);
                Console.WriteLine("Starting with empty inventory log.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("ERROR: Access denied while reading file.");
                Console.WriteLine("Details: " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine("ERROR: I/O error occurred while reading file.");
                Console.WriteLine("Details: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Unexpected error occurred while loading.");
                Console.WriteLine("Details: " + ex.Message);
                throw;
            }
        }

        public void ClearLog()
        {
            _log.Clear();
            Console.WriteLine("Inventory log cleared.");
        }

        public int Count
        {
            get { return _log.Count; }
        }
    }
}
