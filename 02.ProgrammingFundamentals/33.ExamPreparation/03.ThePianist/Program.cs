
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i < n; i++)
            {
                string[] currentLane = Console.ReadLine().Split("|");
                string name = currentLane[0];
                string composer = currentLane[1];
                string key = currentLane[2];
                Piece piece = new Piece(name, composer, key);
                pieces.Add(piece);
            }

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] inputArgs = input.Split("|");
                switch (inputArgs[0])
                {
                    case "Add":
                        AddPiece(inputArgs[1], inputArgs[2], inputArgs[3], pieces);
                        break;
                    case "Remove":
                        RemovePiece(inputArgs[1], pieces);
                        break;
                    case "ChangeKey":
                        ChangeKey(inputArgs[1], inputArgs[2], pieces);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            pieces.ForEach(Console.WriteLine);
        }

        private static void AddPiece(string name, string composer, string key, List<Piece> pieces)
        {
            if (!pieces.Any(x => x.Name == name))
            {
                pieces.Add(new Piece(name, composer, key));
                Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
            }
            else
            {
                Console.WriteLine($"{name} is already in the collection!");
            }
        }

        private static void RemovePiece(string name, List<Piece> pieces)
        {
            if (pieces.Any(x => x.Name == name))
            {
                var pieceToRemove = pieces.First(x => x.Name == name);
                pieces.Remove(pieceToRemove);
                Console.WriteLine($"Successfully removed {name}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
            }
        }

        private static void ChangeKey(string name, string newKey, List<Piece> pieces)
        {
            if (pieces.Any(x => x.Name == name))
            {
                var currentPiece = pieces.First(x => x.Name == name);
                currentPiece.Key = newKey;
                Console.WriteLine($"Changed the key of {name} to {newKey}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
            }
        }
    }

    public class Piece
    {
        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Composer: {Composer}, Key: {Key}";
        }
    }
}
