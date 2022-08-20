using System;

namespace _05.RandomSentencesGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Peter", "Michell", "Jane", "Steve", "Ivan" };
            string[] places = { "Sofia", "London", "New York", "Germany", "Varna" };
            string[] verbs = { "eats", "holds", "sees", "plays with", "brings" };
            string[] nouns = { "stones", "cakes", "apples", "laptops", "bikes" };
            string[] adverbs = { "slowly", "diligently", "warmly", "sadly", "rapidly" };
            string[] details = { "near the river", "at home", "in the park", "in the bathroom", "at school"};
            string sentence = string.Empty;

            Random random = new Random();
            int whoTypeSelector = random.Next(1, 3);
            int actionTypeSelector = random.Next(1, 3);
            if (whoTypeSelector == 1)
            {
                sentence += names[random.Next(0, 5)] + " ";
            }
            else
            {
                sentence += $"{names[random.Next(0, 5)]} from {places[random.Next(0, 5)]} ";
            }
            if (actionTypeSelector == 1)
            {
                sentence += $"{verbs[random.Next(0, 5)]} {nouns[random.Next(0, 5)]} ";
            }
            else
            {
                sentence += $"{adverbs[random.Next(0, 5)]} {verbs[random.Next(0, 5)]} {nouns[random.Next(0, 5)]} ";
            }
            sentence += details[random.Next(0, 5)];

            Console.WriteLine(sentence);
        }
    }
}
