using System;

namespace HealthcareSystem
{
    // Prescription entity class
    public class Prescription
    {
        public int Id { get; private set; }
        public int PatientId { get; private set; }
        public string MedicationName { get; private set; }
        public DateTime DateIssued { get; private set; }

        public Prescription(int id, int patientId, string medicationName, DateTime dateIssued)
        {
            Id = id;
            PatientId = patientId;
            MedicationName = medicationName;
            DateIssued = dateIssued;
        }

        public override string ToString()
        {
            return "ID: " + Id + ", PatientID: " + PatientId + ", Medication: " + MedicationName + 
                   ", Date: " + DateIssued.ToString("yyyy-MM-dd");
        }
    }
}
