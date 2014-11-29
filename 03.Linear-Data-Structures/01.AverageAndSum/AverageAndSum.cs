//1.Write a program that reads from the console a sequence of positive integer numbers.
//  The sequence ends when empty line is entered. Calculate and print the sum and average of the
//  elements of the sequence. Keep the sequence in List<int>.

namespace _01.AverageAndSum
{
    using System;
    using System.Collections.Generic;
    using ReadFromConsole;

    public class AverageAndSum
    {
        static void Main(string[] args)
        {
            List<int> inputNubers = Read.Ints();
            int sum = 0;
            int currNumber;

            for (int i = 0; i < inputNubers.Count; i++)
            {
                currNumber = inputNubers[i];
                sum += currNumber;
            }

            int average = sum / inputNubers.Count;
            Console.WriteLine("Average: " + average);
            Console.WriteLine("Sum: " + sum);

            //// With integrated methods
            //Console.WriteLine("Average: " + inputNubers.Average());
            //Console.WriteLine("Sum: " + inputNubers.Sum());
        }
    }
}
