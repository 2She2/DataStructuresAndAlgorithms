// 6.Write a program that removes from given sequence all numbers that occur odd number of times. 

namespace _06.RemoveOddNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveOddNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> evenCount = RemoveOddCount(numbers);

            Console.WriteLine(string.Join(", ", evenCount));
        }

        static List<int> RemoveOddCount(List<int> numbers)
        {
            List<int> evenCount = new List<int>(numbers);

            int numberCount;
            int currNumber;

            for (int i = 0; i < evenCount.Count; i++)
            {
                currNumber = evenCount[i];
                numberCount = evenCount.Count(x => x == currNumber);

                if (numberCount % 2 != 0)
                {
                    evenCount.RemoveAll(x => x == currNumber);

                    i--;
                }
            }

            return evenCount;
        }
    }
}
