using System;

namespace _04.MoreseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" | ");
            string decryptedMessage = string.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                string[] letter = words[i].Split();
                for (int j = 0; j < letter.Length; j++)
                {
                    string currentLetter = letter[j];

                    switch (currentLetter)
                    {
                        case ".-":
                            decryptedMessage += "A";
                            break;
                        case "-...":
                            decryptedMessage += "B";
                            break;
                        case "-.-.":
                            decryptedMessage += "C";
                            break;
                        case "-..":
                            decryptedMessage += "D";
                            break;
                        case ".":
                            decryptedMessage += "E";
                            break;
                        case "..-.":
                            decryptedMessage += "F";
                            break;
                        case "--.":
                            decryptedMessage += "G";
                            break;
                        case "....":
                            decryptedMessage += "H";
                            break;
                        case "..":
                            decryptedMessage += "I";
                            break;
                        case ".---":
                            decryptedMessage += "J";
                            break;
                        case "-.-":
                            decryptedMessage += "K";
                            break;
                        case ".-..":
                            decryptedMessage += "L";
                            break;
                        case "--":
                            decryptedMessage += "M";
                            break;
                        case "-.":
                            decryptedMessage += "N";
                            break;
                        case "---":
                            decryptedMessage += "O";
                            break;
                        case ".--.":
                            decryptedMessage += "P";
                            break;
                        case "--.-":
                            decryptedMessage += "Q";
                            break;
                        case ".-.":
                            decryptedMessage += "R";
                            break;
                        case "...":
                            decryptedMessage += "S";
                            break;
                        case "-":
                            decryptedMessage += "T";
                            break;
                        case "..-":
                            decryptedMessage += "U";
                            break;
                        case "...-":
                            decryptedMessage += "V";
                            break;
                        case ".--":
                            decryptedMessage += "W";
                            break;
                        case "-..-":
                            decryptedMessage += "X";
                            break;
                        case "-.--":
                            decryptedMessage += "Y";
                            break;
                        case "--..":
                            decryptedMessage += "Z";
                            break;
                        case "|":
                            decryptedMessage += " ";
                            break;
                    }
                }
                decryptedMessage += " ";
            }

            Console.WriteLine(decryptedMessage);
        }
    }
}
