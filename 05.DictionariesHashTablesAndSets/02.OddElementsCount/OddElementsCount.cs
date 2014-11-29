// 02.Write a program that extracts from a given sequence of strings all elements that
//    present in it odd number of times. Example:
//      {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}

namespace _02.OddElementsCount
{
    using System;
    using System.Collections.Generic;

    public class OddElementsCount
    {
        public static void Main(string[] args)
        {
            string[] sequence = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            IDictionary<string, int> occurrences = new Dictionary<string, int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (occurrences.ContainsKey(sequence[i]))
                {
                    occurrences[sequence[i]] += 1;
                }
                else
                {
                    occurrences[sequence[i]] = 1;
                }
            }

            foreach (var pair in occurrences)
            {
                if (pair.Value % 2 == 1)
                {
                    Console.WriteLine(pair.Key + " -> " + pair.Value);
                }
            }
        }
    }
}
