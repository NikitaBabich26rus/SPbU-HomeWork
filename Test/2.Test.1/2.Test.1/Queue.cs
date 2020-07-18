using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Test._1
{
    /// <summary>
    /// Queue with priority
    /// </summary>
    /// <typeparam name="T">Type of value</typeparam>
    public class Queue<T>
    {
        private QueueElement head;
        private QueueElement tail;

        /// <summary>
        /// QueueElement class
        /// </summary>
        private class QueueElement
        {
            internal int priority;
            internal T value;
            internal QueueElement next;
            internal QueueElement previous;

            /// <summary>
            /// QueueElement constructor
            /// </summary>
            /// <param name="value"> value of element</param>
            /// <param name="priority">priority of element</param>
            public QueueElement(T value, int priority)
            {
                this.value = value;
                this.priority = priority;
            }
        }

        /// <summary>
        /// Add new element with priority
        /// </summary>
        /// <param name="value">value of element</param>
        /// <param name="priority">priority of element</param>
        public void Enqueue(T value, int priority)
        {
            var newElement = new QueueElement(value, priority);
            if (head == null)
            {
                head = newElement;
                tail = newElement;
                return;
            }
            var currentElement = tail;
            while(currentElement.priority < newElement.priority)
            {
                if (currentElement.next == null)
                {
                    currentElement.next = newElement;
                    newElement.previous = currentElement;
                    head = newElement;
                    return;
                }
                currentElement = currentElement.next;
            }
            if (currentElement.previous == null)
            {
                currentElement.previous = newElement;
                newElement.next = currentElement;
                tail = newElement;
                return;
            }
            var previousElement = currentElement.previous;
            newElement.next = currentElement;
            newElement.previous = previousElement;
            previousElement.next = newElement;
            currentElement.previous = newElement;
        }

        /// <summary>
        /// Delete and return element with the most priority
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (head == null)
            {
                throw new DequeueFromEmptyQueueException();
            }
            var currentElement = head;
            head = currentElement.previous;
            if (head != null)
            {
                head.next = null;
            }
            return currentElement.value;
        }
    }
}
