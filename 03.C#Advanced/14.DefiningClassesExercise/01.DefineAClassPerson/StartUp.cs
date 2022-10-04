using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person person1 = new Person();
            person1.Name = "Pesho";
            person1.Age = 99;

            Person person2 = new Person() { Name = "Ivan", Age = 22 };
        }
    }
}
