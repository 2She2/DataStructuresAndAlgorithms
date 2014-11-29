//2.Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.

namespace _02.ReversNumbersUsingStack
{
    using System;
    using System.Collections.Generic;

    class ReversNumbersUsingStack
    {
        static void Main(string[] args)
        {
            Console.Write("Numbers count: ");
            string currLine = Console.ReadLine();
            int length = int.Parse(currLine);

            Stack<int> inputNumbers = new Stack<int>(length);

            int currNumber;
            for (int i = 0; i < length; i++)
            {
                currLine = Console.ReadLine();
                currNumber = int.Parse(currLine);
                inputNumbers.Push(currNumber);
            }

            Console.WriteLine("Reversed numbers: " + string.Join(", ", inputNumbers));
        }
    }
}
