using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ForceBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Side> sides = new HashSet<Side>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string forceSide = input.Split(" | ").First();
                    string user = input.Split(" | ").Last();
                    if (!sides.Any(x => x.Name == forceSide))
                    {
                        sides.Add(new Side(forceSide));
                    }
                    Side side = sides.FirstOrDefault(x => x.Name == forceSide);

                    if (!UserExist(user, sides))
                    {
                        side.Memebers.Add(user);
                    }
                }
                else if (input.Contains("->"))
                {
                    string user = input.Split(" -> ").First();
                    string forceSide = input.Split(" -> ").Last();

                    if (!sides.Any(x => x.Name == forceSide))
                    {
                        sides.Add(new Side(forceSide));
                    }
                    Side side = sides.FirstOrDefault(x => x.Name == forceSide);

                    if (UserExist(user, sides))
                    {
                        Side oldSide = sides.FirstOrDefault(x => x.Memebers.Contains(user));
                        oldSide.Memebers.Remove(user);
                        side.Memebers.Add(user);
                    }
                    else
                    {
                        side.Memebers.Add(user);
                    }
                    Console.WriteLine($"{user} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var side in sides.OrderByDescending(x => x.Memebers.Count).ThenBy(x => x.Name))
            {
                if (side.Memebers.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Name}, Members: {side.Memebers.Count}");
                    foreach (var user in side.Memebers.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }

        private static bool UserExist(string user, HashSet<Side> sides)
        {
            foreach (var side in sides)
            {
                foreach (var u in side.Memebers)
                {
                    if (u == user)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}