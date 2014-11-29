/// <summary>
/// The original source can be found at:
/// or-bloggers.com
/// </summary>

namespace PriorityQueueWithBinaryHeap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a binary heap of objects that can be accessed by index, sorted, manipulated, searched and
    /// extracted in a given order.
    /// </summary>
    /// <typeparam name="T">The type of elements in the heap.</typeparam>
    public class BinaryHeap<T> : IEnumerable<T>
    {
        /// <summary>
        /// The minimum size of the heap.
        /// </summary>
        private const int START_HEAP_SIZE = 4;

        /// <summary>
        /// The array of elements in the internal data structure.
        /// </summary>
        private T[] elements;

        /// <summary>
        /// The System.Collections.Generic.Comparer<T> to use in the binary heap.
        /// </summary>
        private IComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the BinaryHeap<T> that contains elements copied from the specified 
        /// collection and has sufficient capacity to accomodate the number of elements copied. The heap is built
        /// using the default System.Collections.Generic.Comparer<T>.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new BinaryHeap<T></param>
        public BinaryHeap(IEnumerable<T> collection)
            : this(collection, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BinaryHeap<T> that contains elements copied from the specified 
        /// collection and has sufficient capacity to accomodate the number of elements copied. The heap is built
        /// using the specified System.Comparison<T>.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new BinaryHeap<T>.</param>
        /// <param name="comparison">The System.Comparison<T> to use when comparing elements.</param>
        public BinaryHeap(IEnumerable<T> collection, Comparison<T> comparison)
            : this(collection, new ComparisonComparer(comparison))
        {
        }

        /// <summary>
        /// Initializes a new instance of the BinaryHeap<T> that contains elements copied from the specified 
        /// collection and has sufficient capacity to accomodate the number of elements copied. The heap is built
        /// using the specified System.Collections.Generic.IComparer<T>.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new BinaryHeap<T>.</param>
        /// <param name="comparer">The System.Collections.Generic.IComparer<T> to use when comparing elements.</param>
        public BinaryHeap(IEnumerable<T> collection, IComparer<T> comparer)
        {
            this.comparer = comparer;

            this.Count = collection.Count();
            this.elements = new T[Count];

            int i = 0;
            foreach (var element in collection)
            {
                this.elements[i] = element;
                i++;
            }

            this.BuildHeap();
        }

        /// <summary>
        /// Initializes a new instance of the BinaryHeap<T> that is empty with the specified initial capacity.
        /// The heap is built using the default System.Collections.Generic.Comparer<T>.
        /// </summary>
        /// <param name="capacity">The number of elements that the new heap can initially store.</param>
        public BinaryHeap(int capacity)
            : this(capacity, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BinaryHeap<T> that is empty with the specified initial capacity. 
        /// The heap is built using the specified System.Comparison<T>.
        /// </summary>
        /// <param name="capacity">The number of elements that the new heap can initially store.</param>
        /// <param name="comparison">The System.Comparison<T> to use when comparing elements.</param>
        public BinaryHeap(int capacity, Comparison<T> comparison)
            : this(capacity, new ComparisonComparer(comparison))
        {
        }

        /// <summary>
        /// Initializes a new instance of the BinaryHeap<T> that is empty with the specified initial capacity. 
        /// The heap is built using the specified System.Collections.Generic.IComparer<T>.
        /// </summary>
        /// <param name="capacity">The number of elements that the new heap can initially store.</param>
        /// <param name="comparer">The System.Collections.Generic.IComparer<T> to use when comparing elements.</param>
        public BinaryHeap(int capacity, IComparer<T> comparer)
        {
            this.comparer = comparer;
            this.elements = new T[capacity];

            this.Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the BinaryHeap<T> that is empty and has the default initial capacity.
        /// The heap is built using the default System.Collections.Generic.Comparer<T>.
        /// </summary>
        public BinaryHeap()
            : this(Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BinaryHeap<T> that is empty and has the default initial capacity.
        /// The heap is built using the specified System.Comparison<T>.
        /// </summary>
        /// <param name="comparison">The System.Comparison<T> to use when comparing elements.</param>
        public BinaryHeap(Comparison<T> comparison)
            : this(new ComparisonComparer(comparison))
        {
        }

        /// <summary>
        /// Initializes a new instance of the BinaryHeap<T> that is empty and has the default initial capacity.
        /// The heap is built using the specified System.Collections.Generic.IComparer<T>.
        /// </summary>
        /// <param name="comparer">The System.Collections.Generic.IComparer<T> to use when comparing elements.</param>
        public BinaryHeap(IComparer<T> comparer)
        {
            this.comparer = comparer;
            this.elements = new T[START_HEAP_SIZE];

            this.Count = 0;
        }

        /// <summary>
        /// Gets the number of elements actually contained in the binary heap.
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if the capacity is tried to set to a 
        /// value which is smaller than the number of elements in the heap</exception>
        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }

            set
            {
                if (value < this.Count)
                {
                    throw new InvalidOperationException("The capacity of the heap cannot be set to a value smaller than the size");
                }

                if (this.elements.Length != value)
                {
                    T[] currentElements = this.elements;
                    this.elements = new T[value];

                    for (int i = 0; i < this.Count; i++)
                    {
                        this.elements[i] = currentElements[i];
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether the heap is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return this.Count == 0;
            }
        }

        /// <summary>
        /// Gets or sets the element in the heap at the specified index.
        /// </summary>
        /// <param name="index">The index of the element to get or set.</param>
        /// <returns>the element at the given index.</returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("The index specified was out of the range of the elements in the heap.");
                }

                return this.elements[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("The index specified was out of the range of the elements in the heap.");
                }

                this.elements[index] = value;
                //Since the element is changed it might be needed to cascade the element.
                this.Cascade(index);
            }
        }

        /// <summary>
        /// Changes the currently used System.Collections.Generic.IComparer<T> to the specified one. Note 
        /// that a call to this method runs in linear time since the heap needs to be updated when changing the 
        /// System.Collections.Generic.IComparer<T>.
        /// </summary>
        /// <param name="comparer">The System.Collections.Generic.IComparer<T> to use subsequently.</param>
        public void ChangeComparer(IComparer<T> comparer)
        {
            this.comparer = comparer;

            this.BuildHeap();
        }

        /// <summary>
        /// Changes the currently used System.Collections.Generic.IComparer<T> to a new one using the 
        /// specified System.Comparison<T> when comparing elements. Note that a call to this method runs in 
        /// linear time since the heap needs to be updated when changing the System.Collections.Generic.IComparer<T>.
        /// </summary>
        /// <param name="comparison">The System.Comparison<T> to use subsequently when comparing elements.</param>
        public void ChangeComparison(Comparison<T> comparison)
        {
            this.comparer = new ComparisonComparer(comparison);

            this.BuildHeap();
        }

        /// <summary>
        /// Checks for the element at the specified index of the heap whether the heap property holds. If not
        /// it is checked whether the element should be cascaded upwards or downwards in the heap.
        /// </summary>
        /// <param name="index">The index in the internal storage of the element to cascade.</param>
        public void Cascade(int index)
        {
            //We may need to cascade upwards
            int i = index;
            int p;
            bool cascadedUp = false;
            T dummy;

            while (i > 0)
            {
                p = (i - 1) >> 1; //An alternative to this expression could be p = (i - 1) / 2;
                if (this.comparer.Compare(this.elements[i], this.elements[p]) >= 0)
                {
                    break;
                }

                dummy = this.elements[p];
                this.elements[p] = this.elements[i];
                this.elements[i] = dummy;

                i = p;
                cascadedUp = true;
            }

            if (!cascadedUp)
            {
                //We may need to cascade downwards
                this.Heapify(index);
            }
        }

        /// <summary>
        /// Searches for the specified element in the heap and removes it if found. Returns true is the element was
        /// found and removed and false otherwise. The comparer or comparison given when initializing the heap will
        /// be used when comparing the element to elements in the internal storage.
        /// </summary>
        /// <param name="element">The element to remove.</param>
        /// <returns>true if the element was succesfully removed; otherwise, false.</returns>
        public bool Remove(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.comparer.Compare(element, this.elements[i]) == 0)
                {
                    this.RemoveAt(i);

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes an element from the internal storage at the specified index.
        /// </summary>
        /// <exception cref="System.IndexOutOfRangeException">Thrown if the specified index is out of bounds
        /// of the heap.</exception>
        /// <param name="index">The index of the element wanted to remove.</param>
        /// <returns>the element which was removed from the set of elements.</returns>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("The index specified for deletion is out of bounds");
            }

            T returnElement = this.elements[index];

            this.Count--;
            this.elements[index] = this.elements[this.Count];

            if (this.Count < (this.Capacity >> 2))
            {
                this.Capacity >>= 1;
            }

            //Cascade element
            this.Cascade(index);

            return returnElement;
        }

        /// <summary>
        /// Adds and element to the bottom of the heap and then cascades the element upwards.
        /// </summary>
        /// <param name="element">The object to add to the BinaryHeap<T>.</param>
        public void Insert(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity <<= 1; //This could just have been expressed as Capacity *= 2;
            }

            this.elements[this.Count] = element;
            this.Count++;
            this.Cascade(this.Count - 1);
        }

        /// <summary>
        /// Peeks at the first element in the heap.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if the heap is empty.</exception>
        /// <returns>the first element in the heap.</returns>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty when trying to peek");
            }

            return this.elements[0];
        }

        /// <summary>
        /// Removes and returns the first element in the BinaryHeap&lt;T&gt;.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if the heap is empty.</exception>
        /// <returns>the first element in the BinaryHeap<T>.</returns>
        public T Extract()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty when trying to extract");
            }

            T returnElement = this.elements[0];
            this.Count--;
            this.elements[0] = this.elements[this.Count];

            if (this.Count < this.Capacity / 4)
            {
                if (this.Capacity / 2 < START_HEAP_SIZE)
                {
                    this.Capacity = START_HEAP_SIZE;
                }
                else
                {
                    this.Capacity /= 2;
                }
            }

            //Cascade down
            this.Heapify(0);

            return returnElement;
        }

        /// <summary>
        /// Removes all elements from the BinaryHeap<T> and uses the default initial capacity.
        /// </summary>
        public void Clear()
        {
            this.elements = new T[START_HEAP_SIZE];
            this.Count = 0;
        }

        /// <summary>
        /// Copies the elements in the heap to an array.
        /// </summary>
        /// <returns>the elements in the heap as an array.</returns>
        public T[] ToArray()
        {
            T[] returnArray = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                returnArray[i] = this.elements[i];
            }

            return returnArray;
        }

        /// <summary>
        /// Checks whether the heap contains the specified element. The comparer or comparison specified when
        /// initializing the heap will be used to compare the elements.
        /// </summary>
        /// <param name="element">The object to search for.</param>
        /// <returns>true if the element is found in the heap; otherwise, false.</returns>
        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.comparer.Compare(this.elements[i], element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copies the binary heap to an array at the specified index.
        /// </summary>
        /// <param name="array">The array that is the destination of the copied elements.</param>
        /// <param name="arrayIndex">The zero-based index of the given array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.elements, 0, array, arrayIndex, this.Count);
        }

        /// <summary>
        /// Uses the heapsort algorithm to sort the elements in the heap. Mostly implemented for fun as the method
        /// Sort() is usually more efficient for large data sets.
        /// </summary>
        /// <seealso cref="BinaryHeap<T>.Sort()"/>
        public void HeapSort()
        {
            int realCount = this.Count;
            T dummy;

            for (int i = realCount - 1; i > 0; i--)
            {
                dummy = this.elements[i];
                this.elements[i] = this.elements[0];
                this.elements[0] = dummy;
                this.Count--;
                this.Heapify(0);
            }

            this.Count = realCount;
            //The elements in the heap needs to be reversed since the heapsort puts them in the reversed ordering
            Array.Reverse(this.elements, 0, this.Count);
        }

        /// <summary>
        /// Sorts the elements in the internal storage by using the System.Collections.Generic.Comparer<T> specified in the initialization when comparing elements.
        /// </summary>
        public void Sort()
        {
            Array.Sort<T>(this.elements, 0, this.Count);
        }

        /// <summary>
        /// Sorts the elements in the internal storage by using the System.Collections.Generic.Comparer<T>
        /// specified when comparing elements.
        /// </summary>
        /// <param name="comparer">The System.Collections.Generic.Comparer<T> to use when comparing elements.</param>
        public void Sort(IComparer<T> comparer)
        {
            Array.Sort<T>(this.elements, 0, this.Count, comparer);
        }

        /// <summary>
        /// Sorts the elements in the internal storage by using the System.Comparison&lt;T&gt;
        /// specified when comparing elements.
        /// </summary>
        /// <param name="comparison">The System.Comparison<T> to use when comparing elements.</param>
        public void Sort(Comparison<T> comparison)
        {
            Array.Sort<T>(this.elements, 0, this.Count, new ComparisonComparer(comparison));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the elements in the BinaryHeap<T>.
        /// </summary>
        /// <returns>the enumerator that iterates through the elements in the BinaryHeap<T>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the elements in the BinaryHeap<T>.
        /// </summary>
        /// <returns>the enumerator that iterates through the elements in the BinaryHeap<T>.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns the BinaryHeapEnumerator&lt;T&gt; that iterates through the elements in the BinaryHeap<T>.
        /// </summary>
        /// <returns>the BinaryHeapEnumerator&lt;T&gt; that iterates through the elements in the BinaryHeap<T>.</returns>
        public BinaryHeapEnumerator<T> GetEnumerator()
        {
            return new BinaryHeapEnumerator<T>(this.elements, this.Count);
        }

        /// <summary>
        /// Build the heap from scratch.
        /// </summary>
        private void BuildHeap()
        {
            // Bitwise operators are used for max performance
            for (int i = (this.Count >> 1) - 1; i >= 0; i--)
            {
                this.Heapify(i);
            }
        }

        /// <summary>
        /// Checks whether the heap property holds for the element at the specified index. If not then the element
        /// is cascaded downwards.
        /// </summary>
        /// <param name="index">The index of the element to check the heap property for.</param>
        private void Heapify(int index)
        {
            int l;
            int r;
            int pivot;
            int i = index;
            T dummy;

            while (i < this.Count)
            {
                l = (i << 1) + 1; //An alternative expression is l = 2 * i + 1;
                r = l + 1; //The right child has the index of the left child plus one.

                if (l < this.Count && comparer.Compare(this.elements[l], this.elements[i]) < 0)
                {
                    pivot = l;
                }
                else
                {
                    pivot = i;
                }

                if (r < this.Count && this.comparer.Compare(this.elements[r], this.elements[pivot]) < 0)
                {
                    pivot = r;
                }

                if (pivot == i)
                {
                    break; //The heap priority holds so the algorithm stops.
                }

                dummy = this.elements[i];
                this.elements[i] = this.elements[pivot];
                this.elements[pivot] = dummy;

                i = pivot;
            }
        }

        /// <summary>
        /// This is used for converting System.Comparison<T> inputs to a 
        /// System.Collections.Generic.Comparer<T> which the binary heap uses.
        /// </summary>
        private class ComparisonComparer : IComparer<T>
        {
            private readonly Comparison<T> comparison;

            /// <summary>
            /// The constructor creating the System.Collections.Generic.Comparer<T> based on the given 
            /// System.Comparison<T>.
            /// </summary>
            /// <param name="comparison">The System.Comparison<T> to use for the comparer.</param>
            public ComparisonComparer(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }

            /// <summary>
            /// The compare method. Returns an integer specified by the return value of the given comparison.
            /// </summary>
            /// <param name="x">The first value to compare.</param>
            /// <param name="y">The second value to compare.</param>
            /// <returns>The integer returned by the comparison based on the two given objects.</returns>
            public int Compare(T x, T y)
            {
                return this.comparison(x, y);
            }
        }
    }
}
