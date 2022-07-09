namespace _05.Students2._0
{
    public class Student
    {
        public Student(string firstName, string lastName, int age, string town)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Town = town;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
    }
}
