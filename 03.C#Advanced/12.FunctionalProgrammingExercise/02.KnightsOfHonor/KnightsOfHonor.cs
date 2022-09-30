using System;

class KnightsOfHonor
{
    static void Main()
    {
        Action<string[]> appendTitle = (names) =>
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        };

        string[] names = Console.ReadLine().Split();
        appendTitle(names);
    }
}