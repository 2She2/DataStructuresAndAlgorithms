//11.Implement the data structure linked list. Define a class ListItem<T> that has two fields:
//   value (of type T) and NextItem (of type ListItem<T>). Define additionally a class LinkedList<T>
//   with a single field FirstElement (of type ListItem<T>).

namespace _11.LinkedListImplementation
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList2<int> myLL = new LinkedList2<int>();
            myLL.AddLast(5);
            myLL.AddLast(10);
            myLL.AddLast(15);
            myLL.AddLast(20);
            myLL.AddLast(25);

            //Console.WriteLine(myLL.Count);

            //Console.WriteLine(myLL.RemoveFirst().Value);
            //Console.WriteLine(myLL.FirstElement.Value);
            //Console.WriteLine(myLL.FirstElement.Previous);
            //Console.WriteLine(myLL.Count);

            //Console.WriteLine(myLL.RemoveLast().Value);
            //Console.WriteLine(myLL.LastElement.Value);
            //Console.WriteLine(myLL.LastElement.Next);
            //Console.WriteLine(myLL.Count);

            //Console.WriteLine(string.Join(", ", myLL));
        }
    }
}
