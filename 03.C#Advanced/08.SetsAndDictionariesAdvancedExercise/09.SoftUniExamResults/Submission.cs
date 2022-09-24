namespace _09.SoftUniExamResults
{
    public class Submission
    {
        public Submission(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public Submission(string name)
        {
            Name = name;
            Count = 1;
        }

        public string Name { get; set; }
        public int Points { get; set; }
        public int Count { get; set; }
    }
}
