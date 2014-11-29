// 13.Implement the ADT queue as dynamic linked list.
//    Use generics (LinkedQueue<T>) to allow storing different data types in the queue.

namespace _13.QueueImplementation
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            LinkedQueue<int> lq = new LinkedQueue<int>();
            lq.Enqueue(1);
            lq.Enqueue(2);
            lq.Enqueue(3);

            Console.WriteLine(string.Join(", ", lq));
            lq.Dequeue();
            Console.WriteLine(string.Join(", ", lq));
            lq.Dequeue();
            Console.WriteLine(string.Join(", ", lq));
        }
    }
}
