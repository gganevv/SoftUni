using System;

namespace _01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] inputArgs = input.Split(":");
                switch (inputArgs[0])
                {
                    case "Add Stop":
                        stops = AddStop(int.Parse(inputArgs[1]), inputArgs[2], stops);
                        break;
                    case "Remove Stop":
                        stops = RemoveStop(int.Parse(inputArgs[1]), int.Parse(inputArgs[2]), stops);
                        break;
                    case "Switch":
                        stops = SwitchStops(inputArgs[1], inputArgs[2], stops);
                        break;
                    default:
                        break;
                }
                Console.WriteLine(stops);

                input = Console.ReadLine();
            }




            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        static string AddStop(int index, string newStop, string stops)
        {
            if (index >= 0 && index < stops.Length)
            {
                stops = stops.Insert(index, newStop);
            }

            return stops;
        }

        private static string RemoveStop(int startIndex, int endIndex, string stops)
        {
            if (startIndex >= 0 && startIndex < stops.Length && endIndex >= 0 && endIndex < stops.Length)
            {
                stops = stops.Remove(startIndex, endIndex - startIndex + 1);
            }

            return stops;
        }

        private static string SwitchStops(string oldStop, string newStop, string stops)
        {
            if (stops.Contains(oldStop))
            {
                stops = stops.Replace(oldStop, newStop);
            }

            return stops;
        }
    }
}
