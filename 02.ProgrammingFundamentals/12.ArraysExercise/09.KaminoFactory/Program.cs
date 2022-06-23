using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequencesLength = int.Parse(Console.ReadLine());
            
            int[] bestDNA = new int[sequencesLength];
            int bestSequence = 0;
            int bestStartingIndex = 0;
            int bestSequenceSum = 0;
            int bestLength = 0;
            int counter = 0;

            string sequence = Console.ReadLine();
            while (sequence != "Clone them!")
            {
                counter++;
                int currentLength = 0;
                int currentBestLength = 0;
                int currentSum = 0;
                int currentStartingIndex = -1;
                int[] DNA = sequence.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                ReadDNAs(ref currentLength, ref currentBestLength, ref currentSum, ref currentStartingIndex, DNA);
                CheckBestDNA(ref bestDNA, ref bestSequence, ref bestStartingIndex, ref bestSequenceSum, ref bestLength, counter, currentBestLength, currentSum, currentStartingIndex, DNA);

                sequence = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequence} with sum: {bestSequenceSum}.");
            Console.WriteLine(String.Join(" ", bestDNA));
        }

        private static void ReadDNAs(ref int currentLength, ref int currentBestLength, ref int currentSum, ref int currentStartingIndex, int[] DNA)
        {
            for (int i = 0; i < DNA.Length; i++)
            {

                if (DNA[i] == 1)
                {
                    currentSum++;
                    currentLength++;
                    if (currentLength > currentBestLength)
                    {
                        currentStartingIndex = i - currentBestLength;
                        currentBestLength = currentLength;
                    }
                }
                else
                {
                    currentLength = 0;
                }
            }
        }

        private static void CheckBestDNA(ref int[] bestDNA, ref int bestSequence, ref int bestStartingIndex, ref int bestSequenceSum, ref int bestLength, int counter, int currentBestLength, int currentSum, int currentStartingIndex, int[] DNA)
        {
            if (currentBestLength > bestLength)
            {
                SetBestDNA(out bestDNA, out bestSequence, out bestStartingIndex, out bestSequenceSum, out bestLength, counter, currentBestLength, currentSum, currentStartingIndex, DNA);
            }
            else if (currentBestLength == bestLength)
            {
                if (currentStartingIndex < bestStartingIndex)
                {
                    SetBestDNA(out bestDNA, out bestSequence, out bestStartingIndex, out bestSequenceSum, out bestLength, counter, currentBestLength, currentSum, currentStartingIndex, DNA);
                }
                else if (currentStartingIndex == bestStartingIndex)
                {
                    if (currentSum > bestSequenceSum)
                    {
                        SetBestDNA(out bestDNA, out bestSequence, out bestStartingIndex, out bestSequenceSum, out bestLength, counter, currentBestLength, currentSum, currentStartingIndex, DNA);
                    }
                }
            }
        }

        private static void SetBestDNA(out int[] bestDNA, out int bestSequence, out int bestStartingIndex, out int bestSequenceSum, out int bestLength, int counter, int currentBestLength, int currentSum, int currentStartingIndex, int[] DNA)
        {
            bestDNA = DNA;
            bestStartingIndex = currentStartingIndex;
            bestSequenceSum = currentSum;
            bestLength = currentBestLength;
            bestSequence = counter;
        }
    }
}
