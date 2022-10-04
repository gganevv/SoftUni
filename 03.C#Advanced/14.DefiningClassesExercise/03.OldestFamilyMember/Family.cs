using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public List<Person> People { get { return people; } set { people = value; } }

        public void AddMember(Person person)
        {
            this.People.Add(person);
        }

        public void GetOldestMember()
        {
            Console.WriteLine(People.OrderByDescending(x => x.Age).First());
        }
    }
}
