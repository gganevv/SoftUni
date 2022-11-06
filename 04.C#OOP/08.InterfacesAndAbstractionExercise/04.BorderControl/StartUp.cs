namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using BorderControl.Models;
    using BorderControl.Models.Interfaces;
    public class StartUp
    {
        static void Main()
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();
                if (inputArgs.Length == 3)
                {
                    identifiables.Add(new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]));
                }
                else
                {
                    identifiables.Add(new Robot(inputArgs[0], inputArgs[1]));
                }
            }

            string fakeIdEnd = Console.ReadLine();
            foreach (var idnt in identifiables)
            {
                if (idnt.Id.EndsWith(fakeIdEnd))
                {
                    Console.WriteLine(idnt.Id);
                }
            }
        }
    }
}
