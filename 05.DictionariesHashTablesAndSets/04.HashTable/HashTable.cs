// 04.Implement the data structure "hash table" in a class HashTable<K,T>.
//    Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with
//    initial capacity of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity.
//    Implement the following methods and properties: 
//      Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys.
//    Try to make the hash table to support iterating over its elements with foreach.

namespace _04.HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private LinkedList<KeyValuePair<K, T>>[] data;
        private List<K> dataPositions;
        private int count = 0;

        public HashTable()
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[16];
            this.dataPositions = new List<K>();
        }

        public int Count
        {
            get { return this.count; }

            private set { this.count = value; }
        }

        public int Capacity
        {
            get { return this.data.Length; }
        }

        public IList<K> Keys
        {
            get
            {
                IList<K> keys = new List<K>();

                for (int i = 0; i < this.Count; i++)
                {
                    var pairs = this.data[i];

                    foreach (var pair in pairs)
                    {
                        keys.Add(pair.Key);
                    }
                }

                return keys;
            }
        }

        public T this[K key]
        {
            get
            {
                T elementValue = this.Find(key);

                return elementValue;
            }

            set
            {
                this.CheckAndResize();

                int index = this.MyHashCode(key, this.data.Length);

                if (this.data[index] == null)
                {
                    this.data[index] = new LinkedList<KeyValuePair<K, T>>();
                    this.dataPositions.Add(key);
                }

                bool doesKeyExist = this.data[index].Any(x => x.Key.Equals(key));
                if (doesKeyExist)
                {
                    var item = this.GetElement(key);
                    this.data[index].Remove(item);

                    this.Count--;
                }

                var toAdd = new KeyValuePair<K, T>(key, value);
                this.data[index].AddLast(new KeyValuePair<K, T>(key, value));

                this.Count++;
            }
        }

        public void Add(K key, T value)
        {
            this.CheckAndResize();

            int length = this.data.Length;
            int index = this.MyHashCode(key, this.data.Length);

            if (this.data[index] == null)
            {
                this.data[index] = new LinkedList<KeyValuePair<K, T>>();
                this.dataPositions.Add(key);
            }

            bool doesKeyExist = this.data[index].Any(x => x.Key.Equals(key));
            if (doesKeyExist)
            {
                throw new ArgumentException("Key: " + key + " exist!");
            }

            this.data[index].AddLast(new KeyValuePair<K, T>(key, value));

            this.Count++;
        }

        public T Find(K key)
        {
            int index = this.MyHashCode(key, this.data.Length);

            if (this.data[index] == null)
            {
                throw new ArgumentException("Key: " + key + " do NOT exist!");
            }

            var searchedItem = this.GetElement(key);

            return searchedItem.Value;
        }

        public void Remove(K key)
        {
            var index = this.MyHashCode(key, this.data.Length);
            var itemToRemove = this.GetElement(key);

            this.data[index].Remove(itemToRemove);

            if (this.data[index] == null)
            {
                this.dataPositions.Remove(key);
            }

            this.Count--;
        }

        public void Clear()
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[16];
            this.dataPositions = new List<K>();
            this.Count = 0;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i] != null)
                {
                    var next = this.data[i].First;
                    while (next != null)
                    {
                        yield return next.Value;
                        next = next.Next;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void CheckAndResize()
        {
            int length = this.data.Length * 2;

            if (this.Count >= this.data.Length * 0.75)
            {
                var resizedData = new LinkedList<KeyValuePair<K, T>>[length];

                int oldDataLength = this.data.Length;
                int newDataLength = resizedData.Length;

                foreach (var key in this.dataPositions)
                {
                    int oldIndex = this.MyHashCode(key, oldDataLength);
                    int newIndex = this.MyHashCode(key, newDataLength);

                    resizedData[newIndex] = this.data[oldIndex];
                }

                this.data = resizedData;
            }
        }

        private int MyHashCode(K key, int length)
        {
            return Math.Abs(key.GetHashCode() % length);
        }

        private KeyValuePair<K, T> GetElement(K key)
        {
            int index = this.MyHashCode(key, this.data.Length);

            if (this.data[index] == null)
            {
                throw new ArgumentException("Key: " + key + " do NOT exist!");
            }

            var searchedItem = this.data[index].First(x => x.Key.Equals(key));

            return searchedItem;
        }
    }
}
