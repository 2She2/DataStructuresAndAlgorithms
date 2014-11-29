namespace PriorityQueueWithBinaryHeap
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a queue of objects that can be accessed by index, sorted, manipulated, searched and
    /// extracted in a prioritized order.
    /// </summary>
    /// <typeparam name="T">The type of elements in the heap.</typeparam>
    public class PriorityQueue<T> : BinaryHeap<T>
    {
        /// <summary>
        /// Initializes a new instance of the PriorityQueue<T> that contains elements copied from the specified 
        /// collection and has sufficient capacity to accomodate the number of elements copied. The queue is built
        /// using the default System.Collections.Generic.Comparer<T>.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new PriorityQueue<T></param>
        public PriorityQueue(IEnumerable<T> collection)
            : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityQueue<T> that contains elements copied from the specified 
        /// collection and has sufficient capacity to accomodate the number of elements copied. The queue is built
        /// using the specified System.Comparison<T>.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new PriorityQueue<T>.</param>
        /// <param name="comparison">The System.Comparison<T> to use when comparing elements.</param>
        public PriorityQueue(IEnumerable<T> collection, Comparison<T> comparison)
            : base(collection, comparison)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityQueue<T> that contains elements copied from the specified 
        /// collection and has sufficient capacity to accomodate the number of elements copied. The queue is built
        /// using the specified System.Collections.Generic.IComparer<T>.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new PriorityQueue<T>.</param>
        /// <param name="comparer">The System.Collections.Generic.IComparer<T> to use when comparing elements.</param>
        public PriorityQueue(IEnumerable<T> collection, IComparer<T> comparer)
            : base(collection, comparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityQueue<T> that is empty with the specified initial capacity.
        /// The queue is built using the default System.Collections.Generic.Comparer<T>.
        /// </summary>
        /// <param name="capacity">The number of elements that the new queue can initially store.</param>
        public PriorityQueue(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityQueue<T> that is empty with the specified initial capacity. 
        /// The queue is built using the specified System.Comparison<T>.
        /// </summary>
        /// <param name="capacity">The number of elements that the new queue can initially store.</param>
        /// <param name="comparison">The System.Comparison<T> to use when comparing elements.</param>
        public PriorityQueue(int capacity, Comparison<T> comparison)
            : base(capacity, comparison)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityQueue<T> that is empty with the specified initial capacity. 
        /// The queue is built using the specified System.Collections.Generic.IComparer<T>.
        /// </summary>
        /// <param name="capacity">The number of elements that the new queue can initially store.</param>
        /// <param name="comparer">The System.Collections.Generic.IComparer<T> to use when comparing elements.</param>
        public PriorityQueue(int capacity, IComparer<T> comparer)
            : base(capacity, comparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityQueue<T> that is empty and has the default initial capacity.
        /// The queue is built using the default System.Collections.Generic.Comparer<T>.
        /// </summary>
        public PriorityQueue()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityQueue<T> that is empty and has the default initial capacity.
        /// The queue is built using the specified System.Comparison<T>.
        /// </summary>
        /// <param name="comparison">The System.Comparison<T> to use when comparing elements.</param>
        public PriorityQueue(Comparison<T> comparison)
            : base(comparison)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityQueue<T> that is empty and has the default initial capacity.
        /// The queue is built using the specified System.Collections.Generic.IComparer<T>.
        /// </summary>
        /// <param name="comparer">The System.Collections.Generic.IComparer<T> to use when comparing elements.</param>
        public PriorityQueue(IComparer<T> comparer)
            : base(comparer)
        {
        }

        /// <summary>
        /// Adds and element to the bottom of the queue and then cascades the element upwards.
        /// </summary>
        /// <seealso cref="BinaryHeap<T>.Insert"/>
        /// <param name="element">The object to add to the PriorityQueue<T>.</param>
        public void Enqueue(T element)
        {
            this.Insert(element);
        }

        /// <summary>
        /// Removes and returns the first element in the PriorityQueue&lt;T&gt;.
        /// </summary>
        /// <seealso cref="BinaryHeap<T>.Extract"/>
        /// <exception cref="System.InvalidOperationException">Thrown if the heap is empty.</exception>
        /// <returns>The first element in the PriorityQueue<T>.</returns>
        public T Dequeue()
        {
            return this.Extract();
        }
    }
}
