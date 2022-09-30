using System;

class ActionPrint
{
    static void Main()
    {
        Action<string[]> printNames = (names) =>
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        };

        string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        printNames(names);
    }
}