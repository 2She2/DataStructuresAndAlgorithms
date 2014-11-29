// 4.Write a method that finds the longest subsequence of equal numbers in given List<int> and
//   returns the result as new List<int>. Write a program to test whether the method works correctly.

namespace _04.LongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestSubsequenceOfEqualNumbers
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = new List<int>() { 4, 6, 6, 1, 1, 1, 1, 5, 5, 5, 5, 5, 0, 0, 1 };
            List<int> maxSubsequence = GetLongestSubsequence(inputNumbers);

            Console.WriteLine("Longest subsequence: " + string.Join(", ", maxSubsequence));
        }

        static List<int> GetLongestSubsequence(List<int> numbers)
        {
            int maxSubsequenceLength = 0;
            int currSubsequenceLength = 1;
            int maxSubsequenceIndex = 0;
            int currNumber;
            int previousNumber;

            for (int i = 1; i < numbers.Count; i++)
            {
                currNumber = numbers[i];
                previousNumber = numbers[i - 1];

                if (currNumber == previousNumber)
                {
                    currSubsequenceLength++;
                    if (currSubsequenceLength > maxSubsequenceLength)
                    {
                        maxSubsequenceLength = currSubsequenceLength;
                        maxSubsequenceIndex = i + 1 - maxSubsequenceLength;
                    }
                }
                else
                {
                    currSubsequenceLength = 1;
                }
            }

            List<int> subsequence = numbers.GetRange(maxSubsequenceIndex, maxSubsequenceLength);

            return subsequence;
        }
    }
}
