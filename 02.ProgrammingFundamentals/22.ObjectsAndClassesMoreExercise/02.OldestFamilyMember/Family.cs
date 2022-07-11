using System.Collections.Generic;

namespace _02.OldestFamilyMember
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void AddMember(Person person)
        {
            People.Add(person);
        }

        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;
            Person oldestPerson = null;
            foreach (var person in People)
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    oldestPerson = person;
                }
            }

            return oldestPerson;
        }

    }
}
