namespace SchoolGradingSystem
{
    // Student class representing a student with grading functionality
    public class Student
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public int Score { get; private set; }

        public Student(int id, string fullName, int score)
        {
            Id = id;
            FullName = fullName;
            Score = score;
        }

        public string GetGrade()
        {
            if (Score >= 80 && Score <= 100)
                return "A";
            else if (Score >= 70 && Score <= 79)
                return "B";
            else if (Score >= 60 && Score <= 69)
                return "C";
            else if (Score >= 50 && Score <= 59)
                return "D";
            else
                return "F";
        }

        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + FullName + ", Score: " + Score + ", Grade: " + GetGrade();
        }
    }
}
