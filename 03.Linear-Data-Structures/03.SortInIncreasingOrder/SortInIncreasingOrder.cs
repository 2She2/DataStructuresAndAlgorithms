//3.Write a program that reads a sequence of integers (List<int>) ending with an empty line and
//  sorts them in an increasing order.

namespace _03.SortInIncreasingOrder
{
    using System;
    using System.Collections.Generic;
    using ReadFromConsole;

    class SortInIncreasingOrder
    {
        static void Main(string[] args)
        {
            List<int> inputNumber = Read.IntsWithCount();

            inputNumber.Sort();

            Console.WriteLine(string.Join(", ", inputNumber));
        }
    }
}
