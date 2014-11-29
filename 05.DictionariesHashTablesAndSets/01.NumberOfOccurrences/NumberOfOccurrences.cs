// 01.Write a program that counts in a given array of double values the
//    number of occurrences of each value. Use Dictionary<TKey,TValue>.
//      Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
//      -2.5  2 times
//      3  4 times
//      4  3 times

namespace _01.NumberOfOccurrences
{
    using System;
    using System.Collections.Generic;

    public class NumberOfOccurrences
    {
        public static void Main(string[] args)
        {   
            double[] nums = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            IDictionary<double, int> occurrences = new Dictionary<double, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (occurrences.ContainsKey(nums[i]))
                {
                    occurrences[nums[i]] += 1;
                }
                else
                {
                    occurrences[nums[i]] = 1;
                }
            }

            foreach (var pair in occurrences)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
