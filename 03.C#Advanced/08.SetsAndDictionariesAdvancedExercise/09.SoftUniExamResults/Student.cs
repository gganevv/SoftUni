namespace _09.SoftUniExamResults
{
    public class Student
    {
        public Student(string name, Submission submission)
        {
            Name = name;
            Submission = submission;
        }
        public string Name { get; set; }
        public Submission Submission { get; set; }
    }
}
