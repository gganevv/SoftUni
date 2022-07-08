using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shelf = Console.ReadLine().Split("&").ToList();

            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] commandArgs = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                string book = commandArgs[1];
                switch (command)
                {
                    case "Add Book":
                        AddBook(book, shelf);
                        break;
                    case "Take Book":
                        TakeBook(book, shelf);
                        break;
                    case "Swap Books":
                        string secondBook = commandArgs[2];
                        SwapBooks(book, secondBook, shelf);
                        break;
                    case "Insert Book":
                        InsertBook(book, shelf);
                        break;
                    case "Check Book":
                        CheckBook(book, shelf);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", shelf));
        }

        private static void AddBook(string book, List<string> shelf)
        {
            if (!shelf.Contains(book))
            {
                shelf.Insert(0, book);
            }
        }

        private static void TakeBook(string book, List<string> shelf)
        {
            if (shelf.Contains(book))
            {
                shelf.Remove(book);
            }
        }

        private static void SwapBooks(string book, string secondBook, List<string> shelf)
        {
            if (shelf.Contains(book) && shelf.Contains(secondBook))
            {
                int firstIndex = shelf.IndexOf(book);
                int secondIndex = shelf.IndexOf(secondBook);
                shelf[firstIndex] = secondBook;
                shelf[secondIndex] = book;
            }
        }

        private static void InsertBook(string book, List<string> shelf)
        {
            if (!shelf.Contains(book))
            {
                shelf.Add(book);
            }
        }

        private static void CheckBook(string book, List<string> shelf)
        {
            int index = int.Parse(book);
            if (index >= 0 && index < shelf.Count)
            {
                Console.WriteLine(shelf[index]);
            }
        }
    }
}
