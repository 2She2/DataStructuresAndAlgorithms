// 04.Implement the data structure "hash table" in a class HashTable<K,T>.
//    Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with
//    initial capacity of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity.
//    Implement the following methods and properties: 
//      Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys.
//    Try to make the hash table to support iterating over its elements with foreach.

namespace _04.HashTable
{
    using System;

    class TestingHashTable
    {
        static void Main(string[] args)
        {
            HashTable<int, int> hassTable = new HashTable<int, int>();

            for (int i = 0; i < 20; i++)
            {
                hassTable.Add(i, 1 + i);
            }

            Console.WriteLine(hassTable.Find(6));

            hassTable[6] = 333;

            Console.WriteLine(hassTable[6]);

            var keys = hassTable.Keys;
            Console.WriteLine(string.Join(", ", keys));

            foreach (var item in hassTable)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }

            hassTable.Add(30, 1);
            hassTable.Add(300, 1);
            hassTable.Add(3000, 1);
            hassTable.Add(30000, 1);

            hassTable.Add(40, 1);
            hassTable.Add(400, 1);
            hassTable.Add(4000, 1);
            hassTable.Add(40000, 1);

            Console.WriteLine(hassTable.Count);
            Console.WriteLine(hassTable.Capacity);
        }
    }
}
