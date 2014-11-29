// 09.We are given the following sequence:
//      S1 = N;
//      S2 = S1 + 1;
//      S3 = 2*S1 + 1;
//      S4 = S1 + 2;
//      S5 = S2 + 1;
//      S6 = 2*S2 + 1;
//      S7 = S2 + 2;
//      ...
//   Using the Queue<T> class write a program to print its first 50 members for given N.
//   Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

namespace _09.GetFirst50MembersOfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GetFirst50MembersOfSequence
    {
        static void Main(string[] args)
        {
            Queue<int> sequence = new Queue<int>();
            int n = 2;
            sequence.Enqueue(n);

            int length = 50 / 3;
            for (int i = 0; i < length; i++)
            {
                sequence.Enqueue(n + 1);
                sequence.Enqueue(2 * n + 1);
                sequence.Enqueue(n + 2);

                Console.Write(sequence.Dequeue() + ", ");
                n = sequence.Peek();
            }

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
