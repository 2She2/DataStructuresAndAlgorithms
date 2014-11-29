namespace PriorityQueueWithBinaryHeap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The enumerator used for enumerating the elements in an instance of the BinaryHeap class
    /// </summary>
    /// <typeparam name="T">The type of the elements in the binary heap</typeparam>
    public class BinaryHeapEnumerator<T> : IEnumerator<T>
    {
        private T[] elements;
        private int heapSize;

        private int position = -1;

        /// <summary>
        /// Creates a new instance of the enumerator based on a given input
        /// </summary>
        /// <param name="data">An array of the data to enumerate</param>
        /// <param name="heapSize">The size of the heap to enumerate over, i.e. it will only be allowed to enumerate over the elements in the heap</param>
        public BinaryHeapEnumerator(T[] data, int heapSize)
        {
            this.elements = data;
            this.heapSize = heapSize;
        }

        /// <summary>
        /// Gets the currently referenced element in the heap enumerated by this BinaryHeapEnumerator<T> object.
        /// </summary>
        public T Current
        {
            get { return this.elements[this.position]; }
        }

        /// <summary>
        /// Gets the currently referenced element in the heap enumerated by this BinaryHeapEnumerator<T> object.
        /// </summary>
        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        void IDisposable.Dispose()
        {
        }

        /// <summary>
        /// Increments the internal index of the current BinaryHeapEnumerator<T> object 
        /// to the next element of the enumerated heap.
        /// </summary>
        /// <returns>true if the index is successfully incremented and within the enumerated heap; otherwise, false.</returns>
        public bool MoveNext()
        {
            this.position++;
            return this.position < this.heapSize;
        }

        /// <summary>
        /// Initializes the index to a position logically before the first element of the enumerated heap.
        /// </summary>
        public void Reset()
        {
            this.position = -1;
        }
    }
}
