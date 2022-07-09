using System;
using System.Collections.Generic;

namespace _03.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] inputArgs = Console.ReadLine().Split('_');
                string songTypeList = inputArgs[0];
                string songName = inputArgs[1];
                string songTime = inputArgs[2];

                Song currentSong = new Song(songTypeList, songName, songTime);

                songs.Add(currentSong);
            }

            string input = Console.ReadLine();
            if (input == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songs)
                {
                    if (song.TypeList == input)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
