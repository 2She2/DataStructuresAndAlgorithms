// 05.Implement the data structure "set" in a class HashedSet<T> using
//    your class HashTable<K,T> to hold the elements. Implement all standard set operations like
//    Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.

namespace _05.HashedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using _04.HashTable;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, T> data;

        public int Count
        {
            get { return this.data.Count; }
            private set { }
        }

        public HashedSet(params T[] values)
        {
            this.data = new HashTable<T, T>();

            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    this.data.Add(values[i], values[i]);
                }
            }
        }

        public void Add(T value)
        {
            this.data.Add(value, value);
        }

        public void Remove(T value)
        {
            this.data.Remove(value);
        }

        public T Find(T value)
        {
            T lookedValue = data.Find(value);

            return lookedValue;
        }

        public void Clear()
        {
            this.data = new HashTable<T, T>();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.data)
            {
                if (!item.Equals(null))
                {
                    yield return item.Value;
                }
            }
        }

        public void Union(HashedSet<T> otherSet)
        {
            foreach (var item in otherSet)
            {
                if (!this.data.Contains(new KeyValuePair<T, T>(item, item)))
                {
                    this.data.Add(item, item);
                }
            }
        }

        public void IntersectWith(HashedSet<T> otherSet)
        {
            HashTable<T, T> otherTable = new HashTable<T, T>();
            foreach (var item in otherSet)
            {
                if (this.data.Contains(new KeyValuePair<T, T>(item, item)))
                {
                    otherTable.Add(item, item);
                }
            }

            this.data = otherTable;
        }
    }
}
