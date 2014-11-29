// 12.Implement the ADT stack as auto-resizable array.
//    Resize the capacity on demand (when no space is available to add / insert a new element).

namespace _12.StackImplementation
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Stack2<int> mySt = new Stack2<int>();

            mySt.Push(10);
            mySt.Push(2);
            mySt.Push(33);
            mySt.Push(12);
            mySt.Push(99);

            Console.WriteLine(mySt.Pop());
            Console.WriteLine(mySt.Pop());
            Console.WriteLine(mySt.Pop());
            Console.WriteLine(mySt.Pop());
            Console.WriteLine(mySt.Pop());
            //Console.WriteLine(mySt.Peek());
            Console.WriteLine("Capacity: " + mySt.Capacity);
        }
    }
}
