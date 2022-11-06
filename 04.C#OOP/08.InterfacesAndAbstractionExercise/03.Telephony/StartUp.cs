namespace Telephony
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            StationaryPhone stationaryPhone = new StationaryPhone();
            SmartPhone smartPhone = new SmartPhone();

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] webSites = Console.ReadLine().Split();

            foreach (var number in phoneNumbers)
            {
                if (!number.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (number.Length == 10)
                {
                    smartPhone.Call(number);
                }
                else if (number.Length == 7)
                {
                    stationaryPhone.Call(number);
                }
            }

            foreach (var website in webSites)
            {
                if (website.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartPhone.Browse(website);
                }
                
            }
        }
    }
}
