// 05.Implement the data structure "set" in a class HashedSet<T> using
//    your class HashTable<K,T> to hold the elements. Implement all standard set operations like
//    Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.
namespace _05.HashedSet
{
    using System;

    public class TestingHashedSet
    {
        public static void Main(string[] args)
        {
            HashedSet<int> setFirst = new HashedSet<int>(new int[] { 111, 1, 3, 5, 7, 12 });
            Console.WriteLine(setFirst.Count);

            setFirst.Add(122);
            Console.WriteLine(setFirst.Find(122));
            Console.WriteLine(setFirst.Count);

            setFirst.Remove(122);
            Console.WriteLine(setFirst.Count);

            foreach (var item in setFirst)
            {
                Console.WriteLine(item);
            }

            HashedSet<int> setSecond = new HashedSet<int>(new int[] { 1, 3, 5, 7, 12, 2222 });

            setSecond.Union(setFirst);
            Console.WriteLine(string.Join(", ", setSecond));
        }
    }
}
