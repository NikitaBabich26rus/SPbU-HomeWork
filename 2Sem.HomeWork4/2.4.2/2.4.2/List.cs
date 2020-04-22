using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace _2._4._2
{
    /// <summary>
    /// List on the nodes
    /// </summary>
    public class List
    {
        /// <summary>
        /// List`s element
        /// </summary>
        private class ListElement
        {
            internal int value;
            internal ListElement next;

            /// <summary>
            /// ListElement`s constructor
            /// </summary>
            /// <param name="value"></param>
            /// <param name="next"></param>
            public ListElement(int value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }
        }
        private ListElement head;
        private int size;

        /// <summary>
        /// Add element in list
        /// </summary>
        /// <param name="value">Element`s value</param>
        /// <param name="position">Element`s position</param>
        public virtual void Add(int value, int position)
        {
            if (position > size + 1 || position <= 0)
            {
                return;
            }
            if (position == 1)
            {
                head = new ListElement(value, head);
                size++;
                return;
            }
            ListElement currentElement = head;
            for (int i = 1; position != i + 1; i++)
            {
                currentElement = currentElement.next;
            }
            currentElement.next = new ListElement(value, currentElement.next);
            size++;
        }

        /// <summary>
        /// Delete element in list by position
        /// </summary>
        /// <param name="position">Element`s position</param>
        public void Delete(int position)
        {
            if (position <= 0 || position > size)
            {
                throw new DeletingAnElementThatIsNotInTheListException("Error : delete from empty list");
            }
            if (position == 1)
            {
                head = head.next;
                size--;
                return;
            }

            ListElement currentElement = head;
            for (int i = 1; i <= size; i++)
            {
                if (position == i + 1)
                {
                    currentElement.next = currentElement.next.next;
                    size--;
                    return;
                }
                currentElement = currentElement.next;
            }
        }

        /// <summary>
        /// Check list for emptiness
        /// </summary>
        /// <returns>Is empty or not</returns>
        public bool IsEmpty() => size == 0;

        /// <summary>
        /// Get list`s size
        /// </summary>
        /// <returns>List`s size</returns>
        public int GetSize() => size;

        /// <summary>
        /// Get element in list by position
        /// </summary>
        /// <param name="position">Element`s position</param>
        /// <returns>Element`s position</returns>
        public int GetElement(int position)
        {
            if (position > size || position <= 0)
            {
                return -1;
            }
            ListElement currentElement = head;
            for (int i = 1; i <= size; i++)
            {
                if (position == i)
                {
                    return currentElement.value;
                }
                currentElement = currentElement.next;
            }
            return currentElement.value;
        }

        /// <summary>
        /// Check the element for contain in list
        /// </summary>
        /// <param name="value">element`s value</param>
        /// <returns>Is contain or not</returns>
        public bool IsContain(int value)
        {
            var currentElement = head;
            while(currentElement != null)
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
        /// List output
        /// </summary>
        public void OutputList()
        {
            ListElement currentElement = head;
            for (int i = 1; i <= size; i++)
            {
                Console.Write(currentElement.value + " ");
                currentElement = currentElement.next;
            }
            Console.WriteLine();
        }
    }
}