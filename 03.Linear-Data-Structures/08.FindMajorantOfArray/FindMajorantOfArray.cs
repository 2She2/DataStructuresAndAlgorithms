// 8.* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
//     Write a program to find the majorant of given array (if exists). Example:
//      {2, 2, 3, 3, 2, 3, 4, 3, 3}  3

namespace _08.FindMajorantOfArray
{
    using System;
    using System.Linq;

    class FindMajorantOfArray
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            Console.WriteLine(string.Join(", ", numbers));

            var distinctNumbers = numbers.Distinct();
            int currNumberOccurrance;

            foreach (var number in distinctNumbers)
            {
                currNumberOccurrance = numbers.Count(x => x == number);

                if (currNumberOccurrance > numbers.Length / 2)
                {
                    Console.WriteLine("majorant: " + number);
                }
            }
        }
    }
}
