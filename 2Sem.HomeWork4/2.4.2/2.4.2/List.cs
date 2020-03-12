using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._2
{
    /// <summary>
    /// List on the nodes
    /// </summary>
    public class List
    {
        internal class ListElement
        {
            /// <summary>
            /// Element of the list
            /// </summary>
            /// <param name="value">Value of node</param>
            /// <param name="next">Pointer to the next node</param>
            public ListElement(int value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }

            public int value;
            public ListElement next;
        }

        private ListElement head;

        private int sizeOfList;

        /// <summary>
        /// Add element in list
        /// </summary>
        /// <param name="value">Value to add</param>
        public virtual void Add(int value)
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
        public void Delete(int value)
        {
            if (head == null)
            {
                throw new DeletingAnElementThatIsNotInTheListException("Error : Delete from empty list");
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

            throw new DeletingAnElementThatIsNotInTheListException($"Error : {value} is not contained in the list");
        }

        /// <summary>
        /// Check element for list belong
        /// </summary>
        /// <param name="value">Value of element</param>
        /// <returns>Belong or not</returns>
        public bool IsContain(int value)
        {
            if (head == null)
            {
                return false;
            }
            ListElement currentElement = head;
            while (currentElement != null)
            {
                if (currentElement.value == value)
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
        /// Clear list
        /// </summary>
        public void Clear()
        {
            head = null;
            sizeOfList = 0;
        }
    }
}