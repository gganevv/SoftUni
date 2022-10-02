using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Func<string, int, bool> checkNameSum = (name, sum) =>
                name.Sum(x => x) >= sum;

        Func<string[], int, Func<string, int, bool>, string> getName = (names, sum, match) =>
            names.FirstOrDefault(name => match(name, sum));

        int sum = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine(getName(names, sum, checkNameSum));
    }
}