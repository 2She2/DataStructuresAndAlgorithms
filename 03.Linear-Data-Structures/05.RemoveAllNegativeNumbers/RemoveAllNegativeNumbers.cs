// 05.Write a program that removes from given sequence all negative numbers.

namespace _05.RemoveAllNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveAllNegativeNumbers
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int> { 3, -1, 6, -3, 5, 9, -3 };
            List<int> positiveSequence = RemoveNegativeNumbers(sequence);

            Console.WriteLine(string.Join(", ", positiveSequence));
        }

        public static List<int> RemoveNegativeNumbers(List<int> sequence)
        {
            List<int> positiveNumbers = new List<int>(sequence);

            positiveNumbers.RemoveAll(x => x < 0);

            return positiveNumbers;
        }
    }
}
