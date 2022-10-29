using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name 
        { 
            get => name;
            set
            {
                if (!string.IsNullOrEmpty(value)) name = value;
                else throw new ArgumentException("Invalid input!");
            }
        }
        public int Age
        {
            get => age;

            set
            {
                if (value >= 0) age = value;
                else throw new ArgumentException("Invalid input!");
            }
        }
        public string Gender 
        {
            get => gender;
            set
            {
                if (!string.IsNullOrEmpty(value)) gender = value;
                else throw new ArgumentException("Invalid input!");
            }
        }

        public virtual string ProduceSound() => "Make sound.";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine($"{ProduceSound()}");

            return sb.ToString().Trim();
        }

    }
}