namespace _13.QueueImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> values = new LinkedList<T>();

        public int Count
        {
            get
            {
                return this.values.Count;
            }
        }

        public void Enqueue(T value)
        {
            this.values.AddLast(value);
        }

        public T Dequeue()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            T value = this.values.First.Value;
            this.values.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            return this.values.First.Value;
        }

        public void Clear()
        {
            this.values.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
