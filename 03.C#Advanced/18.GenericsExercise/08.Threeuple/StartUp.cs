using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            string[] personDetails = Console.ReadLine().Split();
            string personFirstName = personDetails[0] + " " + personDetails[1];
            string personAddres = personDetails[2];
            string personTown = personDetails[3];
            Threeuple<string, string, string> personTuple = new Threeuple<string, string, string>(personFirstName, personAddres, personTown);
            Console.WriteLine(personTuple);

            string[] beerDetails = Console.ReadLine().Split();
            string drinkerName = beerDetails[0];
            int drinkQuantity = int.Parse(beerDetails[1]);
            bool drunk = beerDetails[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> beerTuple = new Threeuple<string, int, bool>(drinkerName, drinkQuantity, drunk);
            Console.WriteLine(beerTuple);

            string[] bankDetails = Console.ReadLine().Split();
            string holderName = bankDetails[0];
            double bankBalance = double.Parse(bankDetails[1]);
            string bankName = bankDetails[2];
            Threeuple<string, double, string> numTuple = new Threeuple<string, double, string>(holderName, bankBalance, bankName);
            Console.WriteLine(numTuple);
        }
    }
}
