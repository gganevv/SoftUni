using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < countOfPeople; i++)
            {
                string[] args = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = args[0];
                int age = int.Parse(args[1]);
                family.AddMember(new Person(name, age));
            }

            family.GetOldestMember();
        }
    }
}
