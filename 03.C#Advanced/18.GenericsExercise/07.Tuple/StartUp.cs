using System;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main()
        {
            string[] personDetails = Console.ReadLine().Split();
            string personFirstName = personDetails[0] + " " + personDetails[1];
            string personAddres = personDetails[2];
            Tuple<string, string> personTuple = new Tuple<string, string>(personFirstName, personAddres);
            Console.WriteLine(personTuple);

            string[] beerDetails = Console.ReadLine().Split();
            string drinkerName = beerDetails[0];
            int drinkQuantity = int.Parse(beerDetails[1]);
            Tuple<string, int> beerTuple = new Tuple<string, int>(drinkerName, drinkQuantity);
            Console.WriteLine(beerTuple);

            string[] numsDetails = Console.ReadLine().Split();
            int intNum = int.Parse(numsDetails[0]);
            double doubleNum = double.Parse(numsDetails[1]);
            Tuple<int, double> numTuple = new Tuple<int, double>(intNum, doubleNum);
            Console.WriteLine(numTuple);
        }
    }
}
