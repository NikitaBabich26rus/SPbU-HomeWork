using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._2
{
    /// <summary>
    /// List on the nodes
    /// </summary>
    public class List
    {
        private class ListElement
        {
            /// <summary>
            /// Element of the list
            /// </summary>
            /// <param name="value">Value of node</param>
            /// <param name="next">Pointer to the next node</param>
            public ListElement(string value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }

            public string value;
            public ListElement next;
        }

        private ListElement head;

        private int sizeOfList;

        /// <summary>
        /// Add element in list
        /// </summary>
        /// <param name="value">Value to add</param>
        public void Add(string value)
        {
            if (head == null)
            {
                head = new ListElement(value, null);
                sizeOfList++;
                return;
            }

            if (head.value == value)
            {
                return;
            }

            var currentElement1 = head;
            var currentElement2 = head.next;
            while (currentElement2 != null)
            {
                if (currentElement2.value == value)
                {
                    return;
                }
                currentElement1 = currentElement2;
                currentElement2 = currentElement2.next;
            }
            sizeOfList++;
            currentElement1.next = new ListElement(value, null);
        }

        /// <summary>
        /// Delete element of the list
        /// </summary>
        /// <param name="value">Value of element for deletion</param>
        public void Remove(string value)
        {
            if (head == null)
            {
                return;
            }
            if (head.value == value)
            {
                sizeOfList--;
                head = head.next;
                return;
            }
            var currentElement1 = head;
            var currentElement2 = currentElement1.next;
            while (currentElement2 != null)
            {
                if (currentElement2.value == value)
                {
                    sizeOfList--;
                    currentElement1.next = currentElement2.next;
                    return;
                }
            }
        }

        /// <summary>
        /// Check element for list belong
        /// </summary>
        /// <param name="value">Value of element</param>
        /// <returns>Belong or not</returns>
        public bool IsContain(string value)
        {
            if (head == null)
            {
                return false;
            }
            ListElement currentElement = head;
            while (currentElement != null)
            {
                if (string.Compare(currentElement.value, value) == 0)
                {
                    return true;
                }
                currentElement = currentElement.next;
            }
            return false;
        }

        /// <summary>
        /// Get size of list
        /// </summary>
        /// <returns>Size</returns>
        public int GetSize()
        => sizeOfList;

        /// <summary>
        /// Check list for emptiness
        /// </summary>
        /// <returns>Empty or not</returns>
        public bool IsEmpty() => sizeOfList == 0;

        /// <summary>
        /// Delete first element of list
        /// </summary>
        /// <returns>Deleted element</returns>
        public string Pop()
        {
            if (head != null)
            {
                sizeOfList--;
                var helpElement = head;
                head = head.next;
                return helpElement.value;
            }
            return null;
        }

        /// <summary>
        /// Clear list
        /// </summary>
        public void Clear()
        {
            head = null;
            sizeOfList = 0;
        }
    }
}