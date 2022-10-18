using System;
using System.Diagnostics.CodeAnalysis;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                return this.Age.CompareTo(other.Age);
            }
            return this.Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null)
            {
                return false;
            }

            return Name == other.Name && Age == other.Age;
        }

        public override int GetHashCode()
        {
            int hashCode = Name.GetHashCode() + Age.GetHashCode();

            return hashCode;
        }
    }
}
