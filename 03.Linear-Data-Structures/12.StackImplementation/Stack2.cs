namespace _12.StackImplementation
{
    using System;

    public class Stack2<T>
    {
        private const int InitialCapacity = 4;
        private int count = -1;

        private T[] elements = new T[InitialCapacity];

        public int Count 
        {
            get
            {
                return this.count + 1;
            }
        }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public void Push(T value)
        {
            if (this.elements.Length == this.Count)
            {
                Array.Resize(ref this.elements, this.Count * 2);
            }

            this.elements[this.Count] = value;

            this.count++;
        }

        public T Pop()
        {
            if (this.count == -1)
            {
                throw new InvalidOperationException("The stack is empty! Can't pop!");
            }

            this.count--;
            T value = this.elements[this.Count];
            this.elements[this.Count] = default(T);

            return value;
        }

        public T Peek()
        {
            if (this.count == -1)
            {
                throw new InvalidOperationException("The stack is empty! Can't peek!");
            }

            return this.elements[this.count];
        }

        public void Clear()
        {
            this.count = -1;
            this.elements = new T[InitialCapacity];
        }

        public void TrimExcess()
        {
            Array.Resize(ref this.elements, this.Count);
        }
    }
}
