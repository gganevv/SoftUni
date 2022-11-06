namespace BirthdayCelebrations.Models
{
    using BirthdayCelebrations.Models.Interfaces;
    public class Pet : IPet
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }

        public string BirthDate { get; private set; }
    }
}
