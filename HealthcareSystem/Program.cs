using System;

namespace HealthcareSystem
{
    // Entry point for the Healthcare Management System
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Healthcare Management System ===");
                Console.WriteLine();

                // Instantiate the healthcare system app
                var healthApp = new HealthSystemApp();

                // Seed data
                healthApp.SeedData();

                // Build prescription map
                healthApp.BuildPrescriptionMap();

                // Print all patients
                healthApp.PrintAllPatients();

                // Print prescriptions for specific patients
                healthApp.PrintPrescriptionsForPatient(1); // Kwame Asante
                healthApp.PrintPrescriptionsForPatient(2); // Akosua Osei

                // Print system summary
                healthApp.PrintSystemSummary();

                Console.WriteLine("=== Healthcare System Demo Complete ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
