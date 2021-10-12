using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Vector
{
    /// <summary>
    /// Class vector on lists
    /// </summary>
    public class VectorOnList
    {
        /// <summary>
        /// Vector dimensionю
        /// </summary>
        public int Size { get; private set; }

        private VectorElement head = null;
        private VectorElement tail = null;

        /// <summary>
        /// Vector`s constructor.
        /// </summary>
        /// <param name="vector">vector array with values</param>
        public VectorOnList(int[] vector)
        {
            Size = vector.Length;
            foreach(var value in vector)
            {
                AddElementInVector(value);
            }
        }

        /// <summary>
        /// Add element in vector from array.
        /// </summary>
        /// <param name="value">element`s value</param>
        private void AddElementInVector(int value)
        {
            if (head == null)
            {
                head = new VectorElement(value, null);
                tail = head;
                return;
            }
            var currentElement = new VectorElement(value, null);
            tail.next = currentElement;
            tail = currentElement;
        }

        /// <summary>
        /// Vector element
        /// </summary>
        private class VectorElement
        {
            public int value;

            public VectorElement next; 

            public VectorElement(int value, VectorElement next)
            {
                this.value = value;
                this.next = next;
            }
        }

        /// <summary>
        /// Get vector array with values.
        /// </summary>
        /// <returns></returns>
        public int[] GetVectorArray()
        {
            int[] array = new int[Size];
            int count = 0;
            var currentElement = head;
            while(currentElement != null)
            {
                array[count] = currentElement.value;
                count++;
                currentElement = currentElement.next;
            }
            return array;
        }
    }
}
