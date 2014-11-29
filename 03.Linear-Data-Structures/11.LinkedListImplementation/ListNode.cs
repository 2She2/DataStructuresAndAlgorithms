namespace _11.LinkedListImplementation
{
    using System;
    using System.Collections.Generic;

    public class ListNode<T>
    {
        public ListNode()
        {
        }

        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public ListNode<T> Next { get; set; }

        public ListNode<T> Previous { get; set; }
    }
}
