using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._1
{
    /// <summary>
    /// Stack based on references
    /// </summary>
    public class ListStack : IStack
    {

        /// <summary>
        /// Element of stack
        /// </summary>
        private class StackElement
        {
            public int value;
            public StackElement next;
            public StackElement(int value, StackElement next)
            {
                this.value = value;
                this.next = next;
            }
        }

        private StackElement head = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Push(int value)
        {
            if (head == null)
            {
                head = new StackElement(value, null);
                return;
            }

            head = new StackElement(value, head);
        }

        /// <summary>
        /// Delete first stack Element
        /// </summary>
        /// <returns>Deleted stack Element</returns>
        public (int, bool) Pop()
        {
            if (head == null)
            {
                return (0, false);
            }
            var currentElement = head;
            head = head.next;
            return (currentElement.value, true);
        }

        /// <summary>
        /// Check list for emptiness
        /// </summary>
        /// <returns>True or false</returns>
        public bool IsEmpty()
            => head == null ? true : false;

        /// <summary>
        /// Clear stack
        /// </summary>
        public void Clear()
        {
            head = null;
        }
    }
}