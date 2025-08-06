namespace HealthcareSystem
{
    // Patient entity class
    public class Patient
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }

        public Patient(int id, string name, int age, string gender)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
        }

        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + Name + ", Age: " + Age + ", Gender: " + Gender;
        }
    }
}
