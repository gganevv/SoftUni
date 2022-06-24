using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seq = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] len = new int[seq.Length];
            int[] prev = new int[seq.Length];

            int bestIndex = CalculateIncreasingSubsequence(seq, len, prev);

            int[] longuestSeq = RestoreLIS(seq, prev, bestIndex);
            Console.WriteLine(string.Join(" ", longuestSeq));
        }

        private static int CalculateIncreasingSubsequence(int[] seq, int[] len, int[] prev)
        {
            int maxLen = 0;
            int maxIndex = 0;

            for (int i = 0; i < seq.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (seq[j] < seq[i] && len[j] + 1 > len[i])
                    {
                        len[i] = 1 + len[i];
                        prev[i] = j;
                    }
                }
                if (len[i] > maxLen)
                {
                    maxLen = len[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private static int[] RestoreLIS(int[] seq, int[] prev, int bestIndex)
        {
            var longestSeq = new List<int>();
            while (bestIndex != -1)
            {
                longestSeq.Add(seq[bestIndex]);
                bestIndex = prev[bestIndex];
            }

            longestSeq.Reverse();

            return longestSeq.ToArray();
        }
    }
}
