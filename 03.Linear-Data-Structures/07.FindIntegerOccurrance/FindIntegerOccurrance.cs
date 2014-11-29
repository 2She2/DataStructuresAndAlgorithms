// 07.Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
//      Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
//      2  2 times
//      3  4 times
//      4  3 times

namespace _07.FindIntegerOccurrance
{
    using System;
    using System.Linq;

    class FindIntegerOccurrance
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var distinctNumbers = numbers.Distinct();

            foreach (var number in distinctNumbers)
            {
                Console.WriteLine(number + " -> " + numbers.Count(x => x == number));
            }

        }
    }
}
