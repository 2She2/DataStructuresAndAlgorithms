namespace _11.LinkedListImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList2<T> : IEnumerable, IEnumerable<T>
    {
        public int Count { get; private set; }

        public ListNode<T> FirstElement { get; private set; }

        public ListNode<T> LastElement { get; private set; }

        public void AddFirst(T value)
        {
            var newNode = new ListNode<T>(value);

            if (this.FirstElement == null)
            {
                this.FirstElement = newNode;
                this.LastElement = newNode;
            }
            else
            {
                newNode.Next = this.FirstElement;

                this.FirstElement.Previous = newNode;
                this.FirstElement = newNode;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            var newNode = new ListNode<T>(value);

            if (this.FirstElement == null)
            {
                this.FirstElement = newNode;
                this.LastElement = newNode;
            }
            else
            {
                newNode.Previous = this.LastElement;

                this.LastElement.Next = newNode;
                this.LastElement = newNode;
            }

            this.Count++;
        }

        public ListNode<T> RemoveFirst()
        {
            if (this.FirstElement == null)
            {
                throw new NullReferenceException("The linked list is empty!");
            }
            else
            {
                var head = this.FirstElement;

                this.FirstElement = this.FirstElement.Next;
                this.FirstElement.Previous = null;
                this.Count--;

                return head;
            }
        }

        public ListNode<T> RemoveLast()
        {
            if (this.FirstElement == null)
            {
                throw new NullReferenceException("The linked list is empty!");
            }
            else
            {
                var tail = this.LastElement;

                this.LastElement = this.LastElement.Previous;
                this.LastElement.Next = null;
                this.Count--;

                return tail;
            }
        }

        public void Clear()
        {
            this.FirstElement = null;
            this.LastElement = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currNode = this.FirstElement;

            while (currNode != null)
            {
                yield return currNode.Value;
                currNode = currNode.Next;
            }
        }
    }
}
