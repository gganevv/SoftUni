using System;
using System.Linq;

class AddVat
{
    static void Main()
    {
        Func<double, double> addVat = x => x * 1.2;
        double[] nums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
        double[] numsPlusVat = nums.Select(x => addVat(x)).ToArray();

        Array.ForEach(numsPlusVat, x => Console.WriteLine($"{x:f2}"));
    }
}