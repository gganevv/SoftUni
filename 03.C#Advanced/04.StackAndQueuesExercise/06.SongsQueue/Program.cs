using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] initialSongs = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(initialSongs);

            while (songs.Any())
            {
                List<string> command = Console.ReadLine().Split().ToList();
                switch (command[0])
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        AddSong(command, songs);
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }

        private static void AddSong(List<string> command, Queue<string> songs)
        {
            command.RemoveAt(0);
            string currentSong = string.Join(" ", command);
            if (!songs.Contains(currentSong))
            {
                songs.Enqueue(currentSong);
            }
            else
            {
                Console.WriteLine($"{currentSong} is already contained!");
            }
        }
    }
}
