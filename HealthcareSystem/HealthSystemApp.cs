using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareSystem
{
    // Main healthcare system application class
    public class HealthSystemApp
    {
        private readonly Repository<Patient> _patientRepo;
        private readonly Repository<Prescription> _prescriptionRepo;
        private readonly Dictionary<int, List<Prescription>> _prescriptionMap;

        public HealthSystemApp()
        {
            _patientRepo = new Repository<Patient>();
            _prescriptionRepo = new Repository<Prescription>();
            _prescriptionMap = new Dictionary<int, List<Prescription>>();
        }

        public void SeedData()
        {
            Console.WriteLine("=== Seeding Healthcare System Data ===");
            
            // Add patients
            _patientRepo.Add(new Patient(1, "Kwame Asante", 35, "Male"));
            _patientRepo.Add(new Patient(2, "Akosua Osei", 28, "Female"));
            _patientRepo.Add(new Patient(3, "Yaa Boateng", 45, "Female"));
            
            // Add prescriptions
            _prescriptionRepo.Add(new Prescription(1, 1, "Paracetamol", new DateTime(2025, 8, 1)));
            _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", new DateTime(2025, 8, 3)));
            _prescriptionRepo.Add(new Prescription(3, 2, "Amoxicillin", new DateTime(2025, 8, 2)));
            _prescriptionRepo.Add(new Prescription(4, 2, "Vitamin D", new DateTime(2025, 8, 4)));
            _prescriptionRepo.Add(new Prescription(5, 3, "Lisinopril", new DateTime(2025, 8, 5)));
            
            Console.WriteLine("Data seeded successfully!");
            Console.WriteLine();
        }

        public void BuildPrescriptionMap()
        {
            Console.WriteLine("=== Building Prescription Map ===");
            
            // Clear existing map
            _prescriptionMap.Clear();
            
            // Group prescriptions by PatientId
            var allPrescriptions = _prescriptionRepo.GetAll();
            foreach (var prescription in allPrescriptions)
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }
                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
            
            Console.WriteLine("Prescription map built successfully!");
            Console.WriteLine("Patients with prescriptions: " + _prescriptionMap.Count);
            Console.WriteLine();
        }

        public void PrintAllPatients()
        {
            Console.WriteLine("=== All Patients ===");
            Console.WriteLine("+----+----------------+-----+--------+");
            Console.WriteLine("| ID |      Name      | Age | Gender |");
            Console.WriteLine("+----+----------------+-----+--------+");
            
            var patients = _patientRepo.GetAll();
            foreach (var patient in patients)
            {
                Console.WriteLine("| " + patient.Id.ToString().PadRight(2) + " | " + 
                    patient.Name.PadRight(14) + " | " + 
                    patient.Age.ToString().PadRight(3) + " | " + 
                    patient.Gender.PadRight(6) + " |");
            }
            Console.WriteLine("+----+----------------+-----+--------+");
            Console.WriteLine("Total patients: " + patients.Count);
            Console.WriteLine();
        }

        public void PrintPrescriptionsForPatient(int patientId)
        {
            Console.WriteLine("=== Prescriptions for Patient ID: " + patientId + " ===");
            
            // Get patient info first
            var patient = _patientRepo.GetById(p => p.Id == patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found!");
                return;
            }
            
            Console.WriteLine("Patient: " + patient.Name);
            Console.WriteLine();
            
            // Get prescriptions from map
            if (_prescriptionMap.ContainsKey(patientId) && _prescriptionMap[patientId].Count > 0)
            {
                Console.WriteLine("+----+----------------+------------+");
                Console.WriteLine("| ID |   Medication   |    Date    |");
                Console.WriteLine("+----+----------------+------------+");
                
                foreach (var prescription in _prescriptionMap[patientId])
                {
                    Console.WriteLine("| " + prescription.Id.ToString().PadRight(2) + " | " + 
                        prescription.MedicationName.PadRight(14) + " | " + 
                        prescription.DateIssued.ToString("yyyy-MM-dd") + " |");
                }
                Console.WriteLine("+----+----------------+------------+");
                Console.WriteLine("Total prescriptions: " + _prescriptionMap[patientId].Count);
            }
            else
            {
                Console.WriteLine("No prescriptions found for this patient.");
            }
            Console.WriteLine();
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            if (_prescriptionMap.ContainsKey(patientId))
            {
                return new List<Prescription>(_prescriptionMap[patientId]);
            }
            return new List<Prescription>();
        }

        public void PrintSystemSummary()
        {
            Console.WriteLine("=== Healthcare System Summary ===");
            Console.WriteLine("Total Patients: " + _patientRepo.GetAll().Count);
            Console.WriteLine("Total Prescriptions: " + _prescriptionRepo.GetAll().Count);
            Console.WriteLine("Patients with Prescriptions: " + _prescriptionMap.Count);
            Console.WriteLine();
            
            // Summary table
            Console.WriteLine("=== Patient-Prescription Summary ===");
            Console.WriteLine("+----+----------------+---------------+");
            Console.WriteLine("| ID |      Name      | Prescriptions |");
            Console.WriteLine("+----+----------------+---------------+");
            
            var patients = _patientRepo.GetAll();
            foreach (var patient in patients)
            {
                int prescriptionCount = _prescriptionMap.ContainsKey(patient.Id) ? 
                    _prescriptionMap[patient.Id].Count : 0;
                Console.WriteLine("| " + patient.Id.ToString().PadRight(2) + " | " + 
                    patient.Name.PadRight(14) + " | " + 
                    prescriptionCount.ToString().PadLeft(13) + " |");
            }
            Console.WriteLine("+----+----------------+---------------+");
        }
    }
}
